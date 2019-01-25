
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class FreezeWidget : Gtk.Bin
	{
		public Gtk.Image image;
		public Gtk.Label label;
		
		public Gtk.TreeStore available_groups_store;
		public Gtk.TreeStore available_users_store;
		public Gtk.TreeStore frozen_groups_store;
		public Gtk.TreeStore frozen_users_store;
		
		private System.Collections.Generic.List<llum.LdapGroup> group_list;
		private System.Collections.Generic.List<llum.LdapUser> user_list;
		private System.Collections.Generic.List<string> group_list_str;
		private System.Collections.Generic.List<string> user_list_str;
		
		public FreezeWidget ()
		{
			this.Build ();
			msgLabel.Text="";
			
			image=new Gtk.Image();
			image.SetFromIconName("stock_frozen_person",Gtk.IconSize.Dnd);
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Freeze Users"));
			label.Show();
			
			searchImage.Animation=new Gdk.PixbufAnimation(null,"llum.watch.gif");
			
			Gtk.TreeViewColumn available_groups_column=new Gtk.TreeViewColumn();
			available_groups_column.Title=Mono.Unix.Catalog.GetString("Available groups");
			Gtk.CellRendererText available_groups_cell=new Gtk.CellRendererText();
			available_groups_column.PackStart(available_groups_cell,true);
			available_groups_column.AddAttribute(available_groups_cell,"text",0);
			availableGroupsTreeview.AppendColumn(available_groups_column); 
			available_groups_store=new Gtk.TreeStore(typeof(string));
			availableGroupsTreeview.Model=available_groups_store;			
			availableGroupsTreeview.Selection.Mode=Gtk.SelectionMode.Multiple;
			
			
			Gtk.TreeViewColumn frozen_groups_column=new Gtk.TreeViewColumn();
			frozen_groups_column.Title=Mono.Unix.Catalog.GetString("Frozen groups");
			Gtk.CellRendererText frozen_groups_cell=new Gtk.CellRendererText();
			frozen_groups_column.PackStart(frozen_groups_cell,true);
			frozen_groups_column.AddAttribute(frozen_groups_cell,"text",0);
			frozenGroupsTreeview.AppendColumn(frozen_groups_column); 
			frozen_groups_store=new Gtk.TreeStore(typeof(string));
			frozenGroupsTreeview.Model=frozen_groups_store;			
			frozenGroupsTreeview.Selection.Mode=Gtk.SelectionMode.Multiple;			
			
			
			
			
			Gtk.TreeViewColumn available_users_column=new Gtk.TreeViewColumn();
			available_users_column.Title=Mono.Unix.Catalog.GetString("Available users");
			Gtk.CellRendererText available_users_cell=new Gtk.CellRendererText();
			available_users_column.PackStart(available_users_cell,true);
			available_users_column.AddAttribute(available_users_cell,"text",0);
			availableUsersTreeview.AppendColumn(available_users_column); 
			available_users_store=new Gtk.TreeStore(typeof(string));
			availableUsersTreeview.Model=available_users_store;			
			availableUsersTreeview.Selection.Mode=Gtk.SelectionMode.Multiple;

			
			Gtk.TreeViewColumn frozen_users_column=new Gtk.TreeViewColumn();
			frozen_users_column.Title=Mono.Unix.Catalog.GetString("Frozen users");
			Gtk.CellRendererText frozen_users_cell=new Gtk.CellRendererText();
			frozen_users_column.PackStart(frozen_users_cell,true);
			frozen_users_column.AddAttribute(frozen_users_cell,"text",0);
			frozenUsersTreeview.AppendColumn(frozen_users_column); 
			frozen_users_store=new Gtk.TreeStore(typeof(string));
			frozenUsersTreeview.Model=frozen_users_store;			
			frozenUsersTreeview.Selection.Mode=Gtk.SelectionMode.Multiple;					
			
			
			disable_gui();
			
			System.Threading.ThreadStart tstart=delegate{
			
				group_list=llum.Core.getCore().xmlrpc.get_available_groups_info();
				group_list_str=new System.Collections.Generic.List<string>();
				foreach(llum.LdapGroup grp in group_list)
					group_list_str.Add(grp.gid);
			
				user_list=llum.Core.getCore().xmlrpc.get_user_list();
				
				user_list_str=new System.Collections.Generic.List<string>();
				foreach(llum.LdapUser user in user_list)
				{
					if(user.main_group=="students")
						user_list_str.Add(user.uid);		
				}
				
			
				Gtk.Application.Invoke(delegate{
					if (user_list==null)
						msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("There was an error connecting to the n4d(XMLRPC) server") + "</span>";
					else
						msgLabel.Text="";
					enable_gui();
					searchImage.Visible=false;
					try
					{
						populate_available_groups_treeview();
						populate_available_users_treeview();
					}
					catch(Exception e)
					{
						Console.WriteLine(e);
					}
					
				});
				
				
				
				
			};
			
			System.Threading.Thread thread=new System.Threading.Thread(tstart);
			
			thread.Start();
			
			
		}
		
		public void disable_gui()
		{
			availableGroupsTreeview.Sensitive=false;
			availableUsersTreeview.Sensitive=false;
			frozenGroupsTreeview.Sensitive=false;
			frozenUsersTreeview.Sensitive=false;
			freezeGroupButton.Sensitive=false;
			freezeUserButton.Sensitive=false;
			unfreezeGroupButton.Sensitive=false;
			unfreezeUserButton.Sensitive=false;
		}
		
		public void enable_gui()
		{
			availableGroupsTreeview.Sensitive=true;
			availableUsersTreeview.Sensitive=true;
			frozenGroupsTreeview.Sensitive=true;
			frozenUsersTreeview.Sensitive=true;
			freezeGroupButton.Sensitive=true;
			freezeUserButton.Sensitive=true;
			unfreezeGroupButton.Sensitive=true;
			unfreezeUserButton.Sensitive=true;
		}
		
		public void populate_available_users_treeview()
		{
			available_users_store.Clear();
			frozen_users_store.Clear();
			
			System.Collections.Generic.List<string> frozen_users=llum.Core.getCore().xmlrpc.get_frozen_users();
			foreach(string user in frozen_users)
				frozen_users_store.AppendValues(user);
			
			foreach(LdapUser user in user_list)
			{
				if(!frozen_users.Contains(user.uid) && user.main_group=="students")
					available_users_store.AppendValues(user.uid);	
			}
			
		}
		
		
		public void populate_available_groups_treeview()
		{
			
			available_groups_store.Clear();	
			frozen_groups_store.Clear();
			
		
			
			System.Collections.Generic.List<string> frozen_groups=llum.Core.getCore().xmlrpc.get_frozen_groups();
			
			foreach(string frozen_group in frozen_groups)
			{
				frozen_groups_store.AppendValues(frozen_group);	
			}

			foreach(string grp in group_list_str)
			{
				if(!frozen_groups.Contains(grp))
					available_groups_store.AppendValues(grp);	
			}
			

			
		}		
		
		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			llum.Core.getCore().freeze_wid=new FreezeWidget();
			
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().freeze_wid);
		}		
		
		protected virtual void OnFreezeGroupButtonClicked (object sender, System.EventArgs e)
		{
			System.Collections.Generic.Dictionary<string,bool> ret=new System.Collections.Generic.Dictionary<string, bool>();
			
			foreach(Gtk.TreePath path in availableGroupsTreeview.Selection.GetSelectedRows())
			{
					Gtk.TreeIter iter=new Gtk.TreeIter();
					available_groups_store.GetIter(out iter,path);
					string cn=(string)(available_groups_store.GetValue(iter,0));
					ret[cn]=llum.Core.getCore().xmlrpc.freeze_group(cn);
					
			}
			
			bool ok=true;
			string error_list="";
			foreach(System.Collections.Generic.KeyValuePair<string,bool> tmp in ret)
			{
				if(!tmp.Value)
				{
					ok=false;
					error_list+=" - " + tmp.Key + "\n";
				}
			}
			
			if(ok)
				msgLabel.Markup=Mono.Unix.Catalog.GetString("Groups have been frozen successfully");
			else
				msgLabel.Markup=Mono.Unix.Catalog.GetString("The following groups couldn't get frozen:") + "\n" + error_list;
			
			populate_available_groups_treeview();
			
		}
		
		protected virtual void OnUnfreezeGroupButtonClicked (object sender, System.EventArgs e)
		{
			System.Collections.Generic.Dictionary<string,bool> ret=new System.Collections.Generic.Dictionary<string, bool>();
			
			foreach(Gtk.TreePath path in frozenGroupsTreeview.Selection.GetSelectedRows())
			{
					Gtk.TreeIter iter=new Gtk.TreeIter();
					frozen_groups_store.GetIter(out iter,path);
					string cn=(string)frozen_groups_store.GetValue(iter,0);
					ret[cn]=llum.Core.getCore().xmlrpc.unfreeze_group(cn);
					
			}
			
			bool ok=true;
			string error_list="";
			foreach(System.Collections.Generic.KeyValuePair<string,bool> tmp in ret)
			{
				if(!tmp.Value)
				{
					ok=false;
					error_list+=" - " + tmp.Key + "\n";
				}
			}
			
			if(ok)
				msgLabel.Markup=Mono.Unix.Catalog.GetString("Groups have been unfrozen successfully");
			else
				msgLabel.Markup=Mono.Unix.Catalog.GetString("The following groups couldn't get unfrozen:") + "\n" + error_list;
			
			populate_available_groups_treeview();
		}
		
		protected virtual void OnFreezeUserButtonClicked (object sender, System.EventArgs e)
		{
			System.Collections.Generic.Dictionary<string,bool> ret=new System.Collections.Generic.Dictionary<string, bool>();
			
			foreach(Gtk.TreePath path in availableUsersTreeview.Selection.GetSelectedRows())
			{
					Gtk.TreeIter iter=new Gtk.TreeIter();
					available_users_store.GetIter(out iter,path);
					string uid=(string)available_users_store.GetValue(iter,0);
					ret[uid]=llum.Core.getCore().xmlrpc.freeze_user(uid);
					
			}
			
			bool ok=true;
			string error_list="";
			foreach(System.Collections.Generic.KeyValuePair<string,bool> tmp in ret)
			{
				if(!tmp.Value)
				{
					ok=false;
					error_list+=" - " + tmp.Key + "\n";
				}
			}
			
			if(ok)
				msgLabel.Markup=Mono.Unix.Catalog.GetString("Users have been frozen successfully");
			else
				msgLabel.Markup=Mono.Unix.Catalog.GetString("The following users couldn't get frozen:") + "\n" + error_list;
			
			populate_available_users_treeview();				
		}
		
		protected virtual void OnUnfreezeUserButtonClicked (object sender, System.EventArgs e)
		{
			System.Collections.Generic.Dictionary<string,bool> ret=new System.Collections.Generic.Dictionary<string, bool>();
			
			foreach(Gtk.TreePath path in frozenUsersTreeview.Selection.GetSelectedRows())
			{
					Gtk.TreeIter iter=new Gtk.TreeIter();
					frozen_users_store.GetIter(out iter,path);
					string uid=(string)frozen_users_store.GetValue(iter,0);
					ret[uid]=llum.Core.getCore().xmlrpc.unfreeze_user(uid);
					
			}
			
			bool ok=true;
			string error_list="";
			foreach(System.Collections.Generic.KeyValuePair<string,bool> tmp in ret)
			{
				if(!tmp.Value)
				{
					ok=false;
					error_list+=" - " + tmp.Key + "\n";
				}
			}
			
			if(ok)
				msgLabel.Markup=Mono.Unix.Catalog.GetString("Users have been unfrozen successfully");
			else
				msgLabel.Markup=Mono.Unix.Catalog.GetString("The following users couldn't get unfrozen:") + "\n" + error_list;
			
			populate_available_users_treeview();
		}
		
		
		
		
		
	}
}
