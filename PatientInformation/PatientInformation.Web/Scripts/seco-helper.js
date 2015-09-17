/*
 * Array extention method for element removing.
 */
Array.prototype.remove = function () {
    var what, a = arguments, L = a.length, ax;
    while (L && this.length) {
        what = a[--L];
        while ((ax = this.indexOf(what)) !== -1) {
            this.splice(ax, 1);
        }
    }
    return this;
};

/**
 * Returns a random number between min (inclusive) and max (exclusive)
 */
function getRandomArbitrary(min, max) {
    return Math.random() * (max - min) + min;
}

/**
 * Returns a random integer between min (inclusive) and max (inclusive)
 * Using Math.round() will give you a non-uniform distribution!
 */
function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

/*
 * If there is no indexOf func (for IE8), create it manually.
 */
if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function (elt /*, from*/) {
        var len = this.length >>> 0;
        var from = Number(arguments[1]) || 0;
        from = (from < 0)
             ? Math.ceil(from)
             : Math.floor(from);
        if (from < 0)
            from += len;
        for (; from < len; from++) {
            if (from in this &&
                this[from] === elt)
                return from;
        }
        return -1;
    };
}

/*
 * jQuery plugin for detecting position in a relative manor
 */
(function ($) {
    $.fn.offsetRelative = function (top) {
        var $this = $(this);
        var $parent = $this.offsetParent();
        var offset = $this.position();
        if (!top) return offset; // Didn't pass a 'top' element 
        else if ($parent.get(0).tagName == "BODY") return offset; // Reached top of document
        else if ($(top, $parent).length) return offset; // Parent element contains the 'top' element we want the offset to be relative to 
        else if ($parent[0] == $(top)[0]) return offset; // Reached the 'top' element we want the offset to be relative to 
        else { // Get parent's relative offset
            var parent_offset = $parent.offsetRelative(top);
            offset.top += parent_offset.top;
            offset.left += parent_offset.left;
            return offset;
        }
    };
    $.fn.positionRelative = function (top) {
        return $(this).offsetRelative(top);
    };
}(jQuery));