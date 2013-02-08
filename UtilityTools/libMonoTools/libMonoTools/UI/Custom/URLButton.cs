using System;

namespace libMonoTools.UI.Custom
{
	[System.ComponentModel.ToolboxItem(true)]
	public class URLButton : libMonoTools.UI.Custom.LabelButton
	{
		public URLButton ()
		{
            //Build();
			this.ShowAll();
        } 

        public URLButton (string text, string url) 
        {
            //_Text = text;
            //_URL = url;
           // Build();
            this.ShowAll();
        }
        
        
//        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
//        [System.ComponentModel.Category("Normal Font Format")]
//        [System.ComponentModel.DefaultValue("#AD0000")]
//        [System.ComponentModel.Description("Normal Color of the Font")]
//        [System.ComponentModel.Browsable(true)]
//        public override string FontMarkup {
//            get {
//                return base.FontMarkupText;
//            }
//            set {
//                base.FontMarkupText = value;
//            }
//        }

	}
}

