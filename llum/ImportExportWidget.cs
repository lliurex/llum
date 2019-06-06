using System;

namespace llum
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ImportExportWidget : Gtk.Bin
	{

		public Gtk.Label label;
		public Gtk.Image image;

		public ImportExportWidget ()
		{

			this.Build ();

			image=new Gtk.Image();
			image.SetFromIconName("document-revert",Gtk.IconSize.Dnd);
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Import/Export operations"));
			label.Show();

			exportFilechooserbutton.SetCurrentFolder(System.Environment.GetEnvironmentVariable("HOME"));

		}

		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{

			llum.Core.getCore().imex_wid=new ImportExportWidget();

			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().imex_wid);
		}


		protected void OnExportButtonClicked (object sender, EventArgs e)
		{
			if(llum.Core.getCore().xmlrpc.export_llum_info(exportFilechooserbutton.Filename+"/llum_data.llum"))
				msg_label.Markup="<b>"+Mono.Unix.Catalog.GetString("Llum data exported successfully")+":\n"+exportFilechooserbutton.Filename+"/llum_data.llum</b>";
			else
				msg_label.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Llum data exportation failed") + "</span>";
		}

		protected void OnImportButtonClicked (object sender, EventArgs e)
		{


			// IMPORT USERS
			string msg2=Mono.Unix.Catalog.GetString("Importing users...");
			llum.Core.getCore().progress_window=new ProgressWindow(msg2);
			llum.Core.getCore().progress_window.ShowAll();
			llum.Core.getCore().progress_window.ShowNow();			

			System.Threading.ThreadStart progressTStart = delegate 
			{
				bool ok=false;

				try
				{
					ok=llum.Core.getCore().xmlrpc.import_llum_info(importFilechooserbutton.Filename);
					llum.Core.getCore().xmlrpc.regenerate_net_files();
					if(regenerateCb.Active)
					{
						Console.WriteLine("Regenerating all passwords");
						System.Collections.Generic.List<llum.LdapUser> list=llum.Core.getCore().xmlrpc.get_user_list();
						System.Collections.Generic.List<string> ret=new System.Collections.Generic.List<string>();
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
						
				}
				catch
				{
				
				}

				Gtk.Application.Invoke(delegate{
					if(ok)
						msg_label.Markup="<b>"+Mono.Unix.Catalog.GetString("Llum data imported successfully")+"</b>";
					else
						msg_label.Markup="<span foreground='red'>"+Mono.Unix.Catalog.GetString("Llum data importation failed")+"</span>";

					llum.Core.getCore().progress_window.Hide();

				});	

			};

			System.Threading.Thread thread;
			thread=new System.Threading.Thread(progressTStart);
			thread.Start();

			// ///////////////////////////////////////////////////////////






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
	}
}

