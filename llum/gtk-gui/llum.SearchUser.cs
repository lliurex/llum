
// This file has been generated by the GUI designer. Do not modify.
namespace llum
{
	public partial class SearchUser
	{
		private global::Gtk.Frame frame1;
		
		private global::Gtk.Alignment GtkAlignment;
		
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Image image1;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Entry searchEntry;
		
		private global::Gtk.Image searchImage;
		
		private global::Gtk.HBox hbox4;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.TreeView userTreeview;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.Button editButton;
		
		private global::Gtk.Button promoteButton;
		
		private global::Gtk.Button demoteButton;
		
		private global::Gtk.Button deleteUsersButton;
		
		private global::Gtk.Label msgLabel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget llum.SearchUser
			global::Stetic.BinContainer.Attach (this);
			this.Name = "llum.SearchUser";
			// Container child llum.SearchUser.Gtk.Container+ContainerChild
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
			this.image1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "system-search", global::Gtk.IconSize.Dialog);
			this.hbox3.Add (this.image1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.image1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Search user");
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
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Search filter:");
			this.hbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.searchEntry = new global::Gtk.Entry ();
			this.searchEntry.CanFocus = true;
			this.searchEntry.Name = "searchEntry";
			this.searchEntry.IsEditable = true;
			this.searchEntry.InvisibleChar = '●';
			this.hbox1.Add (this.searchEntry);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.searchEntry]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.searchImage = new global::Gtk.Image ();
			this.searchImage.Name = "searchImage";
			this.searchImage.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("llum.watch.gif");
			this.hbox1.Add (this.searchImage);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.searchImage]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.userTreeview = new global::Gtk.TreeView ();
			this.userTreeview.CanFocus = true;
			this.userTreeview.Name = "userTreeview";
			this.userTreeview.RulesHint = true;
			this.userTreeview.SearchColumn = 0;
			this.GtkScrolledWindow.Add (this.userTreeview);
			this.hbox4.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.GtkScrolledWindow]));
			w9.Position = 0;
			// Container child hbox4.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.editButton = new global::Gtk.Button ();
			this.editButton.Sensitive = false;
			this.editButton.CanFocus = true;
			this.editButton.Name = "editButton";
			this.editButton.UseUnderline = true;
			this.editButton.Label = global::Mono.Unix.Catalog.GetString ("Edit User");
			global::Gtk.Image w10 = new global::Gtk.Image ();
			w10.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-edit", global::Gtk.IconSize.Menu);
			this.editButton.Image = w10;
			this.vbox2.Add (this.editButton);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.editButton]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.promoteButton = new global::Gtk.Button ();
			this.promoteButton.Sensitive = false;
			this.promoteButton.CanFocus = true;
			this.promoteButton.Name = "promoteButton";
			this.promoteButton.UseUnderline = true;
			this.promoteButton.Label = global::Mono.Unix.Catalog.GetString ("Promote User/s");
			global::Gtk.Image w12 = new global::Gtk.Image ();
			w12.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-go-up", global::Gtk.IconSize.Menu);
			this.promoteButton.Image = w12;
			this.vbox2.Add (this.promoteButton);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.promoteButton]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.demoteButton = new global::Gtk.Button ();
			this.demoteButton.Sensitive = false;
			this.demoteButton.CanFocus = true;
			this.demoteButton.Name = "demoteButton";
			this.demoteButton.UseUnderline = true;
			this.demoteButton.Label = global::Mono.Unix.Catalog.GetString ("Demote User/s");
			global::Gtk.Image w14 = new global::Gtk.Image ();
			w14.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-go-down", global::Gtk.IconSize.Menu);
			this.demoteButton.Image = w14;
			this.vbox2.Add (this.demoteButton);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.demoteButton]));
			w15.Position = 2;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.deleteUsersButton = new global::Gtk.Button ();
			this.deleteUsersButton.Sensitive = false;
			this.deleteUsersButton.CanFocus = true;
			this.deleteUsersButton.Name = "deleteUsersButton";
			this.deleteUsersButton.UseUnderline = true;
			this.deleteUsersButton.Label = global::Mono.Unix.Catalog.GetString ("Delete User/s");
			global::Gtk.Image w16 = new global::Gtk.Image ();
			w16.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "dialog-cancel", global::Gtk.IconSize.Menu);
			this.deleteUsersButton.Image = w16;
			this.vbox2.Add (this.deleteUsersButton);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.deleteUsersButton]));
			w17.Position = 3;
			w17.Expand = false;
			w17.Fill = false;
			this.hbox4.Add (this.vbox2);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.vbox2]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			this.vbox1.Add (this.hbox4);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox4]));
			w19.Position = 2;
			// Container child vbox1.Gtk.Box+BoxChild
			this.msgLabel = new global::Gtk.Label ();
			this.msgLabel.Name = "msgLabel";
			this.vbox1.Add (this.msgLabel);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.msgLabel]));
			w20.Position = 3;
			w20.Expand = false;
			w20.Fill = false;
			this.GtkAlignment.Add (this.vbox1);
			this.frame1.Add (this.GtkAlignment);
			this.Add (this.frame1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.searchEntry.Changed += new global::System.EventHandler (this.OnSearchEntryChanged);
			this.userTreeview.RowActivated += new global::Gtk.RowActivatedHandler (this.OnUserTreeviewRowActivated);
			this.userTreeview.CursorChanged += new global::System.EventHandler (this.OnUserTreeviewCursorChanged);
			this.userTreeview.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnUserTreeviewButtonPressEvent);
			this.userTreeview.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.OnUserTreeviewButtonReleaseEvent);
			this.editButton.Clicked += new global::System.EventHandler (this.OnEditButtonClicked);
			this.promoteButton.Clicked += new global::System.EventHandler (this.OnPromoteButtonClicked);
			this.demoteButton.Clicked += new global::System.EventHandler (this.OnDemoteButtonClicked);
			this.deleteUsersButton.Clicked += new global::System.EventHandler (this.OnDeleteUsersButtonClicked);
		}
	}
}
