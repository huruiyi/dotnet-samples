(function ($) {

    $.fn.dottify = function (options) {
        var dots = [];
        var dotBox = this;
        var transitionTime = 500;
        var running = true;
        var timer;

        var settings = $.extend({
            numDots: 5, //Number of dots
            swoopPause: 200, //Pause time between dots
            dotColor: "#0A78C7",
            dotSize: "12px",
            radius: "100%",
            randomColors: false, //random colors on switch
            progress: false,
            percent: 0 
        }, options);

        var $dotsSelelector;

        function createDots() {
            dotBox.css({
                position: "relative",
                overflow: "hidden"
            }); 

            if ( settings.progress && !options.numDots )
                settings.numDots = 30;

            for (var i = 0; i < settings.numDots; i++) {
                var percent = ( i + .5 ) * ( 100 / settings.numDots );
                var dot = $('<div class="swoopDot"></div>').data( "pos", percent );
                dots.push( dot.appendTo( dotBox ) );
            }

            $dotsSelelector = dotBox.find( ".swoopDot" ).css({
                'background-color'  : settings.dotColor, 
                width               : settings.dotSize, 
                height              : settings.dotSize,
                'border-radius'     : settings.radius
            });

            if ( settings.progress )
            {
                var dotWidth = dotBox.width() / settings.numDots;

                $dotsSelelector.css({ height: "90%", width: dotWidth * .6 });                
            }

        }

        function swoop(left) {

            var addClass = left?"swoopReverse":"swoopActive";

            $dotsSelelector.removeClass( "swoopReverse swoopActive" );

            if ( left && settings.randomColors ) {
                $dotsSelelector.css( { "background-color": randomColor() } );
            }

            var movingDots = Math.floor( ( settings.percent / 100 ) * settings.numDots );

            if ( !movingDots )
            {
                movingDots = 1;
            }

            for (var i = 0; i < settings.numDots; i++) {
                moveDot( i );
            }

            function moveDot ( i ) {
                var dot = dots[i];
                var percent = dot.data("pos");

                //setting initial state
                
                if ( ( left && settings.progress ) || !settings.progress )
                {
                    dot.css({                                       
                        left: (left ? "-100" : percent) + "%"
                    });    
                }
                
                var timerPause;
                if ( settings.progress && left )
                {
                    timerPause = i * settings.swoopPause;
                }
                else
                {
                    timerPause = ( (settings.progress?movingDots:settings.numDots) - i) * settings.swoopPause;
                }

                if ( i >= movingDots && settings.progress )
                    return false;

                timer = setTimeout(function (dot, $sel) {
                    if ( !running )
                        return false;

                    $sel.addClass(addClass);

                    //final state
                    dot.css({
                        left: (left ? dot.data("pos") : "200") + "%"
                    });

                }, timerPause, dots[i], $dotsSelelector );
            }

            var $transitionEndSelector;

            if ( settings.progress && left )
            {
                $transitionEndSelector = dots[movingDots-1];
            }
            else
            {
                $transitionEndSelector = $dotsSelelector.first();
            }

            $transitionEndSelector.bind( "transitionend", function () {
                
                $(this).unbind();
                swoop(!left);
            
            });

        }

        function randomColor() {
            return '#'+Math.floor(Math.random()*16777215).toString(16);
        }

        createDots();
        swoop( settings.progress );

        return {
            stop: function () {
                running = false;
                clearInterval(timer);
            },
            start: function () {
                running = true;
                $dotsSelelector.removeClass("swoopReverse swoopActive");
                swoop( settings.progress );
            },
            setProgress: function (percent) {
                settings.percent = percent;
            }
        }
    }

}(jQuery));