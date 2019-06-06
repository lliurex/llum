
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class SearchGroupWidget : Gtk.Bin
	{
		
		private System.Collections.Generic.List<llum.LdapGroup> group_list;
		

		
		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{

			llum.Core.getCore().search_group_wid=new SearchGroupWidget();
			
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().search_group_wid);
		}			
		
		
		
		protected virtual void OnSearchEntryChanged (object sender, System.EventArgs e)
		{
			store.Clear();
			
			
			llum.Core core=llum.Core.getCore();
			
			group_list=core.xmlrpc.get_available_groups_info();
			string filter;
			if(searchEntry.Text.Contains("*"))
				filter=searchEntry.Text.ToLower().Replace("*","");
			else
				filter=searchEntry.Text.ToLower();
			
				
			foreach(llum.LdapGroup grp in group_list)
			{
				
				
				
				
				//if((searchEntry.Text.ToLower().Contains(grp.description.ToLower())) || (searchEntry.Text.ToLower().Contains(grp.gid.ToLower())))
				if( grp.description.ToLower().Contains(filter) || grp.gid.Contains(filter))
					store.AppendValues(grp.gid,grp.description);	 
				
				
			}
			
			
			
			
		}
		
		public Gtk.Label label;
		public Gtk.Image image;		
		public Gtk.TreeViewColumn user_id_column;
		public Gtk.CellRendererText user_id_cell_renderer;
		public Gtk.ListStore store;
		
		public SearchGroupWidget ()
		{
			this.Build ();
			image=new Gtk.Image();
			image.SetFromIconName("system-search",Gtk.IconSize.Dnd);
			
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Search Group"));
			label.Show();		
			
			userTreeview.Selection.Mode=Gtk.SelectionMode.Multiple;
		
			
			user_id_column=new Gtk.TreeViewColumn();
			user_id_column.Title=Mono.Unix.Catalog.GetString("Group ID");
			user_id_cell_renderer=new Gtk.CellRendererText();
			user_id_column.PackStart(user_id_cell_renderer,true);
			user_id_column.AddAttribute(user_id_cell_renderer,"text",0);
			userTreeview.AppendColumn(user_id_column);
			store=new Gtk.ListStore(typeof(string),typeof(string));
			userTreeview.Model=store;
			
			Gtk.TreeViewColumn user_name_column=new Gtk.TreeViewColumn();
			user_name_column.Title=Mono.Unix.Catalog.GetString("Description");
			Gtk.CellRendererText user_name_cell_renderer=new Gtk.CellRendererText();
			user_name_column.PackStart(user_name_cell_renderer,true);
			user_name_column.AddAttribute(user_name_cell_renderer,"text",1);
			userTreeview.AppendColumn(user_name_column);
			userTreeview.ShowAll();			
			
			//store.AppendValues("a","b");			
			
			
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
				deleteGroupsButton.Sensitive=true;
				deleteUsersButton.Sensitive=true;
				promoteButton.Sensitive=true;
				demoteUsersButton.Sensitive=true;
			}
			else
			{
				deleteGroupsButton.Sensitive=false;
				promoteButton.Sensitive=false;
				demoteUsersButton.Sensitive=false;
				deleteUsersButton.Sensitive=false;
			}			
		}
		
		protected virtual void OnEditButtonClicked (object sender, System.EventArgs e)
		{
			Gtk.TreePath[] path_array=userTreeview.Selection.GetSelectedRows();
			
			if(path_array.Length==1)
			{
				Gtk.TreeIter iter;
				store.GetIter(out iter,path_array[0]);
				//Console.WriteLine(store.GetValue(iter,0));
				LdapGroup return_group=null;
				foreach(LdapGroup grp in group_list)
				{
					if (grp.gid==(string)store.GetValue(iter,0))
					{
						return_group=grp;
						break;	
					}
				}
				
				
				
				llum.Core core=llum.Core.getCore();
				/*
				core.edit_user_wid=new EditUser(return_user);
				core.mw.setCurrentWidget(core.edit_user_wid);
				*/
				core.edit_group_wid=new EditGroupWidget(return_group);
				core.mw.setCurrentWidget(core.edit_group_wid);
				
			}
			
			
		
		}
		
		protected virtual void OnDeleteUsersButtonClicked (object sender, System.EventArgs e)
		{
			
			llum.Core core=llum.Core.getCore();
			System.Collections.Generic.List<LdapUser> delete_user_list=new System.Collections.Generic.List<LdapUser>();
			System.Collections.Generic.List<LdapUser> user_list=core.xmlrpc.get_user_list();
			
			
			
			Gtk.TreePath[] path_array=userTreeview.Selection.GetSelectedRows();
			
			
			System.Collections.Generic.List<string> grp_user_list=new System.Collections.Generic.List<string>();
			
			foreach(Gtk.TreePath path in path_array)
			{
			
				Gtk.TreeIter iter;
				store.GetIter(out iter,path);
				
				string gid=(string)store.GetValue(iter,0);
				
				foreach(LdapGroup grp in group_list)
				{
					if(grp.gid==gid)
					{
						foreach(string str in grp.member_list)
						{
							if(!grp_user_list.Contains(str))
								grp_user_list.Add(str);
							
						}
						
						break;
					}
				}
				
				
		
			}
			
			foreach(string str in grp_user_list)
			{
				foreach(LdapUser user in user_list)
				{
					if(user.uid==str)
					{
						if(user.main_group=="students" || user.main_group=="teachers")
							user.ok_to_delete=true;
						delete_user_list.Add(user);
						break;
					}
				}
			}
			
			core.delete_users_wid=new DeleteUserWidget(delete_user_list,"groups");
			core.mw.setCurrentWidget(core.delete_users_wid);
			
			
			
		}
		
		protected virtual void OnDeleteGroupsButtonClicked (object sender, System.EventArgs e)
		{
			
			Gtk.TreePath[] path_array=userTreeview.Selection.GetSelectedRows();
			System.Collections.Generic.List<LdapGroup>return_group_list=new System.Collections.Generic.List<llum.LdapGroup>();
			
			
			foreach(Gtk.TreePath path in path_array)
			{
				Gtk.TreeIter iter;
				store.GetIter(out iter,path);
				string gid=(string)store.GetValue(iter,0);
				
				foreach(LdapGroup grp in group_list)
				{
					if(grp.gid==gid)
					{
						return_group_list.Add(grp);
						break;	
					}
				}
					
				
				
			}
			
			
			
			
			llum.Core core=llum.Core.getCore();
			core.delete_groups_wid=new DeleteGroupsWidget(return_group_list);
			
			core.mw.setCurrentWidget(core.delete_groups_wid);
			
		}
		
		protected virtual void OnDemoteUsersButtonClicked (object sender, System.EventArgs e)
		{
			Gtk.TreePath[] path_array=userTreeview.Selection.GetSelectedRows();
			
			System.Collections.Generic.List<LdapUser> user_list=llum.Core.getCore().xmlrpc.get_user_list();
			System.Collections.Generic.List<LdapUser> ret_user_list=new System.Collections.Generic.List<LdapUser>();
			
			foreach(Gtk.TreePath path in path_array)
			{
				Gtk.TreeIter iter;
				store.GetIter(out iter, path);
				string gid=(string)store.GetValue(iter,0);
				foreach(LdapGroup grp in group_list)
				{
					if(grp.gid==gid)
					{
						foreach(string user in grp.member_list)
						{
							foreach(LdapUser luser in user_list)
							{
								if(luser.uid==user)	
								{
									ret_user_list.Add(luser);
									break;
								}
							}
						}
						break;
					}
				}
			}
			
			llum.Core core=llum.Core.getCore();
			
			core.demote_users_wid=new DemoteUserWidget(ret_user_list,"groups");
			core.mw.setCurrentWidget(core.demote_users_wid);
			
		}
		
		protected virtual void OnPromoteButtonClicked (object sender, System.EventArgs e)
		{
			Gtk.TreePath[] path_array=userTreeview.Selection.GetSelectedRows();
			
			System.Collections.Generic.List<LdapUser> user_list=llum.Core.getCore().xmlrpc.get_user_list();
			System.Collections.Generic.List<LdapUser> ret_user_list=new System.Collections.Generic.List<LdapUser>();
			
			foreach(Gtk.TreePath path in path_array)
			{
				Gtk.TreeIter iter;
				store.GetIter(out iter, path);
				string gid=(string)store.GetValue(iter,0);
				foreach(LdapGroup grp in group_list)
				{
					if(grp.gid==gid)
					{
						foreach(string user in grp.member_list)
						{
							foreach(LdapUser luser in user_list)
							{
								if(luser.uid==user)	
								{
									ret_user_list.Add(luser);
									break;
								}
							}
						}
						break;
					}
				}
			}
			
			llum.Core core=llum.Core.getCore();
			
			core.promote_users_wid=new PromoteUserWidget(ret_user_list,"groups");
			core.mw.setCurrentWidget(core.promote_users_wid);
			
			
		}
		
		
		
		
		
		
		
	}
}
