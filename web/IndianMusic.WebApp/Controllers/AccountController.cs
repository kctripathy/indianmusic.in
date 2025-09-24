using IndianMusic.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IndianMusic.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // ==========================
        // LOGIN
        // ==========================
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe, string returnUrl = null)
        {
            ViewData["ReturnUrl"]  = returnUrl ?? Url.Content("~/"); // fallback to home;

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user != null && user.IsActive)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, password, rememberMe, false);

                    if (result.Succeeded)
                    {
                        // Role-based redirect
                        if (await _userManager.IsInRoleAsync(user, "Admin"))
                            return RedirectToAction("Dashboard", "Admin");
                        else
                            return RedirectToLocal(returnUrl);
                    }

                    if (result.IsLockedOut)
                        return RedirectToAction(nameof(Lockout));
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View();
        }

        // ==========================
        // REGISTER
        // ==========================
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string email, string displayName, string password)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    DisplayName = displayName,
                    IsActive = true,
                    DateAdded = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    // Assign default role
                    await _userManager.AddToRoleAsync(user, "User");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View();
        }

        // ==========================
        // LOGOUT
        // ==========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Lockout() => View();

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
