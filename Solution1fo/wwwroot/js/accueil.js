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

$("#navbar_button").click(function (e) {
    var header = document.getElementById("navbar");
    alert("test");
    if (window.pageYOffset == 0 && header.classList.contains("bg-opaque")) {
        header.classList.remove("bg-opaque");
        header.classList.add("bg-opaque-fixed");
    }
    else if (window.pageYOffset == 0 && header.classList.contains("bg-opaque-fixed")) {
        header.classList.add("bg-opaque");
        header.classList.remove("bg-opaque-fixed");
    }
    else {
        header.classList.remove("bg-opaque");
        header.classList.add("bg-opaque-fixed");
    }
});