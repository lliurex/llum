
// This file has been generated by the GUI designer. Do not modify.
namespace llum
{
	public partial class EditUser
	{
		private global::Gtk.Frame frame1;
		
		private global::Gtk.Alignment GtkAlignment;
		
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox6;
		
		private global::Gtk.Image image1;
		
		private global::Gtk.Label label10;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Label uidNumLabel;
		
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Label uidLabel;
		
		private global::Gtk.HBox hbox4;
		
		private global::Gtk.Label label7;
		
		private global::Gtk.Label groupLabel;
		
		private global::Gtk.HSeparator hseparator1;
		
		private global::Gtk.Frame frame4;
		
		private global::Gtk.Alignment GtkAlignment6;
		
		private global::Gtk.HBox hbox13;
		
		private global::Gtk.VBox vbox8;
		
		private global::Gtk.HBox hbox14;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Entry niaEntry;
		
		private global::Gtk.HBox hbox15;
		
		private global::Gtk.Label label6;
		
		private global::Gtk.Entry dniEntry;
		
		private global::Gtk.VSeparator vseparator3;
		
		private global::Gtk.Button niaButton;
		
		private global::Gtk.Label GtkLabel6;
		
		private global::Gtk.HBox hbox5;
		
		private global::Gtk.Frame frame2;
		
		private global::Gtk.Alignment GtkAlignment1;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.HBox hbox7;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.HBox hbox8;
		
		private global::Gtk.Label label11;
		
		private global::Gtk.Entry nameEntry;
		
		private global::Gtk.HBox hbox9;
		
		private global::Gtk.Label label12;
		
		private global::Gtk.Entry surnameEntry;
		
		private global::Gtk.VSeparator vseparator2;
		
		private global::Gtk.VBox vbox4;
		
		private global::Gtk.Button undoButton;
		
		private global::Gtk.Button applyButton;
		
		private global::Gtk.HSeparator hseparator2;
		
		private global::Gtk.Expander expander1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.VBox vbox7;
		
		private global::Gtk.HBox hbox11;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Entry passEntry;
		
		private global::Gtk.HBox hbox12;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Entry passEntry2;
		
		private global::Gtk.Button changePasswordButton;
		
		private global::Gtk.Label GtkLabel3;
		
		private global::Gtk.Label GtkLabel5;
		
		private global::Gtk.Frame frame3;
		
		private global::Gtk.Alignment GtkAlignment5;
		
		private global::Gtk.VBox vbox6;
		
		private global::Gtk.HBox hbox10;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.TreeView belongTreeview;
		
		private global::Gtk.VBox vbox5;
		
		private global::Gtk.Button removeGroupButton;
		
		private global::Gtk.Image image3;
		
		private global::Gtk.Button addGroupButton;
		
		private global::Gtk.Image image2;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		
		private global::Gtk.TreeView availableTreeview;
		
		private global::Gtk.Label GtkLabel4;
		
