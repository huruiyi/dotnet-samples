(function ($) {
  $.extend(this, {
    layer: function () {
      const body = $('body');
      const layerChild = '<div class="layer" style = " background: rgba(0,0,0,0.8); position: fixed; top: 0; left: 0;"></div>';
      body.html(layerChild)
    }
  }, {
    width: 100,
    height: 100
  })
})(jQuery)
