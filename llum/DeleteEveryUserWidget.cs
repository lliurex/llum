
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class DeleteEveryUserWidget : Gtk.Bin
	{
		public Gtk.Image image;
		public Gtk.Label label;
		private Gtk.ListStore store;
		public DeleteEveryUserWidget ()
		{
			this.Build ();
			image=new Gtk.Image();
			image.SetFromIconName("dialog-cancel",Gtk.IconSize.Dnd);
			image.Show();
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("User Deletion tool"));
			label.Show();			
			
			store=new Gtk.ListStore(typeof(string),typeof(int));
			store.AppendValues(Mono.Unix.Catalog.GetString("Students"),0);
			store.AppendValues(Mono.Unix.Catalog.GetString("Teachers"),1);
			store.AppendValues(Mono.Unix.Catalog.GetString("Everyone"),2);
			
			optionCombobox.Model=store;
			optionCombobox.Active=0;
			
			warningHbox.Hide();
			
		}
		
		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			
			llum.Core.getCore().delete_every_user_wid=new DeleteEveryUserWidget();
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().delete_every_user_wid);
			
		}		
		
		protected virtual void OnAcceptButtonClicked (object sender, System.EventArgs e)
		{
			frame2.Sensitive=false;
			warningHbox.Show();
			string msg="";
			switch(optionCombobox.Active)
			{
				case 0:	
					msg=Mono.Unix.Catalog.GetString("You are about to delete every student. Are you sure?");
				break;
				
				case 1:
					msg=Mono.Unix.Catalog.GetString("You are about to delete every teacher. Are you sure?");
				break;
				
				case 2:
					msg=Mono.Unix.Catalog.GetString("You are about to delete every user. Are you sure?");
				break;
				
			}
			
			warningLabel.Markup="<b>" + msg +"</b>";
			
		}
		
		protected virtual void OnCancelButtonClicked (object sender, System.EventArgs e)
		{
			warningHbox.Hide();
			frame2.Sensitive=true;
		}
		

		
		protected virtual void OnDoitButtonClicked (object sender, System.EventArgs e)
		{
			
			
			System.Threading.Thread thread=null;
			
			
			string msg="";
			msg=Mono.Unix.Catalog.GetString("Deleting users...");
						
			llum.Core.getCore().progress_window=new ProgressWindow(msg);
			llum.Core.getCore().progress_window.ShowAll();
			llum.Core.getCore().progress_window.ShowNow();
			
			bool delete_data=this.delete_checkbutton.Active;
			
			System.Threading.ThreadStart progressTStart = delegate 
			{
				//ACTIONS
				
				llum.Core core=llum.Core.getCore();
				
				System.Collections.Generic.List<string> ret=new System.Collections.Generic.List<string>();
				
				switch(optionCombobox.Active)
				{
					case 0:
						ret=core.xmlrpc.delete_students(delete_data);
					break;
						
					case 1:
						ret=core.xmlrpc.delete_teachers(delete_data);
					break;
					
					case 2:
						ret=core.xmlrpc.delete_all(delete_data);
					break;
				}
				
				
				
				Gtk.Application.Invoke(delegate{
					
					
					bool ok=true;
					
					foreach(string str in ret)
					{
						if(!str.Contains(":true"))
						{
							ok=false;	
						}
					}
					
					string msg2="";
					
					if(ok)
					{
						msg2="<b>" + Mono.Unix.Catalog.GetString("Deletion successful") + "</b>";
					}
					else
					{
						msg2="<span foreground='red'>" + Mono.Unix.Catalog.GetString("There was an error when deleting users") + ":\n";	
						foreach(string str in ret)
							msg2+=str + "\n";
						msg2+="</span>";
					}
					
					msgLabel.Markup=msg2;
						
					Core.getCore().progress_window.Hide();
						
					});	
					
							

			};
			
			thread=new System.Threading.Thread(progressTStart);
			thread.Start();

			

					
		}
		
		
		
		
		
	}
}
