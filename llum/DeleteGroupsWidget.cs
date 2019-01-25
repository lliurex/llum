
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class DeleteGroupsWidget : Gtk.Bin
	{
		protected virtual void OnDeleteUsersCheckbuttonToggled (object sender, System.EventArgs e)
		{
			if(deleteUsersCheckbutton.Active)
			{
				userListTreeview.Sensitive=true;
				delete_checkbutton.Sensitive=true;
			}
			else
			{
			
				userListTreeview.Sensitive=false;
				delete_checkbutton.Sensitive=false;
				
			}
		}
		
		
		private System.Collections.Generic.List<LdapGroup> group_list;
		private System.Collections.Generic.List<LdapUser> user_list;
		
		
		public DeleteGroupsWidget (System.Collections.Generic.List<LdapGroup>list)
		{
			this.Build ();
			group_list=list;
			groupListTreeview.Selection.Mode=Gtk.SelectionMode.None;
			userListTreeview.Selection.Mode=Gtk.SelectionMode.None;
		
			System.Collections.Generic.List<LdapUser> ulist=llum.Core.getCore().xmlrpc.get_user_list();
			
			user_list=new System.Collections.Generic.List<LdapUser>();
			
			
			
			foreach(LdapUser user in ulist)
			{
				foreach(LdapGroup grp in group_list)	
				{
					if(grp.member_list.Contains(user.uid) && !user_list.Contains(user) && user.main_group!="admin")
						user_list.Add(user);
						
				}
			}
			
			
			
			
			Gtk.TreeViewColumn grp_id_column;
			Gtk.CellRendererText grp_id_cell;
			Gtk.TreeViewColumn grp_description_column;
			Gtk.CellRendererText grp_description_cell;			
			
			Gtk.TreeStore group_store;
			
			grp_id_column=new Gtk.TreeViewColumn();
			grp_id_column.Title=Mono.Unix.Catalog.GetString("Group ID");
			grp_id_cell=new Gtk.CellRendererText();
			grp_id_column.PackStart(grp_id_cell,true);
			grp_id_column.AddAttribute(grp_id_cell,"text",0);
			groupListTreeview.AppendColumn(grp_id_column);
			
			grp_description_column=new Gtk.TreeViewColumn();
			grp_description_column.Title=Mono.Unix.Catalog.GetString("Description");
			grp_description_cell=new Gtk.CellRendererText();
			grp_description_column.PackStart(grp_description_cell,true);
			grp_description_column.AddAttribute(grp_description_cell,"text",1);
			groupListTreeview.AppendColumn(grp_description_column);
			
			
			group_store=new Gtk.TreeStore(typeof(string),typeof(string));
			groupListTreeview.Model=group_store;
			
			foreach(LdapGroup grp in group_list)
				group_store.AppendValues(grp.gid,grp.description);
			
			
			Gtk.TreeViewColumn user_id_column;
			Gtk.CellRendererText user_id_cell_renderer;
		
			Gtk.TreeViewColumn user_name_column;
			Gtk.CellRendererText user_name_cell_renderer;
		
			Gtk.TreeViewColumn user_surname_column;
			Gtk.CellRendererText user_surname_cell_renderer;
		
			Gtk.ListStore store;			
			
			user_id_column=new Gtk.TreeViewColumn();
			user_id_column.Title=Mono.Unix.Catalog.GetString("User ID");
			user_id_cell_renderer=new Gtk.CellRendererText();
			user_id_column.PackStart(user_id_cell_renderer,true);
			user_id_column.AddAttribute(user_id_cell_renderer,"text",0);
			userListTreeview.AppendColumn(user_id_column);
			store=new Gtk.ListStore(typeof(string),typeof(string),typeof(string));
			userListTreeview.Model=store;
			
			user_name_column=new Gtk.TreeViewColumn();
			user_name_column.Title=Mono.Unix.Catalog.GetString("Name");
			user_name_cell_renderer=new Gtk.CellRendererText();
			user_name_column.PackStart(user_name_cell_renderer,true);
			user_name_column.AddAttribute(user_name_cell_renderer,"text",1);
			userListTreeview.AppendColumn(user_name_column);
			
			user_surname_column=new Gtk.TreeViewColumn();
			user_surname_column.Title=Mono.Unix.Catalog.GetString("Surname");
			user_surname_cell_renderer=new Gtk.CellRendererText();
			user_surname_column.PackEnd(user_surname_cell_renderer,true);
			user_surname_column.AddAttribute(user_surname_cell_renderer,"text",2);
			userListTreeview.AppendColumn(user_surname_column);
			
			
			foreach(LdapUser user in user_list)
				store.AppendValues(user.uid,user.name,user.surname);
			
			
			
			userListTreeview.ShowAll();			
			
			
		}
		protected virtual void OnAcceptButtonClicked (object sender, System.EventArgs e)
		{
			
			
			System.Threading.Thread thread=null;
			string msg="";
			if(deleteUsersCheckbutton.Active)
				msg=Mono.Unix.Catalog.GetString("Deleting groups and users...");
			else
				msg=Mono.Unix.Catalog.GetString("Deleting groups only...");
					
					
			llum.Core.getCore().progress_window=new ProgressWindow(msg);
			llum.Core.getCore().progress_window.ShowAll();
			llum.Core.getCore().progress_window.ShowNow();
			
			System.Threading.ThreadStart progressTStart = delegate 
			{
				llum.Core core=llum.Core.getCore();
				System.Collections.Generic.List<string> ret=new System.Collections.Generic.List<string>();
				bool error=false;
				// DELETE GROUPS
				foreach(LdapGroup grp in group_list)
				{
					
					string ret_str=core.xmlrpc.delete_group(grp.gid);
					ret.Add(grp.gid + ":" + ret_str + "\n");
					if(!ret_str.Contains("true"))
						error=true;
				}
				
				
				// DELETE USERS
				
				if(deleteUsersCheckbutton.Active)
				{
					Console.WriteLine("[DeleteGroupsWidget] Deleting users...");
					bool delete_data=this.delete_checkbutton.Active;
					foreach(LdapUser user in user_list)
					{
						string ret_str="";
						switch(user.main_group)
						{
							case "students":
								ret_str=core.xmlrpc.delete_student(user.uid,delete_data);
								break;
							case "teachers":
								ret_str=core.xmlrpc.delete_teacher(user.uid,delete_data);
								break;
							case "others":
								ret_str=core.xmlrpc.delete_other(user.uid,delete_data);
								break;
							default:
								break;
							
						}
						
						ret.Add(user.uid+":"+ret_str+"\n");
						if(!ret_str.Contains("true"))
							error=true;
					}
					
				}
				else
				{
					Console.WriteLine("[DeleteGroupsWidget] Users won't be removed");	
				}
				
				
				
				
				
				Gtk.Application.Invoke(delegate{
				
					string msg_label="";
					
					if(error)
					{
						msg_label="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Errors were found when deleting groups:") + "\n";
						foreach(string str in ret)
							msg_label+=str;
						msg_label+="</span>";
					}
					else
						msg_label="<b>" + Mono.Unix.Catalog.GetString("Group Deletion successful") + "</b>";
					
					msgLabel.Markup=msg_label;
					acceptButton.Sensitive=false;
					Core.getCore().progress_window.Hide();
				});				

			};
			
			thread=new System.Threading.Thread(progressTStart);
			thread.Start();

			
						
			
			
			

			
			
			
			
		}
		
		protected virtual void OnCancelButtonClicked (object sender, System.EventArgs e)
		{
			llum.Core core=llum.Core.getCore();
			
			core.search_group_wid=new SearchGroupWidget();
			core.mw.setCurrentWidget(core.search_group_wid);
			
			
		}
		
		
		
	}
}
