
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class AddUser : Gtk.Bin
	{

		
		public Gtk.Label label;
		public Gtk.Image image;
		
		private Gtk.ListStore store;
		private Gtk.ListStore groups_store;
		
		public AddUser ()
		{
			
			this.Build ();
			acceptButton.Sensitive=false;
			store=new Gtk.ListStore(typeof(string),typeof(int));
			store.AppendValues(Mono.Unix.Catalog.GetString("Students"),0);
			store.AppendValues(Mono.Unix.Catalog.GetString("Teachers"),1);
			store.AppendValues(Mono.Unix.Catalog.GetString("Other"),2);
			templateCombobox.Model=store;
			templateCombobox.Active=0;
			image=new Gtk.Image();
			image.SetFromIconName("gtk-add",Gtk.IconSize.Dnd);
			
			groups_store=new Gtk.ListStore(typeof(string),typeof(int));
			groups_store.AppendValues ("---",0);
			
			System.Collections.Generic.List<string> group_list=llum.Core.getCore().xmlrpc.get_available_groups();
			foreach(string grp in group_list)
			{
					groups_store.AppendValues(grp,1);
			}
			
			groupCombobox.Model=groups_store;
			groupCombobox.Active=0;
			
			
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Add User"));
			label.Show();						


			
		}

		
	
		
		
		
		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			
			llum.Core.getCore().add_user_wid=new AddUser();
			
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().add_user_wid);
		}			
		
		protected virtual void OnAcceptButtonClicked (object sender, System.EventArgs e)
		{
			
			Gtk.TreeIter iter;
			templateCombobox.GetActiveIter(out iter);
			llum.Core core=llum.Core.getCore();
			string ret="";
			
			CookComputing.XmlRpc.XmlRpcStruct user_properties=new CookComputing.XmlRpc.XmlRpcStruct();
			
			user_properties["uid"]=uidEntry.Text;
			user_properties["cn"]=nameEntry.Text;
			user_properties["sn"]=surnameEntry.Text;
			user_properties["userPassword"]=passwordEntry.Text;
			
			/*
			
			
			
			*/
			
			
			switch((int)store.GetValue(iter,1))
			{
				case 0:	
				//Students
				
					if(niaEntry.Text!="")
					{
						user_properties["x-lliurex-usertype"]="itaca";
						user_properties["x-lliurex-nia"]=niaEntry.Text;
					}
					else
						user_properties["x-lliurex-usertype"]="generic";
				
					ret=core.xmlrpc.add_user("Students",user_properties);
					if (ret.Contains("true:"))
					{
						msgLabel.Text=Mono.Unix.Catalog.GetString("User created successfully");
						acceptButton.Sensitive=false;
					}
					else
					{
						msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Error creating user: ") + ret + "</span>";
					}
					break;
				case 1:
				//Teachers

				
				
					if(dniEntry.Text!="")
					{
						user_properties["x-lliurex-usertype"]="itaca";
						user_properties["x-lliurex-nif"]=dniEntry.Text;
					}
					else
						user_properties["x-lliurex-usertype"]="generic";
				
					ret=core.xmlrpc.add_user("Teachers",user_properties);
					if (ret.Contains("true:"))
					{
						msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("User created successfully") + "</b>";
						acceptButton.Sensitive=false;
					}
					else
					{
						msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Error creating user: ") + ret + "</span>";
					}
				
					break;

				case 2:
				//Other
					if(dniEntry.Text!="")
					{
						user_properties["x-lliurex-nif"]=dniEntry.Text;
					}
					
					user_properties["x-lliurex-usertype"]="generic";
				
					ret=core.xmlrpc.add_user("Others",user_properties);
					if (ret.Contains("true:"))
					{
						msgLabel.Text=Mono.Unix.Catalog.GetString("User created successfully");
						acceptButton.Sensitive=false;
					}
					else
					{
						msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Error creating user: ") + ret + "</span>";
					}
				
					break;
				
				
				default:
				
					break;
				
				
				
			}
			
			
			if(ret.Contains("true:"))
			{
				Gtk.TreeIter iter2;
				groupCombobox.GetActiveIter(out iter2);
				
				switch((int)groups_store.GetValue(iter2,1))
				{
					case 1:	
						try
						{
							core.xmlrpc.add_to_group((string)user_properties["uid"],(string)groups_store.GetValue(iter2,0));
						}
						catch
						{
						
						}
					
						break;
					
					default:
						break;
					
					
				}
			}
			
			
		}
		
		protected virtual void OnUndoButtonClicked (object sender, System.EventArgs e)
		{
			nameEntry.Text="";
			surnameEntry.Text="";
			uidEntry.Text="";
			dniEntry.Text="";
			
			
			
		}
		
		protected virtual void OnCancelButtonClicked (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnNameEntryChanged (object sender, System.EventArgs e)
		{
			string generated_uid="";
			string tmp=nameEntry.Text.Replace(" ","");
			char[] name_entry=tmp.ToCharArray();
			for(int i=0;i<tmp.Length;i++)
			{
				generated_uid+=name_entry[i];
				if(surnameEntry.Text.Length>0)
				{
					if(i==2)
						break;
				}
				else
				{
					if(i==5)
						break;
						
						
				}
			}
			
			string[] lista=surnameEntry.Text.Split(' ');
			
			tmp=lista[lista.Length-1];
			
			
			
			char[] surname_entry=tmp.ToCharArray();
			
			for(int i=0;i<tmp.Length;i++)
			{
				generated_uid+=surname_entry[i];
				if((i==2))
					break;
			}
			
			
			
			uidEntry.Text=Core.getCore().strip_special_chars(generated_uid).ToLower();
			
			if(nameEntry.Text.Length>0 && surnameEntry.Text.Length >0 && passwordEntry.Text.Length >0)
				acceptButton.Sensitive=true;
			else
				acceptButton.Sensitive=false;
			
		}
		
		protected virtual void OnSurnameEntryChanged (object sender, System.EventArgs e)
		{
			string generated_uid="";
			string tmp=nameEntry.Text.Replace(" ","");
			char[] name_entry=tmp.ToCharArray();
			for(int i=0;i<tmp.Length;i++)
			{
				generated_uid+=name_entry[i];
				
				if(surnameEntry.Text.Length>0)
				{
					if(i==2)
						break;
				}
				else
				{
					if(i==5)
						break;
						
						
				}
			}
			
			string[] lista=surnameEntry.Text.Split(' ');
			
			
			tmp=lista[lista.Length-1];
			
			char[] surname_entry=tmp.ToCharArray();
			
			for(int i=0;i<tmp.Length;i++)
			{
				generated_uid+=surname_entry[i];
				if((i==2))
					break;
			}
			
			
			
			uidEntry.Text=Core.getCore().strip_special_chars(generated_uid).ToLower();
			
			
			if(nameEntry.Text.Length>0 && surnameEntry.Text.Length >0 && passwordEntry.Text.Length >0)
				acceptButton.Sensitive=true;
			else
				acceptButton.Sensitive=false;			
			
		}

		protected virtual void OnPasswordEntryChanged (object sender, System.EventArgs e)
		{

			if(nameEntry.Text.Length>0 && surnameEntry.Text.Length >0 && passwordEntry.Text.Length >0)
				acceptButton.Sensitive=true;
			else
				acceptButton.Sensitive=false;			
		}

		protected virtual void OnTemplateComboboxChanged (object sender, System.EventArgs e)
		{
			Gtk.TreeIter iter;
			templateCombobox.GetActiveIter(out iter);
			switch((int)store.GetValue(iter,1))
			{
				case 0:	
				
					niaEntry.Sensitive=true;
					dniEntry.Sensitive=false;
					dniEntry.Text="";
				
					break;
				
				case 1:
				
					dniEntry.Sensitive=true;
					niaEntry.Sensitive=false;
					niaEntry.Text="";
					break;
				
				case 2:
					
					dniEntry.Sensitive=true;
					niaEntry.Sensitive=false;
					niaEntry.Text="";
				
					break;
			}
		}
		
		
		
		protected void OnUidEntryChanged (object sender, System.EventArgs e)
		{
			//uidEntry.Text=llum.Core.getCore().strip_special_chars(uidEntry.Text);
			uidEntry.Text=uidEntry.Text.Replace(" ","");
			try
			{

				Convert.ToInt32(uidEntry.Text);
				msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("User ID must contain characters") + "</span>";
				acceptButton.Sensitive=false;
				uidEntry.Text=uidEntry.Text.Trim();
			}
			catch
			{
				msgLabel.Markup="";
				if(uidEntry.Text.Length>0 && nameEntry.Text.Length>0 && surnameEntry.Text.Length >0 && passwordEntry.Text.Length >0)
					acceptButton.Sensitive=true;
				else
					acceptButton.Sensitive=false;
			}
			
			
				
			
		}




	}
}
