
// This file has been generated by the GUI designer. Do not modify.
namespace SQLiteMonoPlusEditor
{
	public partial class SQLTextEditor
	{
		private global::Gtk.Alignment alignment2;
		private global::Gtk.VPaned vpaned1;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::SQLiteMonoPlusEditor.SQLEditor.SQLEditorView sqleditorview1;
		private global::Gtk.Alignment alignment3;
		private global::Gtk.Notebook notebook2;
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		private global::Gtk.TreeView tvResults;
		private global::Gtk.Label label4;
		private global::Gtk.Label label2;
		private global::Gtk.Label label3;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget SQLiteMonoPlusEditor.SQLTextEditor
			global::Stetic.BinContainer.Attach (this);
			this.CanDefault = true;
			this.CanFocus = true;
			this.ExtensionEvents = ((global::Gdk.ExtensionMode)(1));
			this.Name = "SQLiteMonoPlusEditor.SQLTextEditor";
			// Container child SQLiteMonoPlusEditor.SQLTextEditor.Gtk.Container+ContainerChild
			this.alignment2 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			// Container child alignment2.Gtk.Container+ContainerChild
			this.vpaned1 = new global::Gtk.VPaned ();
			this.vpaned1.CanFocus = true;
			this.vpaned1.Name = "vpaned1";
			this.vpaned1.Position = 375;
			// Container child vpaned1.Gtk.Paned+PanedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.sqleditorview1 = new global::SQLiteMonoPlusEditor.SQLEditor.SQLEditorView ();
			this.sqleditorview1.CanFocus = true;
			this.sqleditorview1.Name = "sqleditorview1";
			this.GtkScrolledWindow.Add (this.sqleditorview1);
			this.vpaned1.Add (this.GtkScrolledWindow);
			global::Gtk.Paned.PanedChild w2 = ((global::Gtk.Paned.PanedChild)(this.vpaned1 [this.GtkScrolledWindow]));
			w2.Resize = false;
			// Container child vpaned1.Gtk.Paned+PanedChild
			this.alignment3 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment3.Name = "alignment3";
			// Container child alignment3.Gtk.Container+ContainerChild
			this.notebook2 = new global::Gtk.Notebook ();
			this.notebook2.CanFocus = true;
			this.notebook2.Name = "notebook2";
			this.notebook2.CurrentPage = 0;
			// Container child notebook2.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.tvResults = new global::Gtk.TreeView ();
			this.tvResults.CanFocus = true;
			this.tvResults.Name = "tvResults";
			this.tvResults.RulesHint = true;
			this.GtkScrolledWindow1.Add (this.tvResults);
			this.notebook2.Add (this.GtkScrolledWindow1);
			// Notebook tab
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xpad = 4;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Results");
			this.notebook2.SetTabLabel (this.GtkScrolledWindow1, this.label4);
			this.label4.ShowAll ();
			// Notebook tab
			global::Gtk.Label w5 = new global::Gtk.Label ();
			w5.Visible = true;
			this.notebook2.Add (w5);
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xpad = 4;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Messages");
			this.notebook2.SetTabLabel (w5, this.label2);
			this.label2.ShowAll ();
			// Notebook tab
			global::Gtk.Label w6 = new global::Gtk.Label ();
			w6.Visible = true;
			this.notebook2.Add (w6);
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xpad = 4;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Execution Plan");
			this.notebook2.SetTabLabel (w6, this.label3);
			this.label3.ShowAll ();
			this.alignment3.Add (this.notebook2);
			this.vpaned1.Add (this.alignment3);
			this.alignment2.Add (this.vpaned1);
			this.Add (this.alignment2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Show ();
		}
	}
}