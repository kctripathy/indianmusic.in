const themeToggleBtn = document.getElementById('themeToggleBtn');

function setTheme(theme) {
    document.documentElement.setAttribute('data-bs-theme', theme);
    localStorage.setItem('theme', theme);
}

function toggleTheme() {
    const currentTheme = document.documentElement.getAttribute('data-bs-theme') || 'light';
    const newTheme = currentTheme === 'light' ? 'dark' : 'light';
    if (newTheme == 'dark') {
        $(themeToggleBtn).prop('checked', true);
        $('.light-theme').each(function () {
            $(this)
                .removeClass('light-theme light-menu-theme light-btn')
                .addClass('dark-theme dark-menu-theme dark-btn');
        });
    }
    else {
        $(themeToggleBtn).prop('checked', false);
        $('.dark-theme').each(function () {
            $(this)
                .removeClass('dark-theme dark-menu-theme dark-btn')
                .addClass('light-theme light-menu-theme light-btn');
        });
    }
    setTheme(newTheme);
}

// Initialize theme on page load
(function initializeTheme() {
    const savedTheme = localStorage.getItem('theme') || 'light';
    setTheme(savedTheme);
})();

themeToggleBtn.addEventListener('click', toggleTheme);

// Handle submenu toggle
document.querySelectorAll('.dropdown-submenu .dropdown-toggle').forEach(function (el) {
    el.addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        // Close any open submenus
        let openMenus = el.closest('.dropdown-menu').querySelectorAll('.show');
        openMenus.forEach(menu => {
            if (menu !== el.nextElementSibling) {
                menu.classList.remove('show');
            }
        });

        // Toggle current submenu
        el.nextElementSibling.classList.toggle('show');
    });
});

// Close all dropdowns when clicking outside
document.addEventListener('click', function () {
    document.querySelectorAll('.dropdown-menu .show').forEach(function (menu) {
        menu.classList.remove('show');
    });
});
