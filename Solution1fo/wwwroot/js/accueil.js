// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.onscroll = function (e) {
    var header = document.getElementById("navbar");
    var navbar_deployed = document.getElementById("navbar_deployed");
    if (window.pageYOffset == 0 && !(navbar_deployed.classList.contains("show"))) {
        header.classList.add("bg-opaque");
        header.classList.remove("bg-opaque-fixed");
    }
    else {
        header.classList.remove("bg-opaque");
        header.classList.add("bg-opaque-fixed");
    }
}

var element = document.getElementById('navbar_deployed');

// Créez une instance de MutationObserver avec une fonction de rappel
var observer = new MutationObserver(function (mutations) {
    mutations.forEach(function (mutation) {
        // Vérifiez si la classe a changé
        if (mutation.type === 'attributes' && mutation.attributeName === 'class') {
            // La classe a changé, effectuez votre action ici
            console.log('La classe a changé : ', element.className);

            // Appelez votre fonction ou effectuez votre action ici
            votreFonction();
        }
    });
});

// Configurez l'observateur pour surveiller les modifications de classe
var config = { attributes: true, attributeFilter: ['class'] };
observer.observe(element, config);

// Fonction à exécuter lorsque la classe change
function votreFonction() {
    // Votre code ici
    var header = document.getElementById("navbar");
    var navbar_deployed = document.getElementById("navbar_deployed");
    if (navbar_deployed.classList.contains("show")) {
        header.classList.remove("bg-opaque");
        header.classList.add("bg-opaque-fixed");
    }
    else if (window.pageYOffset == 0) {
        header.classList.add("bg-opaque");
        header.classList.remove("bg-opaque-fixed");
    }
}