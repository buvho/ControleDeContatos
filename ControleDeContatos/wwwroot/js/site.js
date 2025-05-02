// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const alert = document.querySelectorAll('.close-alert');

alert.forEach((el) => {
    el.addEventListener('click', function () {
        el.parentElement.style.display = 'none';
    })
});

