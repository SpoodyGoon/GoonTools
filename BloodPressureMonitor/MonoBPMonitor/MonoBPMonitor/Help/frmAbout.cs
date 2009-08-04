//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Gtk;


namespace MonoBPMonitor
{
	
	
	public partial class frmAbout : Gtk.Dialog
	{
		
		public frmAbout()
		{
			this.Build();
			// TODO: dont for get to aligned the header lables
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly ();
			System.Version v = asm. GetName().Version;
			DateTime t = new DateTime(v.Build * TimeSpan.TicksPerDay +	v.Revision * TimeSpan.TicksPerSecond * 2).AddYears(1999);
			lblBuildDate.Text = t.ToShortDateString();
			lblVersion.Text = v.ToString();
			label8.Text = "<span foreground=\"#990000\" underline=\"single\">" + System.Configuration.ConfigurationManager.AppSettings["AppHomePage"].ToString() + "</span>";
			label8.UseMarkup = true;
			AddPage("License");
			this.ShowAll();
			
		}
		
		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
		
		private void AddPage(string PageName)
		{
			Gtk.TextIter insertIter;
			Gtk.ScrolledWindow sw = new Gtk.ScrolledWindow();
			sw.Name = "sw" + PageName.Replace(" ", "");
			sw.BorderWidth = 7;
			sw.ShadowType = ShadowType.In;
			Gtk.TextView tv = new Gtk.TextView();
			tv.Name = "tv" + PageName.Replace(" ", "");
			tv.WrapMode = WrapMode.Word;
			tv.Editable = false;
			tv.LeftMargin = 10;
			tv.RightMargin = 4;
			GoonTools.BufferTags.GetBufferTags(tv.Buffer);
			switch(PageName)
			{
				case "License":
					insertIter = tv.Buffer.StartIter;
					tv.Buffer.InsertWithTagsByName(ref insertIter, "\nGNU GENERAL PUBLIC LICENSE\n\nVersion 3, 29 June 2007", "sub_heading", "center");
					tv.Buffer.InsertWithTagsByName(ref insertIter, GoonTools.Const.License, "monospace");
					break;
				case "Credit":
//					WriteCredit(tv.Buffer);
//					LinkButton lbnHolly = new LinkButton("http://code.google.com/p/holly-gtk-widgets/","http://code.google.com/p/holly-gtk-widgets/");
//					lbnHolly.Clicked += delegate { System.Diagnostics.Process.Start(@"http://code.google.com/p/holly-gtk-widgets/"); };
//					tv.AddChildAtAnchor(lbnHolly, achHollyLink);
//					LinkButton lbnGoon = new LinkButton("http://code.google.com/p/goontools/","http://code.google.com/p/goontools/");
//					lbnGoon.Clicked += delegate { System.Diagnostics.Process.Start(@"http://code.google.com/p/goontools/"); };
//					tv.AddChildAtAnchor(lbnGoon,achGoonToolsLink);
					break;
				case "Description":
//					WriteDescription(tv.Buffer);
					break;
				case "Known Issues":
//					WriteKnownIssues(tv.Buffer);
					break;
				case "Change Log":
//					WriteChangeLog(tv.Buffer);
					break;
				default:
					break;
			}
			sw.Add(tv);
			nbkAbout.AppendPage((Gtk.Widget)sw, new Gtk.Label(PageName));
			
		}
	}
}
