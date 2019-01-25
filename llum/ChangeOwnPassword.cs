
using System;

namespace llum
{

	

	[System.ComponentModel.ToolboxItem(true)]
	public partial class ChangeOwnPassword : Gtk.Bin
	{
		protected virtual void OnPassword2EntryChanged (object sender, System.EventArgs e)
		{
			
			if(oldPasswordEntry.Text!=llum.Core.getCore().user_info[1])
			{
				msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Enter old password") + "</span>";
				acceptButton.Sensitive=false;	
				
			}
			else
			{
				if (password1Entry.Text!=password2Entry.Text || password1Entry.Text=="" )
				{
					msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("New passwords do not match") + "</span>";
					acceptButton.Sensitive=false;
				}
				else
				{
					msgLabel.Text="";
					acceptButton.Sensitive=true;	
				}
			}
		}
		
		public Gtk.Image image;
		public Gtk.Label label;

		public ChangeOwnPassword ()
		{
			
			image=new Gtk.Image();
			image.SetFromIconName("stock_keyring",Gtk.IconSize.Dnd);
			
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Change Own Password"));
			label.Show();
			
			
			this.Build ();
		}
		
		
		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			if(llum.Core.getCore().cop==null)
				llum.Core.getCore().cop=new ChangeOwnPassword();
			
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().cop);
		}
		
		protected virtual void OnAcceptButtonClicked (object sender, System.EventArgs e)
		{
			if(password1Entry.Text!="")
			{	llum.Core core=llum.Core.getCore();
				string out_response;
				out_response=llum.Core.getCore().xmlrpc.client.change_own_password(core.user_info,"Golem",core.user_info,password1Entry.Text);
				
				if (out_response=="true")
				{
					msgLabel.Text=Mono.Unix.Catalog.GetString("Password changed successfully");
					core.user_info[1]=password1Entry.Text;	
				}
				else
					msgLabel.Text=Mono.Unix.Catalog.GetString("Could not change password.") + "\n Error: " + out_response;
			}
		}
		
		protected virtual void OnPassword1EntryChanged (object sender, System.EventArgs e)
		{
			if(oldPasswordEntry.Text!=llum.Core.getCore().user_info[1])
			{
				msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Enter old password") + "</span>";
				acceptButton.Sensitive=false;			
			}
			else
			{
				if (password1Entry.Text!=password2Entry.Text || password1Entry.Text=="" )
				{
					msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("New passwords do not match") + "</span>";
					acceptButton.Sensitive=false;
				}
				else
				{
					msgLabel.Text="";
					acceptButton.Sensitive=true;	
				}
			}		
		}
		
		protected virtual void OnOldPasswordEntryChanged (object sender, System.EventArgs e)
		{
			if(oldPasswordEntry.Text!=llum.Core.getCore().user_info[1])
			{
				msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Enter old password") + "</span>";
				acceptButton.Sensitive=false;			
			}
			else
			{
				if (password1Entry.Text!=password2Entry.Text || password1Entry.Text=="")
				{
					msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("New passwords do not match") + "</span>";
					acceptButton.Sensitive=false;
				}
				else
				{
					msgLabel.Text="";
					acceptButton.Sensitive=true;	
				}
			}			
		}
		
		
		
		
	}
}
