var ajaxRequestsCounter = 0;
function OnGridErrorHandler(e) {
    HideLoader();
    if (e.textStatus == "parsererror") {
        //location.href = "/Account/LogOn";
    }
    else if (e.errors) {
        var errMsg = [];
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    errMsg[errMsg.length] = this + "\n";

                });
            }
        });

        if (errMsg.length > 0) {
            alert(errMsg.join('\n'));
        }
        this.cancelChanges();
    }
    e.preventDefault();
}

function OnLookupErrorHandler(e) {
    if (e.textStatus == "parseeror") {
        location.href = "/Account/LogOn";
    }
    e.preventDefault();
}

function collapseMVCGroupedGrids(e) {
    var grid = e.sender;
    grid.tbody.find('>tr.k-grouping-row').each(
        function (e) {
            grid.collapseRow(this);
        });
}

function shortLabels(value) {
    if (value != null && value.length > 15) {
        value = value.substring(0, 15) + "...";
    }
    return value;
}

function ShowChars(value, Num) {
    if (value != null && value.length > Num) {
        value = value.substring(0, Num);
    }
    return value;
}

function Desc_Databound(Desc, NoChars) {
    if (NoChars === undefined) {
        NoChars = 10;
    }
    if (Desc == null)
        return "";
    return Desc;
    var DescString = Desc;
    if (DescString.length > NoChars)
        DescString = DescString.substring(0, NoChars) + "...";

    window.setTimeout(BindToolTips, 500);
    return '<div class="tiptip" title="' + Desc + '">' + DescString + '</div>';
}

function ShowLoader() {
    $("body").addClass("loading");
}

function HideLoader() {
    $("body").removeClass("loading");
}

function HideAnim() {
    $("#canvasloader-container").hide();
}

function ShowTrialMsg() {
    //$("#trialloader-container").overlay().load();
    //$("#trialloader-container").show();

    $("#dvMask").show();

}

function HideTrialMsg() {
    //$("#trialloader-container").overlay().close();
    //$("#trialloader-container").hide();
    $("#dvMask").hide();
}

function ChangeDesign(ID) {
    $.post("/home/ChangeDesign", { IsNew: ID }, function (d) {
        location.href = "/";
    });
}

$(document).ready(function () {

});

$(document).ajaxComplete(function (event, request, settings) {
    if (request.responseText.indexOf('Login.aspx') > 0)
        location.href = '/Account/Logon';
});

function BindToolTips() {
    $('div.tiptip').tipTip();
}


function OpenSlidingPopup(UrlTOOpen, paramsData) {
    $(".ha-underlay").removeClass("hide").addClass("show");
    $("#ha-drawer").removeClass("slide-in").addClass("show");
    $(".drawer-panel").remove();

    $.post(UrlTOOpen, paramsData, function (d) {
        $("#ha-drawer").html(d).delay(100).queue(function () {
            $(this).addClass("slide-in").dequeue();
        });
    });
}

function CloseSlidingPopup(callback) {
    $("#ha-drawer").removeClass("slide-in").delay(100).queue(function () {
        $(".ha-underlay").removeClass("show").addClass("hide");
        $(".drawer-panel").remove();
        $(this).removeClass("show").addClass("hide").dequeue();
    });

    if (typeof callback == "function")
        callback();
}

function RegisterSlidingPopupEvents(onCloseCall) {
    $("#ha-drawer").on('click', '.rt-top-action-btn', function (e) {
        CloseSlidingPopup(onCloseCall);
    });
}

function ApplyAutoDecimal(tbID) {
    var exVal = $("#" + tbID).val();
    if (exVal.length > 0) {
        exVal = exVal + '';
        exVal = exVal.replace(".", "");
    }
    if (exVal.length > 0) {
        var newVal = "";
        var cVal = parseFloat(exVal);
        exVal = cVal + '';
        if (exVal.length <= 2) {
            switch (exVal.length) {
                case 1:
                    newVal = "0.0" + exVal;
                    break;
                case 2:
                    newVal = "0." + exVal;
                    break;
            }

        }
        else {
            var leftPart = exVal.substring(0, exVal.length - 2);
            var rightPart = exVal.substring(exVal.length - 2);

            newVal = leftPart + "." + rightPart;
        }

        $("#" + tbID).val(newVal);
    }
}

