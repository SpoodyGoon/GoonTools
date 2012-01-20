/// <summary>
/// This is a function that can be bound to an element
/// or calls by proxy to check all the checkboxes based
/// off the arguments passed in
/// </summary>
(function($)
{
    $.fn.CheckAll = function(options)
    {
        var sender = $(this);
        var defaults =
        {
            ParentID : '',
            CheckGroup : '',
            CustomSelector : '',
            Checked : ''
        };

        var options = $.extend(defaults, options);

        return this.each(function()
        {
            var ParentID = $.trim(options.ParentID);
            var CustomSelector = $.trim(options.CustomSelector);
            var CheckGroup = $.trim(options.CheckGroup);
			var CheckedOverride = $.trim(options.Checked);

			function CheckAllProcess()
			{		
				var Checked = false;				
				// logic to determing the state we want to set the checkboxes to
				if(CheckedOverride != '')
				{
					if(CheckedOverride == 'true')
					{
						Checked = true;
					}
				}
				else
				{
					if(sender.is(":checkbox") && sender.is(":checked"))
					{
						Checked = true;
					}
				}
				
				// Construct the selector string from the options passed in
				// If a custom selector is passed in then just use it
				// reguardless of what it is
				if(CustomSelector != '')
				{
					$(CustomSelector).attr("checked", Checked);
				}
				else
				{
					if(ParentID != '' && CheckGroup != '')
					{
						$("#" + ParentID + " :checkbox").filter('[CheckGroup="' + CheckGroup + '"]').attr("checked", Checked);
					}
					else if(ParentID != '')
					{
						$("#" + ParentID + " :checkbox").attr("checked", Checked);
					}
					else if(CheckGroup != '')
					{
						$(":checkbox").filter('[CheckGroup="' + CheckGroup + '"]').attr("checked", Checked);
					}
					else
					{
						$(":checkbox").attr("checked", Checked);
					}
				}
			}
			
			// bind the click event to the supplied element
			sender.bind('click', function()
			{
				CheckAllProcess();
			});
			
        });
    };
})(jQuery);
