
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class SearchUser : Gtk.Bin
	{
		
		public System.Collections.Generic.List<LdapUser> user_list;
		public System.Collections.Generic.List<LdapUser> selected_user_list;
		

		
		
		public void populate_treeview(string filter)
		{
		
			string def_filter;
			string main_group;
			
			if(filter.Contains("*"))
			   def_filter=filter.Replace("*","");
			else
				def_filter=filter.ToLower();
			
			if(def_filter.Length>0 || (filter.Contains("*")))
				
				foreach(LdapUser user in user_list)
				{
				
					main_group=user.main_group;
				
					//Console.WriteLine (user.main_group);
				
					if(user.main_group=="teachers")
						if(user.is_admin)
							main_group="promoted-teachers";
					
					
						
					if(user.name.Contains(def_filter) || user.name.ToLower().Contains(def_filter) || user.surname.Contains(def_filter) || user.surname.ToLower().Contains(def_filter) || user.uid.Contains(def_filter))
						if(user.is_admin)
						{
							store.AppendValues(user.uid,main_group,user.name,user.surname,"#a72700");
							
						}
						else
						{
							store.AppendValues(user.uid,main_group,user.name,user.surname,"#000000");
							
						}

					
				}
			
			
			
		}
		
		
		protected virtual void OnSearchEntryChanged (object sender, System.EventArgs e)
		{
			store.Clear();
			

			if(!thread.IsAlive)
			{
				populate_treeview(searchEntry.Text);
				
			}
			
			
		}

		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			llum.Core.getCore().search_user=new SearchUser(false);
			
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().search_user);
		}		
		
		
		public Gtk.Label label;
		public Gtk.Image image;
		
		
		
		public Gtk.TreeViewColumn user_id_column;
		public Gtk.CellRendererText user_id_cell_renderer;
		public Gtk.ListStore store;
		public System.Threading.Thread thread;
		
		public Gtk.TreeViewColumn user_group_column;
		
		public SearchUser (bool from_core)
		{
			this.Build ();
			
			searchImage.Animation=new Gdk.PixbufAnimation(null,"llum.watch.gif");
			
			searchEntry.Sensitive=false;
			
			
			
			System.Threading.ThreadStart tstart=delegate{
			
			//user_list=llum.Core.getCore().xmlrpc.light_get_user_list();
				
				user_list=llum.Core.getCore().xmlrpc.get_user_list();

			
				Gtk.Application.Invoke(delegate{
					if (user_list==null)
						msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("There was an error connecting to the n4d(XMLRPC) server") + "</span>";
					else
						msgLabel.Text="";
					searchEntry.Sensitive=true;
					searchImage.Visible=false;
					
				});
				
				
				
			};
			
			thread=new System.Threading.Thread(tstart);
			
			if(!from_core)
				thread.Start();
			
			
			editButton.Sensitive=false;
			promoteButton.Sensitive=false;
			
			
			
			userTreeview.Selection.Mode=Gtk.SelectionMode.Multiple;
			image=new Gtk.Image();
			image.SetFromIconName("system-search",Gtk.IconSize.Dnd);
			
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Search User"));
			label.Show();			

			store=new Gtk.ListStore(typeof(string),typeof(string),typeof(string),typeof(string),typeof(string));
			store.SetSortFunc(0,sort_users);
			store.SetSortFunc(1,sort_groups);
			userTreeview.Model=store;
			
			user_group_column=new Gtk.TreeViewColumn();
			user_group_column.Title=Mono.Unix.Catalog.GetString("User ID");
			user_group_column.Clickable=true;
			user_group_column.SortIndicator = true;
			user_group_column.Clicked+=user_id_column_clicked;
			
			
			
			Gtk.CellRendererText user_group_cell_renderer=new Gtk.CellRendererText();
			user_group_column.PackStart(user_group_cell_renderer,true);
			user_group_column.AddAttribute(user_group_cell_renderer,"text",0);
			user_group_column.AddAttribute(user_group_cell_renderer,"foreground",4);
			userTreeview.AppendColumn(user_group_column);					
			
			user_id_column=new Gtk.TreeViewColumn();
			user_id_column.Title=Mono.Unix.Catalog.GetString("Group");
			user_id_cell_renderer=new Gtk.CellRendererText();
			user_id_column.PackStart(user_id_cell_renderer,true);
			user_id_column.AddAttribute(user_id_cell_renderer,"text",1);
			userTreeview.AppendColumn(user_id_column);
			user_id_column.Clickable=true;
			user_id_column.SortIndicator=true;
			user_id_column.Clicked+=user_group_column_clicked;
			
			
			
			Gtk.TreeViewColumn user_name_column=new Gtk.TreeViewColumn();
			user_name_column.Title=Mono.Unix.Catalog.GetString("Name");
			Gtk.CellRendererText user_name_cell_renderer=new Gtk.CellRendererText();
			user_name_column.PackStart(user_name_cell_renderer,true);
			user_name_column.AddAttribute(user_name_cell_renderer,"text",2);
			userTreeview.AppendColumn(user_name_column);
			
			Gtk.TreeViewColumn user_surname_column=new Gtk.TreeViewColumn();
			user_surname_column.Title=Mono.Unix.Catalog.GetString("Surname");
			Gtk.CellRendererText user_surname_cell_renderer=new Gtk.CellRendererText();
			user_surname_column.PackEnd(user_surname_cell_renderer,true);
			user_surname_column.AddAttribute(user_surname_cell_renderer,"text",3);
			userTreeview.AppendColumn(user_surname_column);
			
			
			
			
			userTreeview.ShowAll();

			
			
			
			
		}
		
		private void user_id_column_clicked(object o, EventArgs args)
		{
			
			if(user_group_column.SortOrder==Gtk.SortType.Ascending)
				user_group_column.SortOrder=Gtk.SortType.Descending;
			else
				user_group_column.SortOrder=Gtk.SortType.Ascending;
			
			store.SetSortColumnId(0, user_group_column.SortOrder);
		}
		
		
		private int sort_users(Gtk.TreeModel model,Gtk.TreeIter a,Gtk.TreeIter b)
		{
			
			return String.Compare ((string) model.GetValue (a, 0),(string) model.GetValue (b, 0));
			
		}
		
		private void user_group_column_clicked(object o, EventArgs args)
		{
			
			if(user_id_column.SortOrder==Gtk.SortType.Ascending)
				user_id_column.SortOrder=Gtk.SortType.Descending;
			else
				user_id_column.SortOrder=Gtk.SortType.Ascending;
			
			store.SetSortColumnId(1, user_id_column.SortOrder);
		}
		
		private int sort_groups(Gtk.TreeModel model,Gtk.TreeIter a, Gtk.TreeIter b)
		{
			return String.Compare ((string) model.GetValue (a, 1),(string) model.GetValue (b, 1));
		}
		
		protected virtual void OnEditButtonClicked (object sender, System.EventArgs e)
		{
			
			//userTreeview.Selection.GetSelected(out iter);
			
			Gtk.TreePath[] path_array=userTreeview.Selection.GetSelectedRows();
			
			if(path_array.Length==1)
			{
				Gtk.TreeIter iter;
				store.GetIter(out iter,path_array[0]);
				//Console.WriteLine(store.GetValue(iter,0));
				LdapUser return_user=null;
				foreach(LdapUser user in user_list)
				{
					if (user.uid==(string)store.GetValue(iter,0))
					{
						return_user=user;
						break;	
					}
				}
				
				llum.Core core=llum.Core.getCore();
				
				core.edit_user_wid=new EditUser(return_user);
				core.mw.setCurrentWidget(core.edit_user_wid);
				
			}

			
		}
		
		protected virtual void OnUserTreeviewRowActivated (object o, Gtk.RowActivatedArgs args)
		{

		}
		
		protected virtual void OnUserTreeviewCursorChanged (object sender, System.EventArgs e)
		{

		}
		
		protected virtual void OnUserTreeviewButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
		{
		

		}

		[GLib.ConnectBefore]
		protected virtual void OnUserTreeviewButtonReleaseEvent (object o, Gtk.ButtonReleaseEventArgs args)
		{
			
			Gtk.TreePath[] path_array=userTreeview.Selection.GetSelectedRows();
			//Console.WriteLine(path_array.Length);	
			if(path_array.Length==1)
			{			
			
				editButton.Sensitive=true;
				
			
			}
			else
			{
				editButton.Sensitive=false;
				
			}
			
			if(path_array.Length>0)
			{
				deleteUsersButton.Sensitive=true;
				promoteButton.Sensitive=true;
				demoteButton.Sensitive=true;
			}
			else
			{
				deleteUsersButton.Sensitive=false;
				promoteButton.Sensitive=false;
				demoteButton.Sensitive=false;
			}
		}
		
		protected virtual void OnDeleteUsersButtonClicked (object sender, System.EventArgs e)
		{
			
			Gtk.TreePath[] path_array=userTreeview.Selection.GetSelectedRows();
			
			selected_user_list=new System.Collections.Generic.List<llum.LdapUser>();
			
			foreach(Gtk.TreePath path in path_array)
			{
				Gtk.TreeIter iter;
				store.GetIter(out iter,path);	
				
				string uid=(string)store.GetValue(iter,0);
				
				foreach(llum.LdapUser u in user_list)
				{
					if(u.uid==uid)
					{
						switch(u.main_group)
						{
							case "students":	
								u.ok_to_delete=true;
								
								break;
							case "teachers":
								if(llum.Core.getCore().user_group=="admin" || llum.Core.getCore().user_group=="promoted-teacher" )
									u.ok_to_delete=true;
								else
									u.ok_to_delete=false;
								break;
							
							case "admin":
								u.ok_to_delete=false;
								break;
							
							case "others":
								u.ok_to_delete=true;
								break;
							
								
							
							
						}
						selected_user_list.Add(u);
						
					}
				}
				
				
				
			}
			
			llum.Core core=llum.Core.getCore();
			
			core.delete_users_wid=new DeleteUserWidget(selected_user_list,"users");
			core.mw.setCurrentWidget(core.delete_users_wid);
			
			
		}
		
		protected virtual void OnPromoteButtonClicked (object sender, System.EventArgs e)
		{
			Gtk.TreePath[] path_array=userTreeview.Selection.GetSelectedRows();
			
			selected_user_list=new System.Collections.Generic.List<llum.LdapUser>();
			
			foreach(Gtk.TreePath path in path_array)
			{
				Gtk.TreeIter iter;
				store.GetIter(out iter,path);	
				
				string uid=(string)store.GetValue(iter,0);
				
				foreach(llum.LdapUser u in user_list)
				{
					if(u.uid==uid)
					{
						selected_user_list.Add(u);
						
					}
				}			
			}
			
			llum.Core core=llum.Core.getCore();
			
			
			
			core.promote_users_wid=new PromoteUserWidget(selected_user_list,"users");
			core.mw.setCurrentWidget(core.promote_users_wid);
			
			
			
			
		}
		
		protected virtual void OnDemoteButtonClicked (object sender, System.EventArgs e)
		{
			Gtk.TreePath[] path_array=userTreeview.Selection.GetSelectedRows();
			
			selected_user_list=new System.Collections.Generic.List<llum.LdapUser>();
			
			foreach(Gtk.TreePath path in path_array)
			{
				Gtk.TreeIter iter;
				store.GetIter(out iter,path);	
				
				string uid=(string)store.GetValue(iter,0);
				
				foreach(llum.LdapUser u in user_list)
				{
					if(u.uid==uid)
					{
						selected_user_list.Add(u);
						
					}
				}			
			}
			
			llum.Core core=llum.Core.getCore();
			
			core.demote_users_wid=new DemoteUserWidget(selected_user_list,"users");
			core.mw.setCurrentWidget(core.demote_users_wid);
			
			
		}
		
		
		
		
		
		
		
		
		
	}
}
