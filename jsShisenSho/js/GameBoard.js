/**
 * @author andy
 */

(function ($)
{

    var GamePieceTemplate = "";
    var SSGame = function(rows, cols){};
/*
    $.fn.RowHighlight = function (options)
    {
        var sender = $(this);
        var defaults =
        {
            HighlightClass: '',
            HighlightBGColor: '',
            AltRowClass: '',
            AltRowBGColor: '',
            OffsetRows: '1'
        };

        var options = $.extend(defaults, options);

        return this.each(function ()
        {
            var HighlightClass = $.trim(options.HighlightClass);
            var HighlightBGColor = $.trim(options.HighlightBGColor);
            var AltRowClass = $.trim(options.AltRowClass);
            var AltRowBGColor = $.trim(options.AltRowBGColor);
            var OffsetRows = $.trim(options.OffsetRows);
            var PrevRow = null;

            // set up the alt row color
            if (AltRowClass != '')
            {
                sender.find("tr").not("tr:lt(" + OffsetRows + ")").filter(":odd").addClass(AltRowClass);
            }
            else if (AltRowBGColor != '')
            {
                sender.find("tr").not("tr:lt(" + OffsetRows + ")").filter(":odd").css('background-color', AltRowBGColor);
            }

            function RowHighightProcess()
            {
                var EventRow = $(this);
                if (HighlightClass != '')
                {
                    sender.closest("table").find('tr:odd').filter('.' + HighlightClass).toggleClass(HighlightClass, AltRowClass);
                    sender.closest("table").find('tr:even').filter('.' + HighlightClass).removeClass(HighlightClass);
                    EventRow.addClass(HighlightClass);
                }
                else if (HighlightBGColor != '')
                {
                    sender.closest("table").find("tr").not("tr:lt(" + OffsetRows + ")").filter(":odd").css('background-color', AltRowBGColor);
                    sender.closest("table").find("tr").not("tr:lt(" + OffsetRows + ")").filter(":even").css('background-color', "");
                    EventRow.css('background-color', HighlightBGColor);
                }
                PrevRow = EventRow;
            }

            // bind the click event to the supplied element
            sender.find('tr').not("tr:lt(" + OffsetRows + ")").bind('mouseup', RowHighightProcess);

        });
    };
    */
})(jQuery);