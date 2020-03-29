$(function() {
  //Home is ready
  var homeSlider = $("#homeHero");
  homeSlider.owlCarousel({
    loop: true,
    items: 1,
    nav: false,
    dots: false,
    autoplay: true,
    animateOut: "fadeOut",
    animateIn: "fadeIn",
    margin: 0
  });
  $("#controllerBack").click(function(e) {
    homeSlider.trigger("prev.owl.carousel");
  });
  $("#controllerNext").click(function(e) {
    homeSlider.trigger("next.owl.carousel");
  });
});
