// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoBPMonitor {
    
    
    public partial class frmCalendar {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment;
        
        private Gtk.VBox vbox3;
        
        private Gtk.Calendar calendar2;
        
        private Gtk.Alignment algTime;
        
        private Gtk.Frame frame2;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.Label label1;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.SpinButton spnHour;
        
        private Gtk.Alignment alignment5;
        
        private Gtk.Label label2;
        
        private Gtk.Alignment alignment6;
        
        private Gtk.SpinButton spnMinute;
        
        private Gtk.Alignment alignment8;
        
        private Gtk.RadioButton rbnPM;
        
        private Gtk.Alignment alignment7;
        
        private Gtk.RadioButton rbnAM;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.EventBox evntDateTimeNow;
        
        private Gtk.Label lblNow;
        
        private Gtk.Button buttonCancel;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoBPMonitor.frmCalendar
            this.WidthRequest = 350;
            this.Name = "MonoBPMonitor.frmCalendar";
            this.Icon = Gdk.Pixbuf.LoadFromResource("date.png");
            this.TypeHint = ((Gdk.WindowTypeHint)(1));
            this.WindowPosition = ((Gtk.WindowPosition)(2));
            this.Modal = true;
            this.BorderWidth = ((uint)(2));
            this.Resizable = false;
            this.AllowGrow = false;
            this.DestroyWithParent = true;
            // Internal child MonoBPMonitor.frmCalendar.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.ShadowType = ((Gtk.ShadowType)(1));
            this.frame1.LabelYalign = 0F;
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment.Name = "GtkAlignment";
            this.GtkAlignment.LeftPadding = ((uint)(2));
            this.GtkAlignment.TopPadding = ((uint)(2));
            this.GtkAlignment.RightPadding = ((uint)(2));
            this.GtkAlignment.BottomPadding = ((uint)(2));
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.calendar2 = new Gtk.Calendar();
            this.calendar2.CanFocus = true;
            this.calendar2.Name = "calendar2";
            this.calendar2.DisplayOptions = ((Gtk.CalendarDisplayOptions)(35));
            this.vbox3.Add(this.calendar2);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox3[this.calendar2]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            this.GtkAlignment.Add(this.vbox3);
            this.frame1.Add(this.GtkAlignment);
            this.vbox2.Add(this.frame1);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox2[this.frame1]));
            w5.Position = 0;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.algTime = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.algTime.Name = "algTime";
            // Container child algTime.Gtk.Container+ContainerChild
            this.frame2 = new Gtk.Frame();
            this.frame2.Name = "frame2";
            // Container child frame2.Gtk.Container+ContainerChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 0.5F, 0.5F);
            this.alignment2.LeftPadding = ((uint)(10));
            this.alignment2.TopPadding = ((uint)(4));
            this.alignment2.RightPadding = ((uint)(5));
            this.alignment2.BottomPadding = ((uint)(4));
            // Container child alignment2.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Hour:");
            this.alignment3.Add(this.label1);
            this.hbox1.Add(this.alignment3);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment3]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.spnHour = new Gtk.SpinButton(1, 12, 1);
            this.spnHour.CanFocus = true;
            this.spnHour.Name = "spnHour";
            this.spnHour.Adjustment.PageIncrement = 10;
            this.spnHour.ClimbRate = 1;
            this.spnHour.Numeric = true;
            this.spnHour.SnapToTicks = true;
            this.spnHour.Value = 8;
            this.alignment4.Add(this.spnHour);
            this.hbox1.Add(this.alignment4);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment4]));
            w9.Position = 1;
            w9.Expand = false;
            w9.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment5 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment5.Name = "alignment5";
            // Container child alignment5.Gtk.Container+ContainerChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Minute:");
            this.alignment5.Add(this.label2);
            this.hbox1.Add(this.alignment5);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment5]));
            w11.Position = 2;
            w11.Expand = false;
            w11.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment6 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment6.Name = "alignment6";
            // Container child alignment6.Gtk.Container+ContainerChild
            this.spnMinute = new Gtk.SpinButton(0, 60, 5);
            this.spnMinute.CanFocus = true;
            this.spnMinute.Name = "spnMinute";
            this.spnMinute.Adjustment.PageIncrement = 10;
            this.spnMinute.ClimbRate = 5;
            this.spnMinute.Numeric = true;
            this.spnMinute.SnapToTicks = true;
            this.spnMinute.Value = 30;
            this.alignment6.Add(this.spnMinute);
            this.hbox1.Add(this.alignment6);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment6]));
            w13.Position = 3;
            w13.Expand = false;
            w13.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment8 = new Gtk.Alignment(0.01F, 0.5F, 0.01F, 1F);
            this.alignment8.Name = "alignment8";
            // Container child alignment8.Gtk.Container+ContainerChild
            this.rbnPM = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("p.m."));
            this.rbnPM.CanFocus = true;
            this.rbnPM.Name = "rbnPM";
            this.rbnPM.DrawIndicator = true;
            this.rbnPM.UseUnderline = true;
            this.rbnPM.Group = new GLib.SList(System.IntPtr.Zero);
            this.alignment8.Add(this.rbnPM);
            this.hbox1.Add(this.alignment8);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment8]));
            w15.PackType = ((Gtk.PackType)(1));
            w15.Position = 4;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment7 = new Gtk.Alignment(0.01F, 0.5F, 0.01F, 1F);
            this.alignment7.Name = "alignment7";
            // Container child alignment7.Gtk.Container+ContainerChild
            this.rbnAM = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("a.m."));
            this.rbnAM.CanFocus = true;
            this.rbnAM.Name = "rbnAM";
            this.rbnAM.DrawIndicator = true;
            this.rbnAM.UseUnderline = true;
            this.rbnAM.Group = this.rbnPM.Group;
            this.alignment7.Add(this.rbnAM);
            this.hbox1.Add(this.alignment7);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment7]));
            w17.PackType = ((Gtk.PackType)(1));
            w17.Position = 5;
            w17.Expand = false;
            w17.Fill = false;
            this.alignment2.Add(this.hbox1);
            this.frame2.Add(this.alignment2);
            this.algTime.Add(this.frame2);
            this.vbox2.Add(this.algTime);
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.vbox2[this.algTime]));
            w21.Position = 1;
            w21.Expand = false;
            w21.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.TopPadding = ((uint)(2));
            this.alignment1.BottomPadding = ((uint)(4));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.evntDateTimeNow = new Gtk.EventBox();
            this.evntDateTimeNow.Name = "evntDateTimeNow";
            this.evntDateTimeNow.AboveChild = true;
            // Container child evntDateTimeNow.Gtk.Container+ContainerChild
            this.lblNow = new Gtk.Label();
            this.lblNow.Name = "lblNow";
            this.lblNow.LabelProp = Mono.Unix.Catalog.GetString("<span size=\"8750\" face=\"san serif\" color=\"#000000\"><u><b>Set Date &#38; Time to Now.</b></u></span>");
            this.lblNow.UseMarkup = true;
            this.evntDateTimeNow.Add(this.lblNow);
            this.alignment1.Add(this.evntDateTimeNow);
            this.vbox2.Add(this.alignment1);
            Gtk.Box.BoxChild w24 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment1]));
            w24.Position = 2;
            w24.Expand = false;
            w24.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w25 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w25.Position = 0;
            w25.Expand = false;
            w25.Fill = false;
            // Internal child MonoBPMonitor.frmCalendar.ActionArea
            Gtk.HButtonBox w26 = this.ActionArea;
            w26.Name = "dialog1_ActionArea";
            w26.Spacing = 6;
            w26.BorderWidth = ((uint)(5));
            w26.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w27 = ((Gtk.ButtonBox.ButtonBoxChild)(w26[this.buttonCancel]));
            w27.Expand = false;
            w27.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w28 = ((Gtk.ButtonBox.ButtonBoxChild)(w26[this.buttonOk]));
            w28.Position = 1;
            w28.Expand = false;
            w28.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 354;
            this.DefaultHeight = 315;
            this.Show();
            this.calendar2.DaySelectedDoubleClick += new System.EventHandler(this.OnCalendar2DaySelectedDoubleClick);
            this.evntDateTimeNow.EnterNotifyEvent += new Gtk.EnterNotifyEventHandler(this.OnEvntDateTimeNowEnterNotifyEvent);
            this.evntDateTimeNow.LeaveNotifyEvent += new Gtk.LeaveNotifyEventHandler(this.OnEvntDateTimeNowLeaveNotifyEvent);
            this.evntDateTimeNow.ButtonPressEvent += new Gtk.ButtonPressEventHandler(this.OnEvntDateTimeNowButtonPressEvent);
            this.buttonCancel.Clicked += new System.EventHandler(this.OnButtonCancelClicked);
            this.buttonOk.Clicked += new System.EventHandler(this.OnButtonOkClicked);
        }
    }
}
