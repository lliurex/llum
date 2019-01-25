
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class DemoteUserWidget : Gtk.Bin
	{
		protected virtual void OnAcceptButtonClicked (object sender, System.EventArgs e)
		{
			llum.Core core=llum.Core.getCore();
			System.Collections.Generic.List<string> ret=new System.Collections.Generic.List<string>();
			string result;
			bool error=false;
			foreach(LdapUser user in to_demote_list)
			{
					result=core.xmlrpc.del_teacher_from_admins(user.uid);
					ret.Add(user.uid + ":" + result+"\n");
					if(!result.Contains("true"))
						error=true;
			}
			
			if(error)
			{
				string txt="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Some errors where found when executing the demoting operation:") + "\n";
				foreach(string str in ret)	
					txt+=str;
				
					
				txt+="</span>";
			}
			else
			{
				msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Users were succesfully demoted") + "</b>";
			}
			
			acceptButton.Sensitive=false;
			
		}
		
		
		private System.Collections.Generic.List<llum.LdapUser> user_list;
		private System.Collections.Generic.List<llum.LdapUser> to_demote_list;
		private string back_to;
		public DemoteUserWidget (System.Collections.Generic.List<LdapUser> user_list, string back_to)
		{
			this.Build ();
			this.back_to=back_to;
			this.user_list=user_list;
			userListTreeview.Selection.Mode=Gtk.SelectionMode.None;
			
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
			
			
			
			
			userListTreeview.ShowAll();
			
			string safe_list="";
			
			to_demote_list=new System.Collections.Generic.List<llum.LdapUser>();
			foreach(llum.LdapUser user in this.user_list)
			{
				if(user.main_group=="teachers")
				{
					store.AppendValues(user.uid,user.name,user.surname);
					to_demote_list.Add(user);	
				}
				else
				{
					if (safe_list!="")
						safe_list+=", ";
					
					safe_list+=user.uid;
					
				}
			}
			
			if(safe_list!="")
				msgLabel.Markup=Mono.Unix.Catalog.GetString("The following users were removed from the to-be-demoted list as they don't belong to the teachers group") + ":\n" + safe_list;
						
			if(to_demote_list.Capacity<1)
				acceptButton.Sensitive=false;			
			
			
		}
		protected virtual void OnCancelButtonClicked (object sender, System.EventArgs e)
		{
			llum.Core core=llum.Core.getCore();
			
			switch(back_to)
			{
				case "users":
				
					core.search_user=new SearchUser(false);
			
					core.mw.setCurrentWidget(core.search_user);			
					break;
				
				case "groups":
				
					core.search_group_wid=new SearchGroupWidget();
			
					core.mw.setCurrentWidget(core.search_group_wid);			
					break;
				
			}
			
			

			
			
			
			
			
		}
		
		
	}
}
