(function ($) {
    $.fn.slider = function ()
    {
        var parent = $(this);
        var celement = 0;
        var ancholist = 0;
        var total = 0;
        var lista = $(".items", this);
        var imgs = $(".mask img", this);
        $(".items li", this).each(function ()
        {
            total = $(this).width() + Number($(this).css("margin-left").substr(0, $(this).css("margin-left").indexOf("px")));
            ancholist = ancholist + total;
            celement++;
        });
        var moveimg = 0;
        var movelist = 0;
        $(".items").css("width", ancholist);
        var anchoimg;
        $(".mask img", this).load(function ()
        {
            anchoimg = $(this).width();
            moveimg = (anchoimg - parent.width()) / celement;
            movelist = total;
            var cc = 0;
            console.debug(celement);
            setInterval(function () {
                console.debug(cc + " " + celement);
                if (cc == celement)
                {
                    imgs.animate({ "margin-left": 0 }, 1000);
                    lista.animate({ "margin-left": 0 },1000);
                    cc=-1;
                }
                else
                {
                    imgs.animate({ "margin-left": "+=-" + moveimg }, 1000);
                    lista.animate({ "margin-left": "+=-" + movelist }, 1000);
                }
                cc++;
            }, 5000);
        });
    }
})(jQuery)