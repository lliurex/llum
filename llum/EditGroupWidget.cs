
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class EditGroupWidget : Gtk.Bin
	{

		

		protected virtual void OnFilterComboboxChanged (object sender, System.EventArgs e)
		{
			/*
			Gtk.TreeIter iter;
			filterCombobox.GetActiveIter(out iter);
			
			available_users_store.Clear();
			
			string ret=(string)combo_store.GetValue(iter,1);
			bool lets_add=true;
			foreach(LdapGroup grp in group_list)
			{
				if(grp.gid_number!=opened_group.gid_number)
				{
					if(ret=="%All%")
					{
						foreach(string user in grp.member_list)
						{
							foreach(string g_user in opened_group.member_list)
							{
								if (g_user==user)
								{
									lets_add=false;
									break;	
								}
							}
							if(lets_add)
								available_users_store.AppendValues(user);
							
							lets_add=true;
						
						}
					}
					else
					{
						if(grp.gid_number==ret)
						{
							foreach(string user in grp.member_list)
							{
								foreach(string g_user in opened_group.member_list)
								{
									if (g_user==user)
									{
										lets_add=false;
										break;	
									}
								}
								if(lets_add)
									available_users_store.AppendValues(user);
								
								lets_add=true;
							
							}
							
							break;
						}
												
					}
						
				}
			}

			*/
		}
		
		
		private System.Collections.Generic.List<llum.LdapGroup> group_list;
		private Gtk.ListStore combo_store;	
		
		
		private Gtk.TreeStore users_in_group_store;
		private Gtk.TreeStore available_users_store;
		private LdapGroup opened_group;
		
		public EditGroupWidget (LdapGroup grp)
		{
			
			this.Build ();
			
			applyPasswordButton.Sensitive=false;
			opened_group=grp;
			
			llum.Core core=llum.Core.getCore();
			gidLabel.Text=grp.gid;
			gidNumberLabel.Text=grp.gid_number;
			descriptionEntry.Text=grp.description;
			
			
			
			
			group_list=core.xmlrpc.get_available_groups_info();
			
			System.Collections.Generic.List<LdapUser> all_list=core.xmlrpc.light_get_user_list();
			
			System.Collections.Generic.List<string> usr_name=new System.Collections.Generic.List<string>();
			foreach(LdapUser u in all_list)
				usr_name.Add(u.uid);
			
			
			LdapGroup all_grp=new LdapGroup("[[ALL]]","1","1",usr_name,"");
			
			group_list.Insert(0,all_grp);
			combo_store=new Gtk.ListStore(typeof(string),typeof(string));
			
			

			
			combo_store.AppendValues(Mono.Unix.Catalog.GetString("All"),"%All%");
			
			
			
			
			
			
			foreach(LdapGroup tmp_grp in group_list)
			{
				if(tmp_grp.gid_number!=grp.gid_number)
				{
					combo_store.AppendValues(tmp_grp.gid,tmp_grp.gid_number);
				}
			}
			

			
			
			Gtk.TreeViewColumn users_in_group_column=new Gtk.TreeViewColumn();
			users_in_group_column.Title=Mono.Unix.Catalog.GetString("Users in this group");
			Gtk.CellRendererText users_in_group_cell=new Gtk.CellRendererText();
			users_in_group_column.PackStart(users_in_group_cell,true);
			users_in_group_column.AddAttribute(users_in_group_cell,"text",0);
			usersInGroupTreeview.AppendColumn(users_in_group_column);
			users_in_group_store=new Gtk.TreeStore(typeof(string));
			usersInGroupTreeview.Model=users_in_group_store;
			
			
			
			usersInGroupTreeview.Selection.Mode=Gtk.SelectionMode.Multiple;
			
			
			populate_users_treeview();
			
			Gtk.TreeViewColumn available_users_column=new Gtk.TreeViewColumn();
			available_users_column.Title=Mono.Unix.Catalog.GetString("Available users");
			Gtk.CellRendererText available_users_cell=new Gtk.CellRendererText();
			available_users_column.PackStart(available_users_cell,true);
			available_users_column.AddAttribute(available_users_cell,"text",0);
			otherUsersTreeview.AppendColumn(available_users_column); 
			
			available_users_store=new Gtk.TreeStore(typeof(string));
			otherUsersTreeview.Model=available_users_store;			

	
			
			otherUsersTreeview.Selection.Mode=Gtk.SelectionMode.Multiple;
			
			populate_others_treeview();

						
			
			
			
			
		}
		
		public void populate_users_treeview()
		{
			users_in_group_store.Clear();
			foreach(string str in opened_group.member_list)
				users_in_group_store.AppendValues(str);			
		}
		
		public void populate_others_treeview()
		{
			available_users_store.Clear();	
			foreach(LdapGroup grp2 in group_list)
			{
				if (grp2.gid!=opened_group.gid)
					if(grp2.member_list.Capacity>0)
					{
						Gtk.TreeIter iter;
						iter=available_users_store.AppendValues(grp2.gid);
						
						int count=0;
						foreach(string str in grp2.member_list)
						{
							if(!opened_group.member_list.Contains(str))
							{
								available_users_store.AppendValues(iter,str);
								count++;
							}
						}
						if(count==0)
							available_users_store.Remove(ref iter);
					}
			}
			
		}
		
		protected virtual void OnUndoButtonClicked (object sender, System.EventArgs e)
		{
			descriptionEntry.Text=opened_group.description;
		}
		
		protected virtual void OnApplyDescriptionButtonClicked (object sender, System.EventArgs e)
		{
			llum.Core core=llum.Core.getCore();
			
			string ret=core.xmlrpc.change_group_description(opened_group.gid,descriptionEntry.Text);
			
			if(ret=="true")
			{
				msgLabel.Text=Mono.Unix.Catalog.GetString("Description changed succesfully");
				opened_group.description=descriptionEntry.Text;
			}
			else
			{
				msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("There was an error changing group description") + ":\n" + ret + "</span>";
			}
			
		}
		

		
		protected virtual void OnDeleteUserButtonClicked (object sender, System.EventArgs e)
		{

			Gtk.TreeIter iter;
			Gtk.TreePath[] path_array=usersInGroupTreeview.Selection.GetSelectedRows();
			System.Collections.Generic.List<string> ret_list=new System.Collections.Generic.List<string>();
			System.Collections.Generic.List<string> user_list=new System.Collections.Generic.List<string>();
			llum.Core core=llum.Core.getCore();
			
			foreach(Gtk.TreePath path in path_array)
			{
				users_in_group_store.GetIter(out iter,path);

				
				if(opened_group.member_list.Contains((string)users_in_group_store.GetValue(iter,0)))
				{
							
					// LDAP OPERATION HERE
					string return_str=core.xmlrpc.remove_from_group((string)users_in_group_store.GetValue(iter,0),opened_group.gid);
					ret_list.Add(return_str);
						
					user_list.Add((string)users_in_group_store.GetValue(iter,0));					
					
					///////////////////////			
					opened_group.member_list.Remove((string)users_in_group_store.GetValue(iter,0));
					
				}
		
			}

			populate_others_treeview();
			populate_users_treeview();			
			string err="";
			bool error_found=false;
			int count=0;
			foreach(string str in ret_list)
			{
				
					if(!str.Contains("true"))
					{
						error_found=true;
						
						
						int count2=0;
						string user="";
						foreach(string str2 in user_list)
						{
							if(count2==count)
							{
								user=str2;
								break;
							}
							count2++;
							
						}
						err+=user + ": " + str + "\n";
						
						
					}
					count++;
						
			}
			
			if(!error_found)
				msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Users were removed from this group successfully") + "</b>";
			else
			{
				string msg="<span foreground='red'>" + Mono.Unix.Catalog.GetString("The following errors were returned: ") + err + "</span>";
				
				msgLabel.Markup=msg;
				
				
				
					
			}
		}
		
		protected virtual void OnAddUserButtonClicked (object sender, System.EventArgs e)
		{
			Gtk.TreeIter iter;
			
			Gtk.TreePath[] path_array=otherUsersTreeview.Selection.GetSelectedRows();
			
			llum.Core core=llum.Core.getCore();
			
			System.Collections.Generic.List<string> ret_list=new System.Collections.Generic.List<string>();
			System.Collections.Generic.List<string> user_list=new System.Collections.Generic.List<string>();
			
			foreach(Gtk.TreePath path in path_array)
			{
				available_users_store.GetIter(out iter,path);
				bool ok=true;
				
				foreach(LdapGroup grp in group_list)
				{
					if((string)available_users_store.GetValue(iter,0)==grp.gid)
						ok=false;
					
				}
				if(ok)
				{
					
					if(!opened_group.member_list.Contains((string)available_users_store.GetValue(iter,0)))
					{					
						//LDAP OPERATION HERE
						
						string return_str=core.xmlrpc.add_to_group((string)available_users_store.GetValue(iter,0),opened_group.gid);
						ret_list.Add(return_str);
						
						user_list.Add((string)available_users_store.GetValue(iter,0));
						
						/////////////////////
						if(return_str=="true")
							opened_group.member_list.Add((string)available_users_store.GetValue(iter,0));
							
						
					}
				
					
					
				}
			}
			populate_others_treeview();
			populate_users_treeview();			
			
			string err="";
			bool error_found=false;
			int count=0;
			foreach(string str in ret_list)
			{
				
					if(!str.Contains("true"))
					{
						error_found=true;
						
						
						int count2=0;
						string user="";
						foreach(string str2 in user_list)
						{
							if(count2==count)
							{
								user=str2;
								break;
							}
							count2++;
							
						}
						err+=user + ": " + str + "\n";
						
						
					}
					count++;
						
			}
			
			if(!error_found)
				msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Users were added to this group successfully") + "</b>";
			else
			{
				string msg="<span foreground='red'>" + Mono.Unix.Catalog.GetString("The following errors were returned: ") + err + "</span>";
				
				msgLabel.Markup=msg;
				
				
				
					
			}
			
					
		}
		
		protected virtual void OnApplyPasswordButtonClicked (object sender, System.EventArgs e)
		{
			llum.Core core=llum.Core.getCore();
			llum.Core.getCore().progress_window=new ProgressWindow(Mono.Unix.Catalog.GetString("Changing User passwords..."));
			llum.Core.getCore().progress_window.ShowAll();
			llum.Core.getCore().progress_window.ShowNow();
			
			System.Collections.Generic.List<string>ret=new System.Collections.Generic.List<string>();

			
			System.Threading.Thread thread=null;
			
			
			System.Threading.ThreadStart progressTStart = delegate 
			{
					
				System.Collections.Generic.List<LdapUser> user_list=core.xmlrpc.light_get_user_list();
				bool error=false;
				foreach(LdapUser user in user_list)
				{
					if(opened_group.member_list.Contains(user.uid))
					{
						string result=core.xmlrpc.change_password(user.path, passwordEntry.Text,false);
						ret.Add(user.uid+":"+result+"\n");
						if(!result.Contains("true"))
							error=true;
					}
				}
				
				string txt="";
				Gtk.Application.Invoke(delegate{
					if(!error)
					{
						msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Passwords were successfully changed") + "</b>";
						
					}
					else
					{
						
						txt="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Some errors were found when changing passwords:") + "\n" ;
						
						
						
						foreach(string str in ret)
							txt+=str;
						
						txt+="</span>";
						
						msgLabel.Markup=txt;
						
						
					}
					
					core.progress_window.Hide();
					
					});
				
								
				
				
				
										

			};
			
			thread=new System.Threading.Thread(progressTStart);
			thread.Start();


			
						
			
			
			
			
			
			
		}
		
		protected virtual void OnPasswordEntry2Changed (object sender, System.EventArgs e)
		{
			if(passwordEntry.Text==passwordEntry2.Text && passwordEntry.Text!="")
				applyPasswordButton.Sensitive=true;
			else
				applyPasswordButton.Sensitive=false;
		}
		
		protected virtual void OnPasswordEntryChanged (object sender, System.EventArgs e)
		{
			if(passwordEntry.Text==passwordEntry2.Text && passwordEntry.Text!="")
				applyPasswordButton.Sensitive=true;
			else
				applyPasswordButton.Sensitive=false;			
		}
		
		
		
		

		
		
		
		
		
		
		
	}
}
