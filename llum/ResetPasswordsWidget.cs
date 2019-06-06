
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class ResetPasswordsWidget : Gtk.Bin
	{
		public Gtk.Image image;
		public Gtk.Label label;
		public ResetPasswordsWidget ()
		{
			this.Build ();
			
			image=new Gtk.Image();
			image.SetFromIconName("system-lock-screen",Gtk.IconSize.Dnd);
			image.Show();
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Reset passwords"));
			label.Show();
			
		}

		protected virtual void OnResetButtonClicked (object sender, System.EventArgs e)
		{

			System.Threading.Thread thread=null;
			string msg2="";
			msg2=Mono.Unix.Catalog.GetString("Resetting passwords...");
						
			llum.Core.getCore().progress_window=new ProgressWindow(msg2);
			llum.Core.getCore().progress_window.ShowAll();
			llum.Core.getCore().progress_window.ShowNow();			
			
			System.Threading.ThreadStart progressTStart = delegate 
			{
				//ACTIONS
				
				System.Collections.Generic.List<llum.LdapUser> list=llum.Core.getCore().xmlrpc.get_user_list();
				System.Collections.Generic.List<string> ret=new System.Collections.Generic.List<string>();
				if(studentsRadiobutton.Active)
				{
					Console.WriteLine("Regenerating students passwords");
					foreach(llum.LdapUser user in list)
					{
						if(user.main_group=="students")
						{
							ret.Add(llum.Core.getCore().xmlrpc.change_password(user.path,generate_password(5),true));
							
						}
		
					}

				}
				else if(teachersRadiobutton.Active)
				{
					Console.WriteLine("Regenerating teachers passwords");
					foreach(llum.LdapUser user in list)
					{
						if(user.main_group=="teachers")
						{
							ret.Add(llum.Core.getCore().xmlrpc.change_teacher_password(user.path,generate_password(5),user.uid,user.name,user.surname,true));
						}
		
					}
				}
				else
				{
					// ALL USERS
					Console.WriteLine("Regenerating all passwords");
					foreach(llum.LdapUser user in list)
					{
						if(user.main_group=="students")
						{
							ret.Add(llum.Core.getCore().xmlrpc.change_password(user.path,generate_password(5),true));
						}
						if(user.main_group=="teachers")
						{
							ret.Add(llum.Core.getCore().xmlrpc.change_teacher_password(user.path,generate_password(5),user.uid,user.name,user.surname,true));
						}
		
					}
				}
									
				
				
				
				Gtk.Application.Invoke(delegate{
					
					bool ok=true;
					
					foreach(string str in ret)
					{
						if(!str.Contains("true"))
						{
							ok=false;	
						}
					}
					
					string msg="";
					
					if(ok)
					{
						msg="<b>" + Mono.Unix.Catalog.GetString("Passwords changed successfuly") + "</b>";
					}
					else
					{
						msg="<span foreground='red'>" + Mono.Unix.Catalog.GetString("There was an error when changing passwords") + ":\n";	
						foreach(string str in ret)
							msg+=str + "\n";
						msg+="</span>";
					}
					
					msgLabel.Markup=msg;
						
					llum.Core.getCore().progress_window.Hide();
						
					});	
					
							

			};
			
			thread=new System.Threading.Thread(progressTStart);
			thread.Start();

		
			
			
			
			
			
			

			
		}

		private string generate_password(int size)
		{
		    char[] buffer = new char[size];
			string chars = "abcdefghijklmnopqrstuvwxyz";
			Random rnd=new Random();
		    for (int i = 0; i < size; i++)
		    {
		        buffer[i] = chars[rnd.Next(chars.Length)];
		    }
		    return new string(buffer);
		}
		
		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			
			llum.Core.getCore().reset_wid=new ResetPasswordsWidget();
			
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().reset_wid);
		}			
		
	}
}
