
using System;

using CookComputing.XmlRpc.XmlRpcStruct;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class LoginWidget : Gtk.Bin
	{
		

		public LoginWidget ()
		{
			this.Build ();
			
			Gtk.ListStore store=new Gtk.ListStore(typeof(string));
			label5.Text=Mono.Unix.Catalog.GetString("User");
			label6.Text=Mono.Unix.Catalog.GetString("Password");
			label3.Text=Mono.Unix.Catalog.GetString("Enter your user and password");
			
			store.AppendValues(Mono.Unix.Catalog.GetString("Classroom Server"));
			store.AppendValues(Mono.Unix.Catalog.GetString("Center Server"));
			
			serverListcombobox.Model=store;
			
			serverListcombobox.Active=0;
			
			
			
			
		}
		

		protected virtual void OnConnectButtonClicked (object sender, System.EventArgs e)
		{
			llum.Core core=llum.Core.getCore();
			
			string[] user_info={userEntry.Text,passwordEntry.Text};
			
			
			try
			{
			
				CookComputing.XmlRpc.XmlRpcStruct ret=core.xmlrpc.client.login(user_info,"Golem",user_info);
				
				if(ret.Contains("true"))
				{
					core.mw.statusText=Mono.Unix.Catalog.GetString("Connected to LDAP as: ") + userEntry.Text;
					//core.function_list=core.xmlrpc.client.get_students_function_list(user_info,"Golem");
					//Console.WriteLine(core.xmlrpc.client.get_students_function_list(user_info,"Golem"));
					string[] tmp=ret.Split(' '); // tmp[1] contains group type [ students, teachers, admin, others ]
					core.user_info=user_info;
					switch(tmp[1])
					{
						case "students":
							core.function_list=core.xmlrpc.client.get_students_function_list(user_info,"Golem");
							core.set_function_list("students");
							core.user_group="students";
							break;
						case "teachers":
							core.function_list=core.xmlrpc.client.get_teachers_function_list(user_info,"Golem");
							core.set_function_list("teachers");
							core.user_group="teachers";
							break;
						case "admin":
							core.function_list=core.xmlrpc.client.get_admin_function_list(user_info,"Golem");
							core.set_function_list("admin");
							core.user_group="admin";
							break;
						
						case "others":
							core.function_list=core.xmlrpc.client.get_others_function_list(user_info,"Golem");
							core.set_function_list("others");
							core.user_group="others";
							break;
						
						case "promoted-teacher":
							core.function_list=core.xmlrpc.client.get_teachers_function_list(user_info,"Golem");
							core.set_function_list("admin");
							core.user_group="promoted-teacher";
							break;
						
						default:
						
							break;
						
					}
					/*
					Console.WriteLine("[LoginWidget] Available functions:");
					foreach(string str in core.function_list)
					{
						Console.WriteLine("\t*Function " + str);	
					}
					Console.WriteLine();
					*/
					
					
				}
				else
					core.mw.statusText="<span foreground='red'>" + Mono.Unix.Catalog.GetString("User and/or password are incorrect.") +  "\n" + "RET: " + ret + "</span>";
			}
			catch(Exception excp)
			{
				Console.WriteLine(core.server);
				Console.WriteLine(excp);
				core.mw.statusText="<span foreground='red'>" + Mono.Unix.Catalog.GetString("There was an error trying to connect to the n4d(XMLRPC) server") +"</span>";	
			}
			
			
		}
				
		[GLib.ConnectBefore]
		protected virtual void OnPasswordEntryKeyPressEvent (object o, Gtk.KeyPressEventArgs args)
		{
			if (args.Event.Key == Gdk.Key.Return || args.Event.Key == Gdk.Key.KP_Enter)
			{
			
				OnConnectButtonClicked(null,null);
				
			}
		}
		
		

		
	}
}
