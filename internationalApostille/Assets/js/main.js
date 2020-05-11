$(function () {
    // Site is ready
    $('.chat-header').click(function () {
        $(this).closest('.chat-wrapper').toggleClass('open');
    })
})