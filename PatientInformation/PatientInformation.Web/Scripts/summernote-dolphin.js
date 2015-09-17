(function (factory) {
    /* global define */
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define(['jquery'], factory);
    } else {
        // Browser globals: jQuery
        factory(window.jQuery);
    }
}(function ($) {

    // template
    var tmpl = $.summernote.renderer.getTemplate();
  
    /**
     * @class plugin.hello 
     * 
     * Hello Plugin  
     */
    $.summernote.addPlugin({
        /** @property {String} name name of plugin */
        name: 'media',
        name: 'h',
        /** 
         * @property {Object} buttons 
         * @property {Function} buttons.hello   function to make button
         * @property {Function} buttons.helloDropdown   function to make button
         * @property {Function} buttons.helloImage   function to make button
         */
        buttons: { // buttons
            media: function () {

                return tmpl.iconButton('fa fa-picture-o', {
                    event: 'media',
                    title: 'Insert media image',
                    hide: true
                });
            },
            h: function () {
                return tmpl.iconButton('fa fa-header', {
                    event: 'h',
                    title: 'Title',
                    hide: true
                });
            }
        },

        /**
         * @property {Object} events 
         * @property {Function} events.hello  run function when button that has a 'hello' event name  fires click
         * @property {Function} events.helloDropdown run function when button that has a 'helloDropdown' event name  fires click
         * @property {Function} events.helloImage run function when button that has a 'helloImage' event name  fires click
         */
        events: { // events
            media: function (event, editor, layoutInfo) {
                // Get current editable node
                var $editable = layoutInfo.editable();
                //console.log('editable', $.summernote.core.dom.isEditable($editable));
                $('#modalx').modal('show');

                $('#modalx').off('imageSelected').on('imageSelected', function (e, url) {
                    var img = $('<img src="' + url + '" />');
                    editor.insertNode($editable, img[0]);
                });
            },
            h: function (event, editor, layoutInfo) {
                var $editable = layoutInfo.editable();
                editor.formatBlock($editable, 'H4');
            }
        }
    });

}));
