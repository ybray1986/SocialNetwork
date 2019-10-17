$(document).ready(function () {
    var body = $('body');
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
    //
    close_modalpopup = $('.close-modalpopup');
    addcontent = $('.addcontent');
    modal_content = $('.modal-content');
    toggleNewContentPopUp = function () {
        body.toggleClass('body-locked');
        modal_content.toggleClass('dp-block');
    };
    addcontent.on('click', toggleNewContentPopUp);
    close_modalpopup.on('click', toggleNewContentPopUp);
    //
});