		private global::Gtk.Label msgLabel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget llum.EditUser
			global::Stetic.BinContainer.Attach (this);
			this.Name = "llum.EditUser";
			// Container child llum.EditUser.Gtk.Container+ContainerChild
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
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.image1 = new global::Gtk.Image ();
			this.image1.Name = "image1";
			this.image1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "stock_person", global::Gtk.IconSize.Dialog);
			this.hbox6.Add (this.image1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.image1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label10 = new global::Gtk.Label ();
			this.label10.Name = "label10";
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString ("User details");
			this.hbox6.Add (this.label10);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.label10]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.vbox1.Add (this.hbox6);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox6]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			w3.Padding = ((uint)(3));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.WidthRequest = 160;
			this.label2.Name = "label2";
			this.label2.Xalign = 0F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>User ID#</b>");
			this.label2.UseMarkup = true;
			this.hbox3.Add (this.label2);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label2]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			w4.Padding = ((uint)(5));
			// Container child hbox3.Gtk.Box+BoxChild
			this.uidNumLabel = new global::Gtk.Label ();
			this.uidNumLabel.Name = "uidNumLabel";
			this.uidNumLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("label6");
			this.hbox3.Add (this.uidNumLabel);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.uidNumLabel]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			w5.Padding = ((uint)(10));
			this.vbox1.Add (this.hbox3);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox3]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.WidthRequest = 160;
			this.label1.Name = "label1";
			this.label1.Xalign = 0F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>User ID</b>");
			this.label1.UseMarkup = true;
			this.hbox2.Add (this.label1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label1]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			w7.Padding = ((uint)(5));
			// Container child hbox2.Gtk.Box+BoxChild
			this.uidLabel = new global::Gtk.Label ();
			this.uidLabel.Name = "uidLabel";
			this.uidLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("label3");
			this.hbox2.Add (this.uidLabel);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.uidLabel]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			w8.Padding = ((uint)(10));
			this.vbox1.Add (this.hbox2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.WidthRequest = 160;
			this.label7.Name = "label7";
			this.label7.Xalign = 0F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Group</b>");
			this.label7.UseMarkup = true;
			this.hbox4.Add (this.label7);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.label7]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			w10.Padding = ((uint)(5));
			// Container child hbox4.Gtk.Box+BoxChild
			this.groupLabel = new global::Gtk.Label ();
			this.groupLabel.Name = "groupLabel";
			this.groupLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("label8");
			this.hbox4.Add (this.groupLabel);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.groupLabel]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			w11.Padding = ((uint)(10));
			this.vbox1.Add (this.hbox4);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox4]));
			w12.Position = 3;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.vbox1.Add (this.hseparator1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hseparator1]));
			w13.Position = 4;
			w13.Expand = false;
			w13.Fill = false;
			w13.Padding = ((uint)(5));
			// Container child vbox1.Gtk.Box+BoxChild
			this.frame4 = new global::Gtk.Frame ();
			this.frame4.Name = "frame4";
			this.frame4.ShadowType = ((global::Gtk.ShadowType)(4));
			// Container child frame4.Gtk.Container+ContainerChild
			this.GtkAlignment6 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment6.Name = "GtkAlignment6";
			this.GtkAlignment6.LeftPadding = ((uint)(6));
			this.GtkAlignment6.TopPadding = ((uint)(6));
			this.GtkAlignment6.RightPadding = ((uint)(6));
			this.GtkAlignment6.BottomPadding = ((uint)(6));
			// Container child GtkAlignment6.Gtk.Container+ContainerChild
			this.hbox13 = new global::Gtk.HBox ();
			this.hbox13.Name = "hbox13";
			this.hbox13.Spacing = 6;
			// Container child hbox13.Gtk.Box+BoxChild
			this.vbox8 = new global::Gtk.VBox ();
			this.vbox8.Name = "vbox8";
			this.vbox8.Spacing = 6;
			// Container child vbox8.Gtk.Box+BoxChild
			this.hbox14 = new global::Gtk.HBox ();
			this.hbox14.Name = "hbox14";
			this.hbox14.Spacing = 6;
			// Container child hbox14.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.WidthRequest = 100;
			this.label5.Name = "label5";
			this.label5.Xalign = 0F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("NIA");
			this.hbox14.Add (this.label5);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox14 [this.label5]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox14.Gtk.Box+BoxChild
			this.niaEntry = new global::Gtk.Entry ();
			this.niaEntry.CanFocus = true;
			this.niaEntry.Name = "niaEntry";
			this.niaEntry.IsEditable = true;
			this.niaEntry.InvisibleChar = '●';
			this.hbox14.Add (this.niaEntry);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox14 [this.niaEntry]));
			w15.Position = 1;
			this.vbox8.Add (this.hbox14);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox8 [this.hbox14]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox8.Gtk.Box+BoxChild
			this.hbox15 = new global::Gtk.HBox ();
			this.hbox15.Name = "hbox15";
			this.hbox15.Spacing = 6;
			// Container child hbox15.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.WidthRequest = 100;
			this.label6.Name = "label6";
			this.label6.Xalign = 0F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("DNI");
			this.hbox15.Add (this.label6);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox15 [this.label6]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hbox15.Gtk.Box+BoxChild
			this.dniEntry = new global::Gtk.Entry ();
			this.dniEntry.CanFocus = true;
			this.dniEntry.Name = "dniEntry";
			this.dniEntry.IsEditable = true;
			this.dniEntry.InvisibleChar = '●';
			this.hbox15.Add (this.dniEntry);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox15 [this.dniEntry]));
			w18.Position = 1;
			this.vbox8.Add (this.hbox15);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox8 [this.hbox15]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			this.hbox13.Add (this.vbox8);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox13 [this.vbox8]));
			w20.Position = 0;
			// Container child hbox13.Gtk.Box+BoxChild
			this.vseparator3 = new global::Gtk.VSeparator ();
			this.vseparator3.Name = "vseparator3";
			this.hbox13.Add (this.vseparator3);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox13 [this.vseparator3]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbox13.Gtk.Box+BoxChild
			this.niaButton = new global::Gtk.Button ();
			this.niaButton.CanFocus = true;
			this.niaButton.Name = "niaButton";
			this.niaButton.UseStock = true;
			this.niaButton.UseUnderline = true;
			this.niaButton.Label = "gtk-apply";
			this.hbox13.Add (this.niaButton);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox13 [this.niaButton]));
			w22.Position = 2;
			w22.Expand = false;
			w22.Fill = false;
			this.GtkAlignment6.Add (this.hbox13);
			this.frame4.Add (this.GtkAlignment6);
			this.GtkLabel6 = new global::Gtk.Label ();
			this.GtkLabel6.Name = "GtkLabel6";
			this.GtkLabel6.Xpad = 6;
			this.GtkLabel6.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Identification Number</b>");
			this.GtkLabel6.UseMarkup = true;
			this.frame4.LabelWidget = this.GtkLabel6;
			this.vbox1.Add (this.frame4);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.frame4]));
			w25.Position = 5;
			w25.Expand = false;
			w25.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(4));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment1 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment1.Name = "GtkAlignment1";
			this.GtkAlignment1.LeftPadding = ((uint)(6));
			this.GtkAlignment1.TopPadding = ((uint)(6));
			this.GtkAlignment1.RightPadding = ((uint)(6));
			this.GtkAlignment1.BottomPadding = ((uint)(6));
			this.GtkAlignment1.BorderWidth = ((uint)(7));
			// Container child GtkAlignment1.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.label11 = new global::Gtk.Label ();
			this.label11.WidthRequest = 100;
			this.label11.Name = "label11";
			this.label11.Xalign = 0F;
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString ("Name");
			this.hbox8.Add (this.label11);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.label11]));
			w26.Position = 0;
			w26.Expand = false;
			w26.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.nameEntry = new global::Gtk.Entry ();
			this.nameEntry.CanFocus = true;
			this.nameEntry.Name = "nameEntry";
			this.nameEntry.IsEditable = true;
			this.nameEntry.InvisibleChar = '●';
			this.hbox8.Add (this.nameEntry);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.nameEntry]));
			w27.Position = 1;
			this.vbox3.Add (this.hbox8);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox8]));
			w28.Position = 0;
			w28.Expand = false;
			w28.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox ();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.label12 = new global::Gtk.Label ();
			this.label12.WidthRequest = 100;
			this.label12.Name = "label12";
			this.label12.Xalign = 0F;
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString ("Surname");
			this.hbox9.Add (this.label12);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.label12]));
			w29.Position = 0;
			w29.Expand = false;
			w29.Fill = false;
			// Container child hbox9.Gtk.Box+BoxChild
			this.surnameEntry = new global::Gtk.Entry ();
			this.surnameEntry.CanFocus = true;
			this.surnameEntry.Name = "surnameEntry";
			this.surnameEntry.IsEditable = true;
			this.surnameEntry.InvisibleChar = '●';
			this.hbox9.Add (this.surnameEntry);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.surnameEntry]));
			w30.Position = 1;
			this.vbox3.Add (this.hbox9);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox9]));
			w31.Position = 1;
			w31.Expand = false;
			w31.Fill = false;
			this.hbox7.Add (this.vbox3);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.vbox3]));
			w32.Position = 0;
			// Container child hbox7.Gtk.Box+BoxChild
			this.vseparator2 = new global::Gtk.VSeparator ();
			this.vseparator2.Name = "vseparator2";
			this.hbox7.Add (this.vseparator2);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.vseparator2]));
			w33.Position = 1;
			w33.Expand = false;
			w33.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.undoButton = new global::Gtk.Button ();
			this.undoButton.CanFocus = true;
			this.undoButton.Name = "undoButton";
			this.undoButton.UseStock = true;
			this.undoButton.UseUnderline = true;
			this.undoButton.Label = "gtk-undo";
			this.vbox4.Add (this.undoButton);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.undoButton]));
			w34.Position = 0;
			w34.Expand = false;
			w34.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.applyButton = new global::Gtk.Button ();
			this.applyButton.CanFocus = true;
			this.applyButton.Name = "applyButton";
			this.applyButton.UseStock = true;
			this.applyButton.UseUnderline = true;
			this.applyButton.Label = "gtk-apply";
			this.vbox4.Add (this.applyButton);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.applyButton]));
			w35.Position = 1;
			w35.Expand = false;
			w35.Fill = false;
			this.hbox7.Add (this.vbox4);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.vbox4]));
			w36.PackType = ((global::Gtk.PackType)(1));
			w36.Position = 2;
			w36.Expand = false;
			w36.Fill = false;
			this.vbox2.Add (this.hbox7);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox7]));
			w37.Position = 0;
			w37.Expand = false;
			w37.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator2 = new global::Gtk.HSeparator ();
			this.hseparator2.Name = "hseparator2";
			this.vbox2.Add (this.hseparator2);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hseparator2]));
			w38.Position = 1;
			w38.Expand = false;
			w38.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.expander1 = new global::Gtk.Expander (null);
			this.expander1.CanFocus = true;
			this.expander1.Name = "expander1";
			// Container child expander1.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox7 = new global::Gtk.VBox ();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox11 = new global::Gtk.HBox ();
			this.hbox11.Name = "hbox11";
			this.hbox11.Spacing = 6;
			// Container child hbox11.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.WidthRequest = 170;
			this.label3.Name = "label3";
			this.label3.Xalign = 0F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Enter new password");
			this.hbox11.Add (this.label3);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.hbox11 [this.label3]));
			w39.Position = 0;
			w39.Expand = false;
			w39.Fill = false;
			// Container child hbox11.Gtk.Box+BoxChild
			this.passEntry = new global::Gtk.Entry ();
			this.passEntry.CanFocus = true;
			this.passEntry.Name = "passEntry";
			this.passEntry.IsEditable = true;
			this.passEntry.Visibility = false;
			this.passEntry.InvisibleChar = '●';
			this.hbox11.Add (this.passEntry);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.hbox11 [this.passEntry]));
			w40.Position = 1;
			this.vbox7.Add (this.hbox11);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.hbox11]));
			w41.Position = 0;
			w41.Expand = false;
			w41.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox12 = new global::Gtk.HBox ();
			this.hbox12.Name = "hbox12";
			this.hbox12.Spacing = 6;
			// Container child hbox12.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.WidthRequest = 170;
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Re-enter new password");
			this.hbox12.Add (this.label4);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.hbox12 [this.label4]));
			w42.Position = 0;
			w42.Expand = false;
			w42.Fill = false;
			// Container child hbox12.Gtk.Box+BoxChild
			this.passEntry2 = new global::Gtk.Entry ();
			this.passEntry2.CanFocus = true;
			this.passEntry2.Name = "passEntry2";
			this.passEntry2.IsEditable = true;
			this.passEntry2.Visibility = false;
			this.passEntry2.InvisibleChar = '●';
			this.hbox12.Add (this.passEntry2);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.hbox12 [this.passEntry2]));
			w43.Position = 1;
			this.vbox7.Add (this.hbox12);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.hbox12]));
			w44.Position = 1;
			w44.Expand = false;
			w44.Fill = false;
			this.hbox1.Add (this.vbox7);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox7]));
			w45.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.changePasswordButton = new global::Gtk.Button ();
			this.changePasswordButton.CanFocus = true;
			this.changePasswordButton.Name = "changePasswordButton";
			this.changePasswordButton.UseStock = true;
			this.changePasswordButton.UseUnderline = true;
			this.changePasswordButton.Label = "gtk-apply";
			this.hbox1.Add (this.changePasswordButton);
			global::Gtk.Box.BoxChild w46 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.changePasswordButton]));
			w46.Position = 1;
			w46.Expand = false;
			w46.Fill = false;
			this.expander1.Add (this.hbox1);
			this.GtkLabel3 = new global::Gtk.Label ();
			this.GtkLabel3.Name = "GtkLabel3";
			this.GtkLabel3.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Change password</b>");
			this.GtkLabel3.UseMarkup = true;
			this.GtkLabel3.UseUnderline = true;
			this.expander1.LabelWidget = this.GtkLabel3;
			this.vbox2.Add (this.expander1);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.expander1]));
			w48.Position = 2;
			w48.Expand = false;
			w48.Fill = false;
			this.GtkAlignment1.Add (this.vbox2);
			this.frame2.Add (this.GtkAlignment1);
			this.GtkLabel5 = new global::Gtk.Label ();
			this.GtkLabel5.Name = "GtkLabel5";
			this.GtkLabel5.Xpad = 6;
			this.GtkLabel5.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Edit user personal data</b>");
			this.GtkLabel5.UseMarkup = true;
			this.frame2.LabelWidget = this.GtkLabel5;
			this.hbox5.Add (this.frame2);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.frame2]));
			w51.Position = 0;
			this.vbox1.Add (this.hbox5);
			global::Gtk.Box.BoxChild w52 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox5]));
			w52.Position = 6;
			w52.Expand = false;
			w52.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.frame3 = new global::Gtk.Frame ();
			this.frame3.Name = "frame3";
			this.frame3.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child frame3.Gtk.Container+ContainerChild
			this.GtkAlignment5 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment5.Name = "GtkAlignment5";
			this.GtkAlignment5.LeftPadding = ((uint)(6));
			this.GtkAlignment5.TopPadding = ((uint)(6));
			this.GtkAlignment5.RightPadding = ((uint)(6));
			this.GtkAlignment5.BottomPadding = ((uint)(6));
			this.GtkAlignment5.BorderWidth = ((uint)(7));
			// Container child GtkAlignment5.Gtk.Container+ContainerChild
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox10 = new global::Gtk.HBox ();
			this.hbox10.Name = "hbox10";
			this.hbox10.Spacing = 6;
			// Container child hbox10.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.belongTreeview = new global::Gtk.TreeView ();
			this.belongTreeview.CanFocus = true;
			this.belongTreeview.Name = "belongTreeview";
			this.GtkScrolledWindow.Add (this.belongTreeview);
			this.hbox10.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w54 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.GtkScrolledWindow]));
			w54.Position = 0;
			// Container child hbox10.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.removeGroupButton = new global::Gtk.Button ();
			this.removeGroupButton.CanFocus = true;
			this.removeGroupButton.Name = "removeGroupButton";
			// Container child removeGroupButton.Gtk.Container+ContainerChild
			this.image3 = new global::Gtk.Image ();
			this.image3.Name = "image3";
			this.image3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-go-forward", global::Gtk.IconSize.Menu);
			this.removeGroupButton.Add (this.image3);
			this.vbox5.Add (this.removeGroupButton);
			global::Gtk.Box.BoxChild w56 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.removeGroupButton]));
			w56.Position = 0;
			w56.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.addGroupButton = new global::Gtk.Button ();
			this.addGroupButton.CanFocus = true;
			this.addGroupButton.Name = "addGroupButton";
			// Container child addGroupButton.Gtk.Container+ContainerChild
			this.image2 = new global::Gtk.Image ();
			this.image2.Name = "image2";
			this.image2.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-go-back", global::Gtk.IconSize.Menu);
			this.addGroupButton.Add (this.image2);
			this.vbox5.Add (this.addGroupButton);
			global::Gtk.Box.BoxChild w58 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.addGroupButton]));
			w58.Position = 1;
			w58.Fill = false;
			this.hbox10.Add (this.vbox5);
			global::Gtk.Box.BoxChild w59 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.vbox5]));
			w59.Position = 1;
			w59.Expand = false;
			w59.Fill = false;
			// Container child hbox10.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.availableTreeview = new global::Gtk.TreeView ();
			this.availableTreeview.CanFocus = true;
			this.availableTreeview.Name = "availableTreeview";
			this.GtkScrolledWindow1.Add (this.availableTreeview);
			this.hbox10.Add (this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w61 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.GtkScrolledWindow1]));
			w61.Position = 2;
			this.vbox6.Add (this.hbox10);
			global::Gtk.Box.BoxChild w62 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.hbox10]));
			w62.Position = 0;
			this.GtkAlignment5.Add (this.vbox6);
			this.frame3.Add (this.GtkAlignment5);
			this.GtkLabel4 = new global::Gtk.Label ();
			this.GtkLabel4.Name = "GtkLabel4";
			this.GtkLabel4.Xpad = 6;
			this.GtkLabel4.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Edit user groups</b>");
			this.GtkLabel4.UseMarkup = true;
			this.frame3.LabelWidget = this.GtkLabel4;
			this.vbox1.Add (this.frame3);
			global::Gtk.Box.BoxChild w65 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.frame3]));
			w65.Position = 7;
			// Container child vbox1.Gtk.Box+BoxChild
			this.msgLabel = new global::Gtk.Label ();
			this.msgLabel.Name = "msgLabel";
			this.vbox1.Add (this.msgLabel);
			global::Gtk.Box.BoxChild w66 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.msgLabel]));
			w66.Position = 8;
			w66.Expand = false;
			w66.Fill = false;
			this.GtkAlignment.Add (this.vbox1);
			this.frame1.Add (this.GtkAlignment);
			this.Add (this.frame1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.niaButton.Clicked += new global::System.EventHandler (this.OnNiaButtonClicked);
			this.undoButton.Clicked += new global::System.EventHandler (this.OnUndoButtonClicked);
			this.applyButton.Clicked += new global::System.EventHandler (this.OnApplyButtonClicked);
			this.passEntry.Changed += new global::System.EventHandler (this.OnPassEntryChanged);
			this.passEntry2.Changed += new global::System.EventHandler (this.OnPass2EntryChanged);
			this.changePasswordButton.Clicked += new global::System.EventHandler (this.OnChangePasswordButtonClicked);
			this.removeGroupButton.Clicked += new global::System.EventHandler (this.OnRemoveGroupButtonClicked);
			this.addGroupButton.Clicked += new global::System.EventHandler (this.OnAddGroupButtonClicked);
		}
	}
}
