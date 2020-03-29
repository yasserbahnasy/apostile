 $(function () {
    $('#menu-item-26').addClass('current-menu-item');
    //Sidebar

    $('.sidebar').stickySidebar({
        containerSelector: '#main-content',
        innerWrapperSelector: '.sidebar__inner',
        resizeSensor: true,
        topSpacing: 20,
        minWidth: 767
    })
})