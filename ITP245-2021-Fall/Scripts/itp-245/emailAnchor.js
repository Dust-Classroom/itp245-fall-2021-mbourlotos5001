﻿$(function () {
    var interval = 10;
    var duration = 1000;
    var shake = 3;
    var vibrateIndex = 0;
    var selector = $('.email'); /* Your own container ID*/
    $(selector).hover( /* The button ID */
        function () {
            vibrateIndex = setInterval(vibrate, interval);
        },
        function () {
            clearInterval(vibrateIndex);
            $(selector).stop(true, false)
                .css({ position: 'static', left: '0px', top: '0px' });
        }
    );

    var vibrate = function () {
        $(selector).stop(true, false)
            .css({
                position: 'relative',
                left: Math.round(Math.random() * shake) - ((shake + 1) / 2) + 'px',
                top: Math.round(Math.random() * shake) - ((shake + 1) / 2) + 'px'
            });
    }
});