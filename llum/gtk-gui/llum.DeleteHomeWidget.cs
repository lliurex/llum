
// This file has been generated by the GUI designer. Do not modify.
namespace llum
{
	public partial class DeleteHomeWidget
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Image image1;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Frame frame2;
		
		private global::Gtk.Alignment GtkAlignment3;
		
		private global::Gtk.HBox selectionHbox;
		
		private global::Gtk.ComboBox optionCombobox;
		
		private global::Gtk.Button acceptButton;
		
		private global::Gtk.Label GtkLabel3;
		
		private global::Gtk.Label label7;
		
		private global::Gtk.HBox warningHbox;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.Label warningLabel;
		
		private global::Gtk.HBox hbox9;
		
		private global::Gtk.Button doitButton;
		
		private global::Gtk.Button cancelButton;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.Label msgLabel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget llum.DeleteHomeWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "llum.DeleteHomeWidget";
			// Container child llum.DeleteHomeWidget.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 12;
			this.vbox1.BorderWidth = ((uint)(7));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.image1 = new global::Gtk.Image ();
			this.image1.Name = "image1";
			this.image1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Dialog);
			this.hbox3.Add (this.image1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.image1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Clear /home contents tool");
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
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(2));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment3 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment3.Name = "GtkAlignment3";
			this.GtkAlignment3.LeftPadding = ((uint)(6));
			this.GtkAlignment3.TopPadding = ((uint)(6));
			this.GtkAlignment3.RightPadding = ((uint)(6));
			this.GtkAlignment3.BottomPadding = ((uint)(6));
			// Container child GtkAlignment3.Gtk.Container+ContainerChild
			this.selectionHbox = new global::Gtk.HBox ();
			this.selectionHbox.Name = "selectionHbox";
			this.selectionHbox.Spacing = 6;
			// Container child selectionHbox.Gtk.Box+BoxChild
			this.optionCombobox = global::Gtk.ComboBox.NewText ();
			this.optionCombobox.Name = "optionCombobox";
			this.selectionHbox.Add (this.optionCombobox);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.selectionHbox [this.optionCombobox]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child selectionHbox.Gtk.Box+BoxChild
			this.acceptButton = new global::Gtk.Button ();
			this.acceptButton.CanFocus = true;
			this.acceptButton.Name = "acceptButton";
			this.acceptButton.UseStock = true;
			this.acceptButton.UseUnderline = true;
			this.acceptButton.Label = "gtk-ok";
			this.selectionHbox.Add (this.acceptButton);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.selectionHbox [this.acceptButton]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.GtkAlignment3.Add (this.selectionHbox);
			this.frame2.Add (this.GtkAlignment3);
			this.GtkLabel3 = new global::Gtk.Label ();
			this.GtkLabel3.Name = "GtkLabel3";
			this.GtkLabel3.Xpad = 6;
			this.GtkLabel3.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Group of homes to delete</b>");
			this.GtkLabel3.UseMarkup = true;
			this.frame2.LabelWidget = this.GtkLabel3;
			this.vbox1.Add (this.frame2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.frame2]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.Xalign = 0F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("* You will be asked to confirm this action");
			this.vbox1.Add (this.label7);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.label7]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.warningHbox = new global::Gtk.HBox ();
			this.warningHbox.Name = "warningHbox";
			this.warningHbox.Spacing = 6;
			// Container child warningHbox.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.warningLabel = new global::Gtk.Label ();
			this.warningLabel.Name = "warningLabel";
			this.vbox3.Add (this.warningLabel);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.warningLabel]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox ();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.doitButton = new global::Gtk.Button ();
			this.doitButton.CanFocus = true;
			this.doitButton.Name = "doitButton";
			this.doitButton.UseStock = true;
			this.doitButton.UseUnderline = true;
			this.doitButton.Label = "gtk-ok";
			this.hbox9.Add (this.doitButton);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.doitButton]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox9.Gtk.Box+BoxChild
			this.cancelButton = new global::Gtk.Button ();
			this.cancelButton.CanFocus = true;
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.UseStock = true;
			this.cancelButton.UseUnderline = true;
			this.cancelButton.Label = "gtk-cancel";
			this.hbox9.Add (this.cancelButton);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.cancelButton]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			this.vbox3.Add (this.hbox9);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox9]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			this.warningHbox.Add (this.vbox3);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.warningHbox [this.vbox3]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			this.vbox1.Add (this.warningHbox);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.warningHbox]));
			w15.Position = 3;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			global::Gtk.Viewport w16 = new global::Gtk.Viewport ();
			w16.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.msgLabel = new global::Gtk.Label ();
			this.msgLabel.Name = "msgLabel";
			w16.Add (this.msgLabel);
			this.GtkScrolledWindow.Add (w16);
			this.vbox1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
			w19.PackType = ((global::Gtk.PackType)(1));
			w19.Position = 4;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.acceptButton.Clicked += new global::System.EventHandler (this.OnAcceptButtonClicked);
			this.doitButton.Clicked += new global::System.EventHandler (this.OnDoitButtonClicked);
		}
	}
}
