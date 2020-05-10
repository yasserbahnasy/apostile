$(document).ready(function () {
    $("#SubmitBlogPost").click(function () {
        alert($('.summernote').summernote('code'));
    
    $.ajax(
        {
            url: "/Admin/CreateBlogPost",
            type: "POST",
            data: {
                Title: $("#kt_maxlength_4").val(),
                Keywords: $("#kt_tagify_1").val(),
                MetaDescription: $("#kt_maxlength_4").val(),
                Description: $('.summernote').summernote('code'),
                PublishedDate: $("#PublishedDate").val(),
                Visibility: $("#Visibility option:selected").val(),
                url: $("#permaLink").val(),
                CategoryID: $("#CategoryID option:selected").val()
            }, success: function (result) {
                if (result == 'no') {  // Mail is registered in the DataBase
                    setTimeout(function () {
                        btn.removeClass('kt-spinner kt-spinner--right kt-spinner--sm kt-spinner--light').attr('disabled', false);
                        showErrorMsg(form, 'danger', 'Incorrect username or password. Please try again.');
                    }, 2000);
                } else {
                    window.location.replace("/Admin");
                }
            }
        });
    })
})
