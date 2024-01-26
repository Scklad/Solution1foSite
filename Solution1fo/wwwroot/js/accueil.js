// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.onscroll = function (e) {
    var header = document.getElementById("navbar");
    if (window.pageYOffset == 0) {
        header.classList.add("bg-opaque");
        header.classList.remove("bg-opaque-fixed");
    }
    else {
        header.classList.remove("bg-opaque");
        header.classList.add("bg-opaque-fixed");
    }
}