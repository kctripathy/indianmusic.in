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
                .removeClass('light-theme light-music')
                .addClass('dark-theme dark-music');
        });
    }
    else {
        $(themeToggleBtn).prop('checked', false);
        $('.dark-theme').each(function () {
            $(this)
                .removeClass('dark-theme dark-music')
                .addClass('light-theme light-music');
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



function addToFavorites(url, title) {
    if (window.external && ('AddFavorite' in window.external)) {
        // Old IE only
        window.external.AddFavorite(url, title);
    } else {
        alert("Press Ctrl+D (Windows) or Cmd+D (Mac) to bookmark this page.");
    }
}

$("#addFav").on("click", function (e) {
    e.preventDefault();
    var url = window.location.href;
    var title = document.title;

    try {
        // Old IE only
        if (window.external && ('AddFavorite' in window.external)) {
            window.external.AddFavorite(url, title);
        }
        // Firefox <23 (very old)
        else if (window.sidebar && window.sidebar.addPanel) {
            window.sidebar.addPanel(title, url, "");
        }
        // Modern browsers
        else {
            const isMac = navigator.platform.toUpperCase().indexOf('MAC') >= 0;
            alert("Press " + (isMac ? "Cmd" : "Ctrl") + "+D to bookmark this page.");
        }
    } catch (err) {
        alert("Press Ctrl+D (or Cmd+D on Mac) to bookmark this page.");
    }
});