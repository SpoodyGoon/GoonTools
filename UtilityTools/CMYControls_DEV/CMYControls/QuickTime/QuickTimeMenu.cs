
using System;
using Gtk;

namespace CMYControls
{
	
	
	public class QuickTimeMenu: Gtk.Menu
	{
		private int[] MinuteMarks;
		public QuickTimeMenu()
		{
			MinuteMarks = new int[4]{00, 15, 30,45};
			Gtk.MenuItem mnuAM = new MenuItem("A.M.");
			mnuAM.Submenu = HourMenu("a.m.");
			this.Add(mnuAM);
			
			Gtk.MenuItem mnuPM = new MenuItem("P.M.");
			mnuPM.Submenu = HourMenu("p.m.");
			this.Add(mnuPM);
		}
		
		private Gtk.Menu HourMenu(string TimeOfDay)
		{
			Gtk.Menu mnuHour = new Gtk.Menu();
			Gtk.MenuItem mi;
			for(int i = 1; i < 13; i++)
			{
				mi = new MenuItem(i.ToString() + ":00 " + TimeOfDay);
				mi.Submenu = MinuteMenu(i, TimeOfDay);
				mnuHour.Add(mi);				
			}
			return mnuHour;
		}		
		
		
		private Gtk.Menu MinuteMenu(int Hour, string TimeOfDay)
		{
			Gtk.Menu mnuMinute = new Gtk.Menu();
			Gtk.MenuItem mi;
			for(int i = 0; i < MinuteMarks.Length; i++)
			{
				mi = new MenuItem(Hour.ToString() + ":" + MinuteMarks[i].ToString() + " " + TimeOfDay);
				mi.Activated += mnuMinute_Activated;
				mnuMinute.Add(mi);				
			}
			return mnuMinute;
		}

		private void mnuMinute_Activated(object sender, EventArgs e)
		{
			
		}
	}
}
