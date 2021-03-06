
// This file has been generated by the GUI designer. Do not modify.
namespace llum
{
	public partial class PasswordListWidget
	{
		private global::Gtk.Frame frame1;
		
		private global::Gtk.Alignment GtkAlignment;
		
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Image image1;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.RadioButton studentsRadiobutton;
		
		private global::Gtk.ComboBox groupsCombobox;
		
		private global::Gtk.RadioButton teachersRadiobutton;
		
		private global::Gtk.RadioButton allRadiobutton;
		
		private global::Gtk.VSeparator vseparator1;
		
		private global::Gtk.Button generateButton;
		
		private global::Gtk.Label label1;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget llum.PasswordListWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "llum.PasswordListWidget";
			// Container child llum.PasswordListWidget.Gtk.Container+ContainerChild
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
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.image1 = new global::Gtk.Image ();
			this.image1.Name = "image1";
			this.image1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "system-lock-screen", global::Gtk.IconSize.Dialog);
			this.hbox3.Add (this.image1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.image1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Get password list");
			this.hbox3.Add (this.label2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label2]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.vbox1.Add (this.hbox3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox3]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			this.hbox1.BorderWidth = ((uint)(11));
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.studentsRadiobutton = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Students"));
			this.studentsRadiobutton.CanFocus = true;
			this.studentsRadiobutton.Name = "studentsRadiobutton";
			this.studentsRadiobutton.DrawIndicator = true;
			this.studentsRadiobutton.UseUnderline = true;
			this.studentsRadiobutton.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.hbox2.Add (this.studentsRadiobutton);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.studentsRadiobutton]));
			w4.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.groupsCombobox = global::Gtk.ComboBox.NewText ();
			this.groupsCombobox.Name = "groupsCombobox";
			this.hbox2.Add (this.groupsCombobox);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.groupsCombobox]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox2.Add (this.hbox2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox2]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.teachersRadiobutton = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Teachers"));
			this.teachersRadiobutton.CanFocus = true;
			this.teachersRadiobutton.Name = "teachersRadiobutton";
			this.teachersRadiobutton.DrawIndicator = true;
			this.teachersRadiobutton.UseUnderline = true;
			this.teachersRadiobutton.Group = this.studentsRadiobutton.Group;
			this.vbox2.Add (this.teachersRadiobutton);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.teachersRadiobutton]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.allRadiobutton = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("All users"));
			this.allRadiobutton.CanFocus = true;
			this.allRadiobutton.Name = "allRadiobutton";
			this.allRadiobutton.DrawIndicator = true;
			this.allRadiobutton.UseUnderline = true;
			this.allRadiobutton.Group = this.studentsRadiobutton.Group;
			this.vbox2.Add (this.allRadiobutton);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.allRadiobutton]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			this.hbox1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox2]));
			w9.Position = 0;
			w9.Expand = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator ();
			this.vseparator1.Name = "vseparator1";
			this.hbox1.Add (this.vseparator1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vseparator1]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.generateButton = new global::Gtk.Button ();
			this.generateButton.CanFocus = true;
			this.generateButton.Name = "generateButton";
			this.generateButton.UseUnderline = true;
			this.generateButton.Label = global::Mono.Unix.Catalog.GetString ("Generate list");
			global::Gtk.Image w11 = new global::Gtk.Image ();
			w11.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-properties", global::Gtk.IconSize.Dnd);
			this.generateButton.Image = w11;
			this.hbox1.Add (this.generateButton);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.generateButton]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			w13.Padding = ((uint)(9));
			// Container child vbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 0F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Important:</b> Student list is the only list up to date. \nOnce a teacher manually changes his/her password, it's no longer updated in these lists.");
			this.label1.UseMarkup = true;
			this.label1.Wrap = true;
			this.vbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.label1]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			this.GtkAlignment.Add (this.vbox1);
			this.frame1.Add (this.GtkAlignment);
			this.Add (this.frame1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.generateButton.Clicked += new global::System.EventHandler (this.OnGenerateButtonClicked);
		}
	}
}
