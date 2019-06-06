
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class GescenImportWidget : Gtk.Bin
	{

		public Gtk.Image image;
		public Gtk.Label label;
		public Gtk.TreeStore group_store;
		public Gtk.TreeStore user_store;
		public System.Collections.Generic.List<LdapUser>to_delete;
		
		public GescenImportWidget ()
		{
			this.Build ();
			
			image=new Gtk.Image();
			image.SetFromIconName("document-new",Gtk.IconSize.Dnd);
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Import Gescen/Itaca file"));
			label.Show();	
			
			groupHbox.Sensitive=false;
			
			/*
			Gtk.FileFilter filter=new Gtk.FileFilter();
			filter.AddPattern("*.xml");
			filter.AddPattern("*.XML");
			gescenFilechooserbutton.Filter=filter;
			*/
			
			group_store=new Gtk.TreeStore(typeof(bool),typeof(string));
			
			Gtk.TreeViewColumn check_column=new Gtk.TreeViewColumn();
			Gtk.CellRendererToggle check_column_cell=new Gtk.CellRendererToggle();
			/*
			 
			user_id_column=new Gtk.TreeViewColumn();
			user_id_column.Title=Mono.Unix.Catalog.GetString("User ID");
			user_id_cell_renderer=new Gtk.CellRendererText();
			user_id_column.PackStart(user_id_cell_renderer,true);
			user_id_column.AddAttribute(user_id_cell_renderer,"text",0);
			userListTreeview.AppendColumn(user_id_column);
			store=new Gtk.ListStore(typeof(string),typeof(string),typeof(string));
			userListTreeview.Model=store;			
			
			*/
			check_column.Title=Mono.Unix.Catalog.GetString("Importable");
			check_column.PackStart(check_column_cell,true);
			check_column.AddAttribute(check_column_cell,"active",0);
			
			groupListTreeview.AppendColumn(check_column);
			
			Gtk.TreeViewColumn group_name_column=new Gtk.TreeViewColumn();
			group_name_column.Title=Mono.Unix.Catalog.GetString("Group");
			Gtk.CellRendererText group_name_column_cell=new Gtk.CellRendererText();
			group_name_column.PackStart(group_name_column_cell,true);
			group_name_column.AddAttribute(group_name_column_cell,"text",1);
			groupListTreeview.AppendColumn(group_name_column);
			
			groupListTreeview.Model=group_store;
			
			
			Gtk.TreeViewColumn user_uid_column=new Gtk.TreeViewColumn();
			user_uid_column.Title="UID";
			Gtk.CellRendererText user_uid_cell=new Gtk.CellRendererText();
			user_uid_column.PackStart(user_uid_cell,true);
			user_uid_column.AddAttribute(user_uid_cell,"text",0);
			usersToDeleteTreeview.AppendColumn(user_uid_column);
			
			Gtk.TreeViewColumn user_desc_column=new Gtk.TreeViewColumn();
			user_desc_column.Title=Mono.Unix.Catalog.GetString("Description");
			Gtk.CellRendererText user_desc_cell=new Gtk.CellRendererText();
			user_desc_column.PackStart(user_desc_cell,true);
			user_desc_column.AddAttribute(user_desc_cell,"text",1);
			usersToDeleteTreeview.AppendColumn(user_desc_column);
			
			Gtk.TreeViewColumn user_group_column=new Gtk.TreeViewColumn();
			user_group_column.Title=Mono.Unix.Catalog.GetString("Group");
			Gtk.CellRendererText user_group_cell=new Gtk.CellRendererText();
			user_group_column.PackStart(user_group_cell,true);
			user_group_column.AddAttribute(user_group_cell,"text",2);
			usersToDeleteTreeview.AppendColumn(user_group_column);
			
			user_store=new Gtk.TreeStore(typeof(string),typeof(string),typeof(string));
			usersToDeleteTreeview.Model=user_store;
			usersToDeleteHbox.Sensitive=false;
			
			
		}
		
		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			
			llum.Core.getCore().gescen_wid=new GescenImportWidget();
			
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().gescen_wid);
		}		
		
		protected virtual void OnSendGescenButtonClicked (object sender, System.EventArgs e)
		{
					
			if(gescenFilechooserbutton.Filename!=null)
			{
				group_store.Clear();
				
				string file=gescenFilechooserbutton.Filename;
				/*
				string[] list=file.Split('/');
				string file_name=list[list.Length-1];
				*/
				//llum.Core.getCore().xmlrpc.send_file_to_server(file,"/home/lliurex/"+file_name);
				
				string passwd="";
				
				if(apply_passwd_checkbutton.Active)
					passwd=itaca_passwd_entry.Text;
				
				string ret=llum.Core.getCore().xmlrpc.send_xml_to_server(file,passwd);
				
				
				
				if(ret=="true")
				{
					System.Collections.Generic.List<string> list=llum.Core.getCore().xmlrpc.gescen_groups();
					if(list!=null)
					{
						foreach(string str in list)
						{
							
							group_store.AppendValues(false,str);	
						}
					}
					
					groupHbox.Sensitive=true;
					
						
				}
				else
				{
					if (ret.Contains("false:encrypted:"))
					{
						ret=ret.Replace("false:encrypted:","");
						msgLabel.Markup="<span foreground='red'>" + ret + "</span>";
					}
					else
					{
						msgLabel.Markup="<span foreground='red'>" + ret + "</span>";
						Console.WriteLine (ret);	
					}
				}
				
				
			}
			//llum.Core.getCore().xmlrpc.send_file_to_server(gescenFilechooserbutton.Filename,"/home/lliurex/test.xml");
		}
		

		
		protected virtual void OnCompleteRadiobuttonToggled (object sender, System.EventArgs e)
		{
			
			
			if(completeRadiobutton.Active)
			{
				Gtk.TreeIter iter;
				
				if(group_store.IterNChildren()>0)
				{
					group_store.GetIterFirst(out iter);
					group_store.SetValue(iter,0,true);
					
					while(group_store.IterNext(ref iter))
						group_store.SetValue(iter,0,true);
				}
			}
		}
		
		
		
		[GLib.ConnectBefore]
		protected virtual void OnGroupListTreeviewButtonReleaseEvent (object o, Gtk.ButtonReleaseEventArgs args)
		{
			Gtk.TreeIter iter;
			groupListTreeview.Selection.GetSelected(out iter);
			
			//bool original_state=(bool)group_store.GetValue(iter,0);
			
			group_store.SetValue(iter,0,!(bool)group_store.GetValue(iter,0));				
		}
		
		protected virtual void OnImportButtonClicked (object sender, System.EventArgs e)
		{
		
			if(partialRadiobutton.Active)
			{
				
			
				Gtk.TreeIter iter;
				System.Collections.Generic.List<string> list=new System.Collections.Generic.List<string>();
				if(group_store.IterNChildren()>0)
				{
					group_store.GetIterFirst(out iter);
					if((bool)group_store.GetValue(iter,0))
						list.Add((string)group_store.GetValue(iter,1));
					
					
					while(group_store.IterNext(ref iter))
						if((bool)group_store.GetValue(iter,0))
							list.Add((string)group_store.GetValue(iter,1));
				}
				
				string[] str_array=new string[list.Count];
				int i;
				for(i=0;i<list.Count;i++)
					str_array[i]=list[i];
				
				
				
				System.Threading.Thread thread=null;

				llum.Core.getCore().progress_window=new ProgressWindow(Mono.Unix.Catalog.GetString("Importing users and groups..."));
				llum.Core.getCore().progress_window.ShowAll();
				llum.Core.getCore().progress_window.ShowNow();				
				
				System.Threading.ThreadStart progressTStart = delegate 
				{
						
		
					bool ret=llum.Core.getCore().xmlrpc.gescen_partial(str_array);
						
					Gtk.Application.Invoke(delegate{
						if(ret)
						{
							msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Importation successful") + "</b>";
							
						}
						else
						{
							
							string txt="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Importation failed") + "</span>" ;
							msgLabel.Markup=txt;
					
						}
						llum.Core.getCore().progress_window.Hide();
						});
					
	
				};
			
				thread=new System.Threading.Thread(progressTStart);
				thread.Start();
	
	

			}
			if(completeRadiobutton.Active)
			{
				
				
				System.Threading.Thread thread2=null;
				System.Threading.ThreadStart tstart=delegate
				{
						Gtk.Application.Invoke(delegate {
							llum.Core.getCore().progress_window=new ProgressWindow(Mono.Unix.Catalog.GetString("Importing users and groups..."));
							llum.Core.getCore().progress_window.ShowAll();
							llum.Core.getCore().progress_window.ShowNow();
						});
						

							
				};
				
				thread2=new System.Threading.Thread(tstart);
				thread2.Start();						
				
				
				System.Threading.Thread thread=null;
				
				
				System.Threading.ThreadStart progressTStart = delegate 
				{
						
		
					//bool ret=llum.Core.getCore().xmlrpc.gescen_partial(str_array);
					
					System.Collections.Generic.List<LdapUser> ret=llum.Core.getCore().xmlrpc.gescen_full();
						
					Gtk.Application.Invoke(delegate{
					if(ret!=null)
					{
						msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Importation successful") + "</b>";
						user_store.Clear();	
						foreach(LdapUser user in ret)
						{
							user_store.AppendValues(user.uid,user.name + " " + user.surname,user.main_group);
						}
						if(ret.Count>0)
						{
							usersToDeleteHbox.Sensitive=true;
							to_delete=ret;		
						}
						
						
							
					}
					else
					{
							
						string txt="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Importation failed") + "</span>" ;
						msgLabel.Markup=txt;
					
					}
	
					groupHbox.Sensitive=false;	
					
					Core.getCore().progress_window.Hide();
					thread.Abort();	
						
					});
					
	
				};
			
				thread=new System.Threading.Thread(progressTStart);
				thread.Start();
	
		
			}
			
		}
		
		protected virtual void OnClearButtonClicked (object sender, System.EventArgs e)
		{
			if(groupHbox.Sensitive && !completeRadiobutton.Active)
			{
				Gtk.TreeIter iter;
				
				if(group_store.IterNChildren()>0)
				{
					group_store.GetIterFirst(out iter);
					group_store.SetValue(iter,0,false);
					
					while(group_store.IterNext(ref iter))
						group_store.SetValue(iter,0,false);
				}				
			}
		}
		
		protected virtual void OnDeleteButtonClicked (object sender, System.EventArgs e)
		{
			llum.Core core=llum.Core.getCore();
			
			core.delete_users_wid=new DeleteUserWidget(to_delete,"users");
			core.mw.setCurrentWidget(core.delete_users_wid);
		}
		
		protected virtual void OnCancelDeleteButtonClicked (object sender, System.EventArgs e)
		{
			llum.Core core=llum.Core.getCore();
			
			core.search_user=new SearchUser(false);
			core.mw.setCurrentWidget(core.search_user);
			
		}
		
		
		
		
		
		
		
		
		
		
		protected void OnCheckbutton1Toggled (object sender, System.EventArgs e)
		{
			if(apply_passwd_checkbutton.Active)
			{
				Console.WriteLine ("APPLY PASSWORD ENABLED");
				passwd_label.Sensitive=true;
				itaca_passwd_entry.Sensitive=true;
			}
			else
			{
				Console.WriteLine ("APPLY PASSWORD DISABLED");
				passwd_label.Sensitive=false;
				itaca_passwd_entry.Sensitive=false;
			}
		}
	}
}
