//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThudSharp {
    
    
    public partial class MovablePiece {
        
        private Gtk.EventBox evtPiece;
        
        private Gtk.Image imgMovable;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget ThudSharp.MovablePiece
            Stetic.BinContainer.Attach(this);
            this.Name = "ThudSharp.MovablePiece";
            // Container child ThudSharp.MovablePiece.Gtk.Container+ContainerChild
            this.evtPiece = new Gtk.EventBox();
            this.evtPiece.WidthRequest = 43;
            this.evtPiece.HeightRequest = 43;
            this.evtPiece.Name = "evtPiece";
            this.evtPiece.AboveChild = true;
            this.evtPiece.VisibleWindow = false;
            this.evtPiece.BorderWidth = ((uint)(2));
            // Container child evtPiece.Gtk.Container+ContainerChild
            this.imgMovable = new Gtk.Image();
            this.imgMovable.WidthRequest = 45;
            this.imgMovable.HeightRequest = 45;
            this.imgMovable.Events = ((Gdk.EventMask)(790526));
            this.imgMovable.Name = "imgMovable";
            this.imgMovable.Xpad = 2;
            this.imgMovable.Ypad = 2;
            this.evtPiece.Add(this.imgMovable);
            this.Add(this.evtPiece);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
            this.evtPiece.ButtonPressEvent += new Gtk.ButtonPressEventHandler(this.OnEvtPieceButtonPressEvent);
            this.evtPiece.ButtonReleaseEvent += new Gtk.ButtonReleaseEventHandler(this.OnEvtPieceButtonReleaseEvent);
            this.evtPiece.ExposeEvent += new Gtk.ExposeEventHandler(this.OnEvtPieceExposeEvent);
            this.evtPiece.EnterNotifyEvent += new Gtk.EnterNotifyEventHandler(this.OnEvtPieceEnterNotifyEvent);
        }
    }
}