function AllowNumericsOnly(event) {
    // Allow: backspace, delete, tab, escape, enter, dot(110, 190), minus(109, 173, 189)
    if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 || event.keyCode == 110 || event.keyCode == 190 || event.keyCode == 109 || event.keyCode == 173 || event.keyCode == 189 ||
        // Allow: Ctrl+A
        (event.keyCode == 65 && event.ctrlKey === true) ||
        // Allow: home, end, left, right
        (event.keyCode >= 35 && event.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    else {
        // Ensure that it is a number and stop the keypress
        if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
            event.preventDefault();
        }
    }
}

function AllowAccountDigits(event) {
    // Allow: backspace, delete, tab, escape, enter, dot(110, 190), minus(109, 173, 189), plus (43, 78, 107)
    if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 || event.keyCode == 110 || event.keyCode == 190 || event.keyCode == 109 || event.keyCode == 173 || event.keyCode == 189 || event.keyCode == 43 || event.keyCode == 78 || event.keyCode == 107 ||
        // Allow: Ctrl+A
        (event.keyCode == 65 && event.ctrlKey === true) ||
        // Allow: home, end, left, right
        (event.keyCode >= 35 && event.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    else {
        // Ensure that it is a number or plus sign and stop the keypress
        if (event.shiftKey && (event.keyCode == 61 || event.keyCode == 187))
            return;
        if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
            event.preventDefault();
        }
    }
}

function AllowDigitsnDivide(event) {
    // Allow: backspace, delete, tab, escape, enter, dot(110, 190), minus(109, 173, 189), plus (43, 78, 107)
    if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 || event.keyCode == 110 || event.keyCode == 190 || event.keyCode == 109 || event.keyCode == 173 || event.keyCode == 189 || event.keyCode == 111 || event.keyCode == 191 ||
        // Allow: Ctrl+A
        (event.keyCode == 65 && event.ctrlKey === true) ||
        // Allow: home, end, left, right
        (event.keyCode >= 35 && event.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    else {
        // Ensure that it is a number and stop the keypress
        if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
            event.preventDefault();
        }
    }
}

function AllowPositiveDigits(event) {
    // Allow: backspace, delete, tab, escape, enter, dot(110, 190), minus(109, 173, 189), plus (43, 78, 107)
    if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
        // Allow: Ctrl+A
        (event.keyCode == 65 && event.ctrlKey === true) ||
        // Allow: home, end, left, right
        (event.keyCode >= 35 && event.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    else {
        // Ensure that it is a number and stop the keypress
        if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
            event.preventDefault();
        }
    }
}
function evalMath(s) {

    var total = 0, s = s.match(/[+\-]*(\.\d+|\d+(\.\d+)?)/g) || [];
    while (s.length) {
        total += parseFloat(s.shift());
    }
    return isNaN(total) ? 0 : total;
}

function getNumberWithDecimals(num) {
    return (num).toString().replace(/(\.\d{1,2})\d*$/, "$1");
}

function GetDecimalValDigits(value, roundOff) {
    if (value == null)
        return "0";

    return value.toFixed(roundOff);
}

(function ($, document, undefined) {

    var pluses = /\+/g;

    function raw(s) {
        return s;
    }

    function decoded(s) {
        return decodeURIComponent(s.replace(pluses, ' '));
    }

    var config = $.cookie = function (key, value, options) {

        // write
        if (value !== undefined) {
            options = $.extend({}, config.defaults, options);

            if (value === null) {
                options.expires = -1;
            }

            if (typeof options.expires === 'number') {
                var days = options.expires, t = options.expires = new Date();
                t.setDate(t.getDate() + days);
            }

            value = config.json ? JSON.stringify(value) : String(value);

            return (document.cookie = [
                encodeURIComponent(key), '=', config.raw ? value : encodeURIComponent(value),
                options.expires ? '; expires=' + options.expires.toUTCString() : '', // use expires attribute, max-age is not supported by IE
                options.path ? '; path=' + options.path : '',
                options.domain ? '; domain=' + options.domain : '',
                options.secure ? '; secure' : ''
            ].join(''));
        }

        // read
        var decode = config.raw ? raw : decoded;
        var cookies = document.cookie.split('; ');
        for (var i = 0, parts; (parts = cookies[i] && cookies[i].split('=')); i++) {
            if (decode(parts.shift()) === key) {
                var cookie = decode(parts.join('='));
                return config.json ? JSON.parse(cookie) : cookie;
            }
        }

        return null;
    };

    config.defaults = {};

    $.removeCookie = function (key, options) {
        if ($.cookie(key) !== null) {
            $.cookie(key, null, options);
            return true;
        }
        return false;
    };

})(jQuery, document);