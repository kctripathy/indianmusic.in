using IndianMusic.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IndianMusic.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public readonly IEmailSenderFromApp _emailsender;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IEmailSenderFromApp emailsender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailsender = emailsender;
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

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { userId = user.Id, token = token }, Request.Scheme);

                    // TODO: send email using Gmail API helper here
                    await _emailsender.SendEmailAsync (user.DisplayName, user.Email, "Confirm your email", $"Please confirm your account by clicking this link: {confirmationLink}");

                    return View("RegistrationPending", user); // tell user to check email
                                                        // Commented because user can sign only after confirmation
                                                        // await _signInManager.SignInAsync(user, isPersistent: false);
                                                        // return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID '{userId}' not found.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            
            ViewBag.IsEmailConfirmed = (bool) result.Succeeded;

            if (result.Succeeded)
            {
                return View("ConfirmEmail"); // Renders ConfirmEmail.cshtml
            }
            else
            {
                return View("ConfirmEmail"); // Optional error view
            }
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

        public IActionResult LoginWithGoogle(string returnUrl = "/")
        {
            var props = new AuthenticationProperties { RedirectUri = returnUrl };
            return Challenge(props, "Google");
        }

        public IActionResult LogoutWithGoogle()
        {
            return SignOut(new AuthenticationProperties { RedirectUri = "/" },
                           CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl = "/")
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "/", string remoteError = null)
        {
            if (remoteError != null)
                return RedirectToAction("Login");

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction("Login");

            // Sign in the user with this external login provider
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);

            if (result.Succeeded)
                return LocalRedirect(returnUrl);

            // If the user does not have an account, create one
            var email = info.Principal.FindFirstValue(System.Security.Claims.ClaimTypes.Email);
            if (email != null)
            {
                var user = new ApplicationUser { UserName = email, Email = email };
                var createResult = await _signInManager.UserManager.CreateAsync(user);
                if (createResult.Succeeded)
                {
                    await _signInManager.UserManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
            }

            return RedirectToAction("Login");
        }
    }
}
