// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('input[type=radio][name=status]').change(function () {
    entreprise = $("#entreprise_group");
    entreprise_name = $("#entreprise_name");
    association = $("#association_group");
    association_name = $("#association_name");
    if (this.value == "entreprise") {
        entreprise.removeClass("visually-hidden");
        entreprise_name.prop({ required: true });
        if (!association.hasClass("visually-hidden")) {
            association.addClass("visually-hidden");
            association_name.removeAttr("required");
        }
    }
    else if (this.value == "association") {
        association.removeClass("visually-hidden");
        association_name.prop({ required: true });
        if (!entreprise.hasClass("visually-hidden")) {
            entreprise.addClass("visually-hidden");
            entreprise_name.removeAttr("required");
        }
    }
    else {
        entreprise_name.removeAttr("required");
        association_name.removeAttr("required");
        if (!association.hasClass("visually-hidden")) {
            association.addClass("visually-hidden");
        }
        if (!entreprise.hasClass("visually-hidden")) {
            entreprise.addClass("visually-hidden");
        }
    }
});