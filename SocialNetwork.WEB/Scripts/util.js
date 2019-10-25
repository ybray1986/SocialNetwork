$(document).ready(function () {
    var body = $('body');
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
    profile = $('.profile');
    profileDropdown = $('.profile-dropdown');
    toggleProfileDropDown = function () {
        if (profileDropdown.css("display") === "block") {
            profileDropdown.css("display", "none");
        } else {
            profileDropdown.css("display", "block");
        }
    };
    profile.on('click', toggleProfileDropDown);
    //
    open_modal = $('.open-modal');
    close_modal = $('.close-modal');
    modal_container = $('.modal-container');
    toggleModal = function () {
        body.toggleClass('body-locked');
        modal_container.toggleClass('dp-block');
    };
    open_modal.on('click', toggleModal);
    close_modal.on('click', toggleModal);
    //
    function GetUserPosts() {
        $.ajax({
            url: '/api/content/',
            type: 'GET',
            dataType: 'json',
            success: function (data) {

            },
            error: function (err) {
                alert(err);
            }
        });
    };
    //
    var categoriesDDL = $('#list-categories-form');
    $.ajax({
        url: 'api/data',
        method: 'post',
        dataType: 'json',
        success: function (data) {
            $(data).each(function (index, item) {
                categoriesDDL.append($('<option>').val(item.IdCategory).text(item.CategoryName));
            });
        }
    });
    //
    $('.submit-content-button').click(function (e) {
        e.preventDefault();
        AddBook();
    });
    function AddBook() {
        var data = new FormData();
        var category = $('#list-categories-form').find(":selected").text();
        var content = $('.content-form').val();
        var files = $('#upload-image-form').get(0).files[0];
        data.append("category", category);
        data.append("content", content);
        data.append("image", files);
        //if (files.length > 0) {
        //    data.append("image", files[0]);
        //}
        $.ajax({
            url: 'api/content',
            method: 'post',
            data: data,
            enctype: 'multipart/form-data',
            contentType: false,
            processData: false,
            success: function (result) { console.log(result); },
            error: function (err) { console.log(err); }
        });
    };
    //
});
