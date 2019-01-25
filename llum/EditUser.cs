
using System;
using System.Text;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class EditUser : Gtk.Bin
	{
		public LdapUser user;
		public Gtk.TreeStore available_store;
		public Gtk.TreeStore belong_store;

		public EditUser (LdapUser user)
		{
			this.Build ();
			
			
			
			this.user=user;
			
			if ((llum.Core.getCore().user_group!="admin") && (llum.Core.getCore().user_group!="promoted-teacher") )
			{
					//expander1.Sensitive=false;
					nameEntry.Sensitive=false;
					surnameEntry.Sensitive=false;
					undoButton.Sensitive=false;
					applyButton.Sensitive=false;
					addGroupButton.Sensitive=false;
					removeGroupButton.Sensitive=false;
						
				
			}
			
			if(this.user.main_group=="admin")
				expander1.Sensitive=false;
			
			
			uidLabel.Text=user.uid;
			uidNumLabel.Text=user.uidn;
			groupLabel.Text=user.main_group;
			
			nameEntry.Text=user.name;
			surnameEntry.Text=user.surname;
			//changePasswordButton.Sensitive=false;

			
			niaEntry.Text=user.nia;
			dniEntry.Text=user.dni;
			
			llum.Core core=llum.Core.getCore();
			
			switch(user.main_group)
			{
				case "students":
					dniEntry.Sensitive=false;
				
					if(niaEntry.Text!="" && (core.user_group!="admin" || core.user_group!="promoted-teacher") )
					{
						niaButton.Hide();
						niaEntry.Sensitive=false;
					}
				
					break;
				case "teachers":
					niaEntry.Sensitive=false;
					if(dniEntry.Text!="" && (core.user_group!="admin" || core.user_group!="promoted-teacher"))
					{
						niaButton.Hide();
						dniEntry.Sensitive=false;
					}
				
					break;
				
				default:
					niaButton.Sensitive=false;
					niaEntry.Sensitive=false;
					dniEntry.Sensitive=false;
					niaButton.Hide();
					break;
				
			}
			
			
			belongTreeview.Selection.Mode=Gtk.SelectionMode.Multiple;
			belong_store=new Gtk.TreeStore(typeof(string));
			Gtk.TreeViewColumn belong_column=new Gtk.TreeViewColumn();
			belong_column.Title=Mono.Unix.Catalog.GetString("Belongs to");
			Gtk.CellRendererText cell=new Gtk.CellRendererText();
			belong_column.PackStart(cell,true);
			belong_column.AddAttribute(cell,"text",0);
			belongTreeview.AppendColumn(belong_column);
			//Console.WriteLine(user.groups.Length);

			belongTreeview.Model=belong_store;
			belongTreeview.ShowAll();
			
			availableTreeview.Selection.Mode=Gtk.SelectionMode.Multiple;
			available_store=new Gtk.TreeStore(typeof(string));
			Gtk.TreeViewColumn available_column=new Gtk.TreeViewColumn();
			available_column.Title=Mono.Unix.Catalog.GetString("Available groups");
			Gtk.CellRendererText available_cell=new Gtk.CellRendererText();
			available_column.PackStart(available_cell,true);
			available_column.AddAttribute(available_cell,"text",0);
			availableTreeview.AppendColumn(available_column);
			availableTreeview.Model=available_store;
			availableTreeview.ShowAll();
			
			//llum.Core core=llum.Core.get
			
			
			populateTrees();
			
			
			
			
		}
		
		private void populateTrees()
		{
			
			belong_store.Clear();
			
			foreach(string group_ in user.groups)
			{
				belong_store.AppendValues((group_));
				
			}		
			
			available_store.Clear();
			
			foreach(string tmp in llum.Core.getCore().xmlrpc.get_available_groups())
			{
				if(!user.groups.Contains(tmp))
					available_store.AppendValues((tmp));
				
			}			
		}
		
		protected virtual void OnAddGroupButtonClicked (object sender, System.EventArgs e)
		{
			/*
			Gtk.TreeIter iter;
			bool ok=availableTreeview.Selection.GetSelected(out iter);
			if (ok)
			{
				
				belong_store.AppendValues(available_store.GetValue(iter,0));
				string ret=llum.Core.getCore().xmlrpc.add_to_group(user.uid,Convert.ToString(available_store.GetValue(iter,0)));
			
				if(ret=="true")
				{
					msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Group modification successful") + "</b>";
					user.groups.Add(Convert.ToString(available_store.GetValue(iter,0)));
					available_store.Remove(ref iter);		
				}
				else
				{
					msgLabel.Markup="<span foreground='red'> Error: " + ret + "</span>";				
				}
			
				
			}
			*/
			
			Gtk.TreeIter iter=new Gtk.TreeIter();
			
			Gtk.TreePath[] path_array=availableTreeview.Selection.GetSelectedRows();
			System.Collections.Generic.List<string>ret_list=new System.Collections.Generic.List<string>();
			
			llum.Core core=llum.Core.getCore();
			bool error_found=false;
			
			if(path_array.Length>0)
			{
			
				foreach(Gtk.TreePath path in path_array)
				{
					available_store.GetIter(out iter,path);
					string ret=core.xmlrpc.add_to_group(user.uid,Convert.ToString(available_store.GetValue(iter,0)));
					ret_list.Add(Convert.ToString(available_store.GetValue(iter,0)) + ": " + ret + "\n");
					
					if(ret=="true")
					{
						//belong_store.AppendValues(available_store.GetValue(iter,0));	
						user.groups.Add(Convert.ToString(available_store.GetValue(iter,0)));
						//available_store.Remove(ref iter);	
						
					}
					else
						error_found=true;
					
				}
				
				if(!error_found)
				{
						msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Group modification successful") + "</b>";
			
				}
				else
				{
					string msg="<span foreground='red'> Error:\n";
					foreach(string str in ret_list)
						msg+=str;
					
					msg+="</span>";
					
					msgLabel.Markup=msg;	
				}
				
				populateTrees();
			}
			
		}		
		
		protected virtual void OnRemoveGroupButtonClicked (object sender, System.EventArgs e)
		{
			/*
			Gtk.TreeIter iter;
			bool ok=belongTreeview.Selection.GetSelected(out iter);
			if (ok)
			{
				
				available_store.AppendValues(belong_store.GetValue(iter,0));
				string ret=llum.Core.getCore().xmlrpc.remove_from_group(user.uid,Convert.ToString(belong_store.GetValue(iter,0)));
			
				
				if(ret=="true")
				{
					msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Group modification successful") + "</b>";
					user.groups.Remove(Convert.ToString(belong_store.GetValue(iter,0)));
					belong_store.Remove(ref iter);
					
				}
				else
				{
					msgLabel.Markup="<span foreground='red'> Error: " + ret + "</span>";				
				}
				

				
			}	
			*/

			
			
			Gtk.TreePath[] path_array=belongTreeview.Selection.GetSelectedRows();
			System.Collections.Generic.List<string>ret_list=new System.Collections.Generic.List<string>();
			
			llum.Core core=llum.Core.getCore();
			bool error_found=false;
			
			if(path_array.Length>0)
			{
				foreach(Gtk.TreePath path in path_array)
				{
					Gtk.TreeIter iter=new Gtk.TreeIter();
					belong_store.GetIter(out iter,path);
					
					string ret=core.xmlrpc.remove_from_group(user.uid,Convert.ToString(belong_store.GetValue(iter,0)));
					ret_list.Add(Convert.ToString(belong_store.GetValue(iter,0)) + ": " + ret + "\n");
					
					if(ret=="true")
					{
						//available_store.AppendValues(belong_store.GetValue(iter,0));		
						user.groups.Remove(Convert.ToString(belong_store.GetValue(iter,0)));
						//belong_store.Remove(ref iter);	
						
						
					}
					else
						error_found=true;
					
					
					
				}
				
				if(!error_found)
				{
						msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Group modification successful") + "</b>";
				}
				else
				{
					string msg="<span foreground='red'> Error:\n";
					foreach(string str in ret_list)
						msg+=str;
					
					msg+="</span>";
					
					msgLabel.Markup=msg;		
				}			
				
				populateTrees();
			}
			
		}
		
		protected virtual void OnUndoButtonClicked (object sender, System.EventArgs e)
		{
			nameEntry.Text=user.name;
			surnameEntry.Text=user.surname;
		}
		
		protected virtual void OnApplyButtonClicked (object sender, System.EventArgs e)
		{

			
		//	string ret=llum.Core.getCore().xmlrpc.change_student_personal_data(user.uid,Convert.ToBase64String(Encoding.UTF8.GetBytes(new string(nameEntry.Text.ToCharArray()))),Convert.ToBase64String(Encoding.UTF8.GetBytes(new string(surnameEntry.Text.ToCharArray()))));
				string ret=llum.Core.getCore().xmlrpc.change_student_personal_data(user.uid,nameEntry.Text,surnameEntry.Text);
			if(ret=="true")
			{
				msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Personal data changed successfully") + "</b>";
				user.name=nameEntry.Text;
				user.surname=surnameEntry.Text;			
				
			}
			else
				msgLabel.Markup="<span foreground='red'> Error: " + ret + "</span>";
		}
		
		protected virtual void OnPassEntryChanged (object sender, System.EventArgs e)
		{
			if((passEntry.Text==passEntry2.Text) && passEntry.Text!="")
			{
				changePasswordButton.Sensitive=true;	
			}
			else
				changePasswordButton.Sensitive=false;
		}
		
		protected virtual void OnPass2EntryChanged (object sender, System.EventArgs e)
		{
			
			if((passEntry.Text==passEntry2.Text) && passEntry.Text!="")
			{
				changePasswordButton.Sensitive=true;	
			}
			else
				changePasswordButton.Sensitive=false;			
		}
		
		protected virtual void OnChangePasswordButtonClicked (object sender, System.EventArgs e)
		{
			string ret="";
			if(passEntry.Text!="")
			{
				if(user.main_group=="students")
				{
					ret=llum.Core.getCore().xmlrpc.change_student_password(user.uid,passEntry.Text);
					
				}
				else
					ret=llum.Core.getCore().xmlrpc.change_password(user.path,passEntry.Text,false);
				
				if(ret=="true")
					msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("User password changed successfully") + "</b>";
				else
					msgLabel.Markup="<span foreground='red'> Error: " + ret + "</span>";
			}
			else
				msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Password cannot be empty") +"</span>";
			
		}
		
		protected virtual void OnNiaButtonClicked (object sender, System.EventArgs e)
		{
			string ret="";
			switch(user.main_group)
			{
				case "students":
				
					ret=llum.Core.getCore().xmlrpc.generic_student_to_itaca(user.uid,niaEntry.Text);
					if(ret.Contains("true"))
					{
					
						msgLabel.Markup="<b>"  + Mono.Unix.Catalog.GetString("NIA edited succesfully") + "</b>";
						
					}
					else
					{
						msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("There was an error trying to edit this user") + ":\n" + ret + "</span>";
					}
				
				break;
				
				case "teachers":
				
					ret=llum.Core.getCore().xmlrpc.generic_teacher_to_itaca(user.uid,dniEntry.Text);
					if(ret.Contains("true"))
					{
					
						msgLabel.Markup="<b>"  + Mono.Unix.Catalog.GetString("NIF edited successfully ") + "</b>";
						
					}
					else
					{
						msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("There was an error trying to edit this user") + ":\n" + ret + "</span>";
					}				
				break;
			}
			
			niaButton.Hide();
			niaEntry.Sensitive=false;
			dniEntry.Sensitive=false;
			
		}
		
		
		
		
		
		
		
		
		
	}
}
