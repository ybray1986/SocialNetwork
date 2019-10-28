$(document).ready(function () {
    var resultObj;
    GetContent();
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
    function GetPostImage(data) {
        $.ajax({
            url: 'web/Data/PostImage',
            type: 'post',
            data: 'image='+data,
            success: function (image) {
                return image;
            },
            error: function (err) {
                console.log("Error Image here:" + err);
            }
        });
    };
    //
    function GetPostImageById(data) {
        $.ajax({
            url: 'Image/Post',
            type: 'get',
            data: 'id=' + data,
            success: function (image) {
                return image;
            },
            error: function (err) {
                console.log("Error PostImageId here:" + err);
            }
        });
    };
    //
    function GetLikes(data) {
        $.ajax({
            url: 'web/Data/Likes',
            type: 'get',
            data: 'id='+data,
            success: function (likes) {
                return likes;
            },
            error: function (err) {
                console.log("Error Likes here:" + err);
            }
        });
    };
    //
    function GetUserImage(data) {
        $.ajax({
            url: 'web/Data/UserImage',
            type: 'post',
            data: 'image=' + data,
            success: function (image) {
                return image;
            },
            error: function (err) {
                console.log("Error UserImage here:" + err);
            }
        });
    };
    //
    function GetUserImageById(data) {
        $.ajax({
            url: 'Image/User',
            type: 'get',
            data: 'id=' + data,
            success: function (image) {
                return image;
            },
            error: function (err) {
                console.log("Error UserImageId here:" + err);
            }
        });
    };
    //
    function GetUserName(data) {
        $.ajax({
            url: 'web/Data/UserName',
            type: 'get',
            data: 'id='+data,
            success: function (name) {
                return name;
            },
            error: function (err) {
                console.log("Error UserName here:" + err);
            }
        });
    };
    //
    function GetCategoryName(data) {
        $.ajax({
            url: 'web/Data/CatName',
            type: 'get',
            data: 'id='+data,
            success: function (cat) {
                return cat;
            },
            error: function (err) {
                console.log("Error UserName here:" + err);
            }
        });
    };
    //
    var userName;
    var userImage;
    function toggleModal() {
        body.toggleClass('body-locked');
        var id = $(this).attr('data-item');
        $('.modal-container').toggleClass('dp-block');
        $.ajax({
            url: 'web/Data/Comments',
            type: 'get',
            data: 'id='+id,
            success: function (data) {
                $(data).each(function (index, comment) {
                    userImage = GetUserImageById(comment.IdUser);
                    userName = GetUserName(comment.IdUser);
                    var box = $(
                        '               <div class="pin-description-comment detailed">' +
                        '                   <a class="user-thumb-container" href="#">' +
                        '                       <img class="user-thumb" alt="" src="' + userImage + '" />' +
                        '                   </a>' +
                        '                   <div class="commenter-name-comment-text">' +
                        '                       <div class="commenter-wrapper">' +
                        '                           <a class="comment-description-creator" href="#">' +
                        '                               ' + userName + '' +
                        '                           </a>' +
                        '                           <span class="comment-description-time-ago">' +
                        '                               ' + comment.CommentDate +'' +
                        '                           </span>' +
                        '                       </div>' +
                        '                       <h1 class="comment-description-content">' +
                        '                           ' + comment.CommentText+'' +
                        '                       </h1>' +
                        '                   </div>' +
                        '               </div>'
                    );
                    $('.comments-data').append(box);
                });
            },
            error: function (err) {
                console.log('Modal-Container:' + err);
            }
        });
    };
    $('#container').on('click', '.open-modal', toggleModal);
    $('#container').on('click', '.close-modal', toggleModal);
    //
    function GetContent() {
        var container = $('#container');
        var categoryName;
        var userName;
        var userImage;
        var imageData;
        var likesData;
        var commentsData;
        
        $.ajax({
            url: 'web/Content/Content',
            type: 'get',
            success: function (data) {
                container.html('<div class="grid-sizer"></div>');
                $(data).each(function (index, post) {
                    categoryName = GetCategoryName(post.IdCategory);
                    userName = GetUserName(post.IdUser);
                    userImage = GetUserImage(post.IdUser);
                    imageData = GetPostImage(post.PostImage);
                    likesData = GetLikes(post.IdPost);
                    var box = $(
                        '<div class="item open-modal" data-item="' + post.IdPost + '">' +
                        '   <a href="#">' +
                        '       <img src="' + imageData + '"></img>' +
                        '   </a>' +
                        '   <div class="pin-meta">' +
                        '       <p class="pin-description">' + post.PostContent + '</p>' +
                        '       <div class="pin-social-meta">' +
                        '           <a class="social-item likes" href=#">' + likesData + ' likes</a>' +
                        '           <a class="social-item comments" href="#">' + commentsData + ' comments</a>' +
                        '       </div>' +
                        '   </div>' +
                        '   <div class="pin-user-attribution">' +
                        '       <a class="attribution-item first-attribution " href="#">' +
                        '           <img class="attribution-img" style="" src="' + userImage + '"></img>' +
                        '           <span class="attribution-title">' +
                        '               Posted by' +
                        '           </span>' +
                        '           <span class="attribution-name">' + userName +
                        '           </span>' +
                        '       </a>' +
                        '       <a class="attribution-item last-attribution " href="#">' +
                        '           <img class="attribution-img" style="" src="' + userImage + '"></img>' +
                        '           <span class="attribution-title">' +
                        '               in' +
                        '           </span>' +
                        '           <span class="attribution-name">' + categoryName + '</span>' +
                        '       </a>' +
                        '   </div>' +
                        '</div>' +
                        '<div class="modal-container dp-none">' +
                        '   <button class= "buttonC borderless close visible close-modal" style="right: 31px;" >' +
                        '       <em></em>' +
                        '   </button>' +
                        '   <div class="modal-popup">' +
                        '       <div class="modal-box">' +
                        '           <img src="~/Content/images/pin1.jpg" />' +
                        '       </div>' +
                        '       <div class="modal-box">' +
                        '           <div class="pin-description comments-data">' +
                        '           </div>' +
                        '           <div class="pin-description-comment detailed">' +
                        '               <a class="user-thumb-container" href="">' +
                        '                   <img class="user-thumb" alt="" src="~/Content/photo/Users/default/default-24.png" />' +
                        '               </a>' +
                        '               <div class="commenter-name-comment-text">' +
                        '                   <div class="commenter-wrapper">' +
                        '                       <a class="comment-description-creator" href="#">' +
                        '                           July Mark' +
                        '                       </a>' +
                        '                       <span class="comment-description-time-ago">' +
                        '                           This is you' +
                        '                       </span>' +
                        '                   </div>' +
                        '                   <h1 class="comment-description-content">' +
                        '                      <div class="">' +
                        '                           <textarea class="content" placeholder="Comment this post" name="description"></textarea>' +
                        '                      </div>' +
                        '                   </h1>' +
                        '                   <p>' +
                        '                       <button class="buttonC btn primary add-comment" type="button">' +
                        '                           <span class="button-text">' +
                        '                               Submit' +
                        '                           </span>' +
                        '                       </button>' +
                        '                   </p>' +
                        '               </div>' +
                        '           </div>' +
                        '       </div >' +
                        '   </div >' +
                        '</div >'
                    );
                    container.append(box);
                    //container.prepend(box).masonry('reload');
                    container.masonry('appended', box, true);
                    //container.masonry({
                    //    isAnimated: true,
                    //    animationOptions: {
                    //        duration: 750,
                    //        easing: 'linear',
                    //        queue: false
                    //    }
                    //});
                    container.masonry();
                });
            },
            error: function (err) {
                console.log("Error here:" + err);
            }
        });
        
    };
    //
    $('.add-comment').click(function (e) {
        e.preventDefault();
        AddComment();

    });
    //
    function AddComment() {
        var id = $(this).attr('data-item');
        var data = new FormData();
        var text = $('#list-categories-form').find(":selected").val();
        var data = $('.content-form').val();
        var postId = $('#upload-image-form').get(0).files[0];
        data.append("category", category);
        data.append("content", content);
        data.append("file", files);
        $.ajax({
            url: 'web/Content/Create',
            method: 'post',
            data: data,
            contentType: false,
            processData: false,
            success: function () { toggleModal(); },
            error: function (err) { console.log(err); }
        });
    };
    };
    //
    var categoriesDDL = $('#list-categories-form');
    $.ajax({
        url: 'web/Data/CategoryList',
        method: 'get',
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
        var category = $('#list-categories-form').find(":selected").val();
        var content = $('.content-form').val();
        var files = $('#upload-image-form').get(0).files[0];
        data.append("category", category);
        data.append("content", content);
        data.append("file", files);
        $.ajax({
            url: 'web/Content/Create',
            method: 'post',
            data: data,
            contentType: false,
            processData: false,
            success: function () { GetContent(); },
            error: function (err) { console.log(err); }
        });
    };
    //
});

