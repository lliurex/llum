
// This file has been generated by the GUI designer. Do not modify.
namespace llum
{
	public partial class AddGroupWidget
	{
		private global::Gtk.Frame frame1;
		
		private global::Gtk.Alignment GtkAlignment;
		
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Image image11;
		
		private global::Gtk.Image image12;
		
		private global::Gtk.Label newLabel;
		
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Entry nameEntry;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Entry descriptionEntry;
		
		private global::Gtk.HSeparator hseparator1;
		
		private global::Gtk.HBox hbox5;
		
		private global::Gtk.Button acceptButton;
		
		private global::Gtk.Button undoButton;
		
		private global::Gtk.Label msgLabel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget llum.AddGroupWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "llum.AddGroupWidget";
			// Container child llum.AddGroupWidget.Gtk.Container+ContainerChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(2));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(6));
			this.GtkAlignment.TopPadding = ((uint)(6));
			this.GtkAlignment.RightPadding = ((uint)(6));
			this.GtkAlignment.BottomPadding = ((uint)(6));
			this.GtkAlignment.BorderWidth = ((uint)(6));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.image11 = new global::Gtk.Image ();
			this.image11.Name = "image11";
			this.image11.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "folder-public", global::Gtk.IconSize.Dialog);
			this.hbox1.Add (this.image11);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.image11]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.image12 = new global::Gtk.Image ();
			this.image12.Name = "image12";
			this.image12.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			this.hbox1.Add (this.image12);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.image12]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.newLabel = new global::Gtk.Label ();
			this.newLabel.Name = "newLabel";
			this.newLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Add group");
			this.hbox1.Add (this.newLabel);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.newLabel]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.WidthRequest = 100;
			this.label2.Name = "label2";
			this.label2.Xalign = 0F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Name");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label2]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.nameEntry = new global::Gtk.Entry ();
			this.nameEntry.CanFocus = true;
			this.nameEntry.Name = "nameEntry";
			this.nameEntry.IsEditable = true;
			this.nameEntry.InvisibleChar = '●';
			this.hbox2.Add (this.nameEntry);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.nameEntry]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox1.Add (this.hbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.WidthRequest = 100;
			this.label3.Name = "label3";
			this.label3.Xalign = 0F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Description");
			this.hbox3.Add (this.label3);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label3]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.descriptionEntry = new global::Gtk.Entry ();
			this.descriptionEntry.CanFocus = true;
			this.descriptionEntry.Name = "descriptionEntry";
			this.descriptionEntry.IsEditable = true;
			this.descriptionEntry.InvisibleChar = '●';
			this.hbox3.Add (this.descriptionEntry);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.descriptionEntry]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.vbox1.Add (this.hbox3);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox3]));
			w10.Position = 2;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.vbox1.Add (this.hseparator1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hseparator1]));
			w11.Position = 3;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 60;
			this.hbox5.BorderWidth = ((uint)(6));
			// Container child hbox5.Gtk.Box+BoxChild
			this.acceptButton = new global::Gtk.Button ();
			this.acceptButton.CanFocus = true;
			this.acceptButton.Name = "acceptButton";
			this.acceptButton.UseStock = true;
			this.acceptButton.UseUnderline = true;
			this.acceptButton.Label = "gtk-ok";
			this.hbox5.Add (this.acceptButton);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.acceptButton]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.undoButton = new global::Gtk.Button ();
			this.undoButton.CanFocus = true;
			this.undoButton.Name = "undoButton";
			this.undoButton.UseStock = true;
			this.undoButton.UseUnderline = true;
			this.undoButton.Label = "gtk-undo";
			this.hbox5.Add (this.undoButton);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.undoButton]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			this.vbox1.Add (this.hbox5);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox5]));
			w14.Position = 4;
			w14.Expand = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.msgLabel = new global::Gtk.Label ();
			this.msgLabel.Name = "msgLabel";
			this.vbox1.Add (this.msgLabel);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.msgLabel]));
			w15.PackType = ((global::Gtk.PackType)(1));
			w15.Position = 5;
			w15.Expand = false;
			w15.Fill = false;
			this.GtkAlignment.Add (this.vbox1);
			this.frame1.Add (this.GtkAlignment);
			this.Add (this.frame1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.nameEntry.Changed += new global::System.EventHandler (this.OnNameEntryChanged);
			this.descriptionEntry.Changed += new global::System.EventHandler (this.OnDescriptionEntryChanged);
			this.acceptButton.Clicked += new global::System.EventHandler (this.OnAcceptButtonClicked);
			this.undoButton.Clicked += new global::System.EventHandler (this.OnUndoButtonClicked);
		}
	}
}
