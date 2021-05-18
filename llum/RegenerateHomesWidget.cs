using System;
using System.Threading;

namespace llum
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class RegenerateHomesWidget : Gtk.Bin
	{
		
		public Gtk.Label label;
		public Gtk.Image image;
		
		public RegenerateHomesWidget ()
		{
			this.Build ();
			
			image=new Gtk.Image();
			image.SetFromIconName("view-refresh",Gtk.IconSize.Dnd);
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("/net operations"));
			label.Show();				
			
		}
		
		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			
			llum.Core.getCore().regen_wid=new RegenerateHomesWidget();
			
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().regen_wid);
		}		
		
		

		
		protected void OnRegenHomeExecuteButtonClicked (object sender, System.EventArgs e)
		{
			
			
			string msg2=Mono.Unix.Catalog.GetString("Regenerating /net folders...");
			llum.Core.getCore().progress_window=new ProgressWindow(msg2);
			llum.Core.getCore().progress_window.ShowAll();
			llum.Core.getCore().progress_window.ShowNow();			
			
			System.Threading.ThreadStart progressTStart = delegate 
			{
				bool ok=true;
				
				try
				{
					llum.Core.getCore().xmlrpc.regenerate_net_files();
				}
				catch
				{
					ok=false;
				}
				
				Gtk.Application.Invoke(delegate{
					
					
					if(ok)
						msg_label.Markup="<b>"+Mono.Unix.Catalog.GetString("/net user folders regenerated")+"</b>";
					else
						msg_label.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Regeneration failed") + "</span>";
						
					llum.Core.getCore().progress_window.Hide();
						
					});	
					
							

			};
			System.Threading.Thread thread;
			thread=new System.Threading.Thread(progressTStart);
			thread.Start();

		}

		protected void OnFixAclsButtonClicked (object sender, System.EventArgs e)
		{
			string msg2=Mono.Unix.Catalog.GetString("Fixing /net ACLs...");
			
			llum.Core core=llum.Core.getCore();
			core.xmlrpc.restore_acls_via_thread();
			
			core.progress_window=new ProgressWindow(msg2);
			core.progress_window.ShowAll();
			core.progress_window.ShowNow();
			
			int status;
			
			System.Threading.ThreadStart progressTStart = delegate 
			{
				
				status=core.xmlrpc.is_acl_thread_alive();
				
				while(status==0)
				{
					Thread.Sleep(10000);
					status=core.xmlrpc.is_acl_thread_alive();
				}
				

				Gtk.Application.Invoke(delegate{
					
					
					if(status==1)
						msg_label.Markup="<b>"+Mono.Unix.Catalog.GetString("ACLs restored")+"</b>";
					else
					{
						msg_label.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("ACLs restoration failed") + "</span>";
					}
						
					llum.Core.getCore().progress_window.Hide();
						
					});	
					
							

			};			
			
			

			/*
			
			llum.Core.getCore().progress_window=new ProgressWindow(msg2);
			llum.Core.getCore().progress_window.ShowAll();
			llum.Core.getCore().progress_window.ShowNow();			
			
			
			
			
			System.Threading.ThreadStart progressTStart = delegate 
			{
				bool ok=true;
				try
				{
					//llum.Core.getCore().xmlrpc.regenerate_net_files();
					
					llum.Core.getCore().xmlrpc.restore_acls();
					
					
				}
				catch(Exception acl_ex)
				{
					ok=false;
					Console.WriteLine(acl_ex);
				}
				
				Gtk.Application.Invoke(delegate{
					
					
					if(ok)
						msg_label.Markup="<b>"+Mono.Unix.Catalog.GetString("ACLs restored")+"</b>";
					else
						msg_label.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("ACLs restoration failed") + "</span>";
						
					llum.Core.getCore().progress_window.Hide();
						
					});	
					
							

			};
			
			*/
			
			
			
			System.Threading.Thread thread;
			thread=new System.Threading.Thread(progressTStart);
			thread.Start();
		}
	}
}

