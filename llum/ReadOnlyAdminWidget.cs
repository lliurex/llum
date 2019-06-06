using System;

namespace llum
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ReadOnlyAdminWidget : Gtk.Bin
	{
		public Gtk.Label label;
		public Gtk.Image image;
		public bool user_available=false;

		public ReadOnlyAdminWidget ()
		{
			this.Build ();
			//label5



			image=new Gtk.Image();
			image.SetFromIconName("actor",Gtk.IconSize.Dnd);
			image.Show();
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("LDAP Read-Only Admin"));
			label.Show();
			try
			{
				string basedn=llum.Core.getCore().xmlrpc.client.get_variable("","VariablesManager","LDAP_BASE_DN");
				dn_entry.Text=dn_entry.Text.Replace("%%LDAP_BASE_DN%%",basedn);

			}
			catch
			{

			}


			try
			{
				if(llum.Core.getCore().xmlrpc.is_roadmin_available())
				{
					status_image.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "user-available", global::Gtk.IconSize.Menu);
					user_available=true;
					status_image.TooltipText=Mono.Unix.Catalog.GetString("User available");
				}
				else
				{
					button1.Sensitive=false;
				}

			}
			catch
			{
				msg_label.Markup="<span foreground='red'>"+Mono.Unix.Catalog.GetString("LDAP Connection is not ready")+"</span>";
			}



		}

		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			llum.Core.getCore().roadmin_wid=new ReadOnlyAdminWidget();

			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().roadmin_wid);
		}	

		protected void OnButton1Clicked (object sender, EventArgs e)
		{
			try{

				if(!user_available)
				{

				}


				if(pwd_entry.Text==pwd_entry2.Text)
				{
					llum.Core core=llum.Core.getCore();
					core.xmlrpc.change_password(dn_entry.Text,pwd_entry.Text,false);
					msg_label.Markup="<b>"+Mono.Unix.Catalog.GetString("Password changed successfully")+"</b>";
				}
				else
				{
					msg_label.Markup="<span foreground='red'>"+Mono.Unix.Catalog.GetString("Passwords do not match")+"</span>";
				}
			}
			catch{

			}

		}
	}
}

