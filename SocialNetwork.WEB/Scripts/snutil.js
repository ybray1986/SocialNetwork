$(document).ready(function () {
    //category = $('.category');
    //categoryWrapper = $('.category-wrapper');
    //toggleCatDropDown = function () {
    //    if (categoryWrapper.hasClass('active')) {
    //        categoryWrapper.removeClass('active');
    //    } else {
    //        categoryWrapper.addClass('active');
    //    }
    //};
    //category.on('click', toggleCatDropDown);
    typeahead = $('.typeahead');
    field = $('.field');

    toggleSearchDropDown = function () {

        if (field.val() === "") {
            typeahead.css("display", "none");
        } else {
            typeahead.css("display", "block");
        }
    };

    field.on('keyup', toggleSearchDropDown);
});
