
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class DeleteUserWidget : Gtk.Bin
	{

		private System.Collections.Generic.List<llum.LdapUser> to_delete_user_list;
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
		
		
		
		private string back_to;
		
		public DeleteUserWidget (System.Collections.Generic.List<llum.LdapUser> user_list, string back_to )
		{
			this.Build ();
			this.back_to=back_to;
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
			
			to_delete_user_list=new System.Collections.Generic.List<llum.LdapUser>();
			foreach(llum.LdapUser user in user_list)
			{
				if(user.ok_to_delete)
				{
					store.AppendValues(user.uid,user.name,user.surname);
					to_delete_user_list.Add(user);	
				}
				else
				{
					if (safe_list!="")
						safe_list+=", ";
					
					safe_list+=user.uid;
					
				}
			}
			
			if(to_delete_user_list.Capacity<1)
				acceptButton.Sensitive=false;
			
			if(safe_list!="")
				msgLabel.Markup=Mono.Unix.Catalog.GetString("The following users were removed from the to-be-deleted list for security reasons") + ":\n" + safe_list;
			
			
		}
		
		protected virtual void OnAcceptButtonClicked (object sender, System.EventArgs e)
		{
			System.Threading.Thread thread=null;
			bool error=false;

			llum.Core.getCore().progress_window=new ProgressWindow(Mono.Unix.Catalog.GetString("Deleting users..."));
			llum.Core.getCore().progress_window.ShowAll();
			llum.Core.getCore().progress_window.ShowNow();
			
					
			bool delete_data=this.delete_checkbutton.Active;
			
			//thread2=new System.Threading.Thread(tstart);
			//thread2.Start();			
			
			System.Threading.ThreadStart progressTStart = delegate 
			{
			
											
											foreach(llum.LdapUser user in to_delete_user_list)
											{
												//Console.WriteLine("Deleting " + user.uid);	
												llum.Core core=llum.Core.getCore();
												
														
												string ret="";
													
												switch(user.main_group)
												{
													case "students":	
															
														ret=core.xmlrpc.delete_student(user.uid,delete_data);
															
														break;
															
													case "teachers":
															
														ret=core.xmlrpc.delete_teacher(user.uid,delete_data);
															
														break;
															
												}
														
												if (ret!="true")
												{
													Gtk.Application.Invoke(delegate{
																			msgLabel.Markup="<span foreground='red'> Error: " + ret + "</span>";
																			error=true;
																			
																			});
													break;
												}
						
												
				
											}
											if(!error)
											{
												Gtk.Application.Invoke(delegate{
												msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Deletion successful") + "</b>";
												acceptButton.Sensitive=false;
												cancelButton.Label=Mono.Unix.Catalog.GetString("Go back");
												
												});
											}					
											
											Core.getCore().progress_window.Hide();
											//thread2.Abort();
										

			};
			
			thread=new System.Threading.Thread(progressTStart);
			thread.Start();


			
			

			

			
		}
		
		
	}
}
