
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class DeleteHomeWidget : Gtk.Bin
	{

		
		public Gtk.Label label;
		public Gtk.Image image;
		public Gtk.ListStore store;
		public DeleteHomeWidget ()
		{
			this.Build ();
			image=new Gtk.Image();
			image.SetFromIconName("dialog-cancel",Gtk.IconSize.Dnd);
			image.Show();
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Clear user's /home"));
			label.Show();			
			
			store=new Gtk.ListStore(typeof(string),typeof(int));
			store.AppendValues(Mono.Unix.Catalog.GetString("Students"),0);
			store.AppendValues(Mono.Unix.Catalog.GetString("Teachers"),1);
			store.AppendValues(Mono.Unix.Catalog.GetString("Others"),2);
			store.AppendValues(Mono.Unix.Catalog.GetString("Everyone"),3);
			
			optionCombobox.Model=store;
			optionCombobox.Active=0;
			
			warningHbox.Hide();
		}
		
		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			llum.Core.getCore().delete_home_wid=new DeleteHomeWidget();
			
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().delete_home_wid);
		}		
		
		protected virtual void OnAcceptButtonClicked (object sender, System.EventArgs e)
		{
			frame2.Sensitive=false;
			warningHbox.Show();
			string msg="";
			switch(optionCombobox.Active)
			{
				case 0:	
					msg=Mono.Unix.Catalog.GetString("You are about to clear every student's home. Are you sure?");
				break;
				
				case 1:
					msg=Mono.Unix.Catalog.GetString("You are about to clear every teacher's home. Are you sure?");
				break;
				
				case 2:
					msg=Mono.Unix.Catalog.GetString("You are about to clear every other's home. Are you sure?");
				break;
				
				
				case 3:
					msg=Mono.Unix.Catalog.GetString("You are about to clear every user's home. Are you sure?");
				break;
				
			}
			
			warningLabel.Markup="<b>" + msg +"</b>";
			
		}		
		
		protected virtual void OnDoitButtonClicked (object sender, System.EventArgs e)
		{

			System.Threading.Thread thread=null;
			string msg2="";
			msg2=Mono.Unix.Catalog.GetString("Cleaning /home directories...");
						
			llum.Core.getCore().progress_window=new ProgressWindow(msg2);
			llum.Core.getCore().progress_window.ShowAll();
			llum.Core.getCore().progress_window.ShowNow();			
			
			System.Threading.ThreadStart progressTStart = delegate 
			{
				//ACTIONS
				
				llum.Core core=llum.Core.getCore();
				
				System.Collections.Generic.List<string> ret=new System.Collections.Generic.List<string>();
				
				switch(optionCombobox.Active)
				{
					case 0:
						//ret=core.xmlrpc.delete_students();
						ret=core.xmlrpc.empty_students();
					break;
						
					case 1:
						//ret=core.xmlrpc.delete_teachers();
						ret=core.xmlrpc.empty_teachers();
					break;
					
					case 2:
						//ret=core.xmlrpc.delete_all();
						ret=core.xmlrpc.empty_others();
					break;
					
					case 3:
						ret=core.xmlrpc.empty_all();
					break;
				}
				
				
				
				Gtk.Application.Invoke(delegate{
					
					bool ok=true;
	
					foreach(string str in ret)
					{
						Console.WriteLine(str);
						if(!str.Contains(":true"))
						{
							ok=false;	
						}
					}
					
					string msg="";
					
					if(ok)
					{
						msg="<b>" + Mono.Unix.Catalog.GetString("Deletion successful") + "</b>";
					}
					else
					{
						msg="<span foreground='red'>" + Mono.Unix.Catalog.GetString("There was an error when deleting homes") + ":\n";	
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
		
		protected virtual void OnCancelButtonClicked (object sender, System.EventArgs e)
		{
			warningHbox.Hide();
			frame2.Sensitive=true;
		}		
		
		
	}
}
