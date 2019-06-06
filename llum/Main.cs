using System;
using Gtk;



namespace llum
{
	
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine("INFO: You may use a custom server ip as a parameter to connect to a n4d-server. Ex.: llum 172.25.25.54");
			Application.Init ();
			llum.Core.getCore();
			if(args.Length>0)
			{
				llum.Core.getCore().server="https://" + args[0] + ":9779";
				llum.Core.getCore().user_ip=true;
				llum.Core.getCore().xmlrpc=new XmlrpcClient();
				Application.Run ();
				
			}
			else
			{
				llum.Core.getCore().server="https://localhost:9779";
				llum.Core.getCore().xmlrpc=new XmlrpcClient();
				
				System.Threading.Thread thread;
				System.Threading.ThreadStart tstart=delegate{
			
				string master_server_ip;			
				master_server_ip=llum.Core.getCore().xmlrpc.get_master_ip();
				if (master_server_ip!=null && master_server_ip!="FUNCTION NOT SUPPORTED")
				{
					llum.Core.getCore().server="https://"+master_server_ip+":9779";
					llum.Core.getCore().xmlrpc=new XmlrpcClient();
					try{
							llum.Core.getCore().xmlrpc.get_methods();
							Gtk.Application.Invoke(delegate{
						
								llum.Core.getCore().mw.enableIcon(true);
					
							});
							if(!System.IO.File.Exists("/lib/systemd/system/net-server\\x2dsync.mount"))
								throw new Exception("Forcing fallback to local server. N4D will handle remote ldap connection");
						}
					catch
						{
							// Connection failed, reverting to local server
							llum.Core.getCore().server="https://server:9779";
							llum.Core.getCore().xmlrpc=new XmlrpcClient();
						}
					
				}
				else
				{
					llum.Core.getCore().server="https://server:9779";
					llum.Core.getCore().xmlrpc=new XmlrpcClient();
						
				}

				};
			
				thread=new System.Threading.Thread(tstart);
			
				thread.Start();
				
				
							
				Gdk.Threads.Init();
			
				Application.Run ();
			}
		}
	}
}
