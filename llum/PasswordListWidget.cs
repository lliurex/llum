
using System;
using System.Text;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class PasswordListWidget : Gtk.Bin
	{

		
		private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
		private string RandomString(int size)
	    {
	        StringBuilder builder = new StringBuilder();
	        char ch;
	        for (int i = 0; i < size; i++)
	        {
	            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));                 
	            builder.Append(ch);
	        }
	
	        return builder.ToString();
	    }		
		
		
		public Gtk.Image image;
		public Gtk.Label label;
		public int search_mode;
		private System.Collections.Generic.List<LdapUser> user_list;
		public PasswordListWidget ()
		{
			this.Build ();
			image=new Gtk.Image();
			image.SetFromIconName("system-lock-screen",Gtk.IconSize.Dnd);
			image.Show();
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Get password list"));
			label.Show();
			search_mode = 0;
			

			System.Threading.ThreadStart tstart=delegate{
			
				user_list=llum.Core.getCore().xmlrpc.get_user_list();
				
			};
			
			System.Threading.Thread thread=new System.Threading.Thread(tstart);			
			thread.Start();
			
			
			System.Collections.Generic.List<string> groups=llum.Core.getCore().xmlrpc.get_available_groups();
			
			groupsCombobox.AppendText(Mono.Unix.Catalog.GetString("All"));
			
			foreach(string group_name in groups)
			{
					groupsCombobox.AppendText(group_name);
			}
			
			groupsCombobox.Active=0;
			
			if(llum.Core.getCore().user_group=="teachers")
			{
				teachersRadiobutton.Sensitive=false;
				allRadiobutton.Sensitive=false;
			}
			
			
		}
		
		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			
			llum.Core.getCore().pass_list_wid=new PasswordListWidget();
			
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().pass_list_wid);
		}		
		
		protected virtual void OnGenerateButtonClicked (object sender, System.EventArgs e)
		{
			llum.Core core=llum.Core.getCore();
			//System.Collections.Generic.Dictionary<string,string>dic=new System.Collections.Generic.Dictionary<string, string>();
			
			System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct> list=new System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct>();
			
			if(studentsRadiobutton.Active)
			{
				list=core.xmlrpc.get_students_passwords();
				search_mode = 0;
			}
			if(teachersRadiobutton.Active)
			{
				list=core.xmlrpc.get_teachers_passwords();
				//groupsCombobox.Active=0;
				search_mode = 1;
			}
			if(allRadiobutton.Active)
			{
				list=core.xmlrpc.get_all_passwords();
				//groupsCombobox.Active=0;
				search_mode = 2;
			}
			
			/*
			foreach(string str in dic.Keys)
			{
				if(!dic[str].Contains("{SSHA}"))
					Console.WriteLine(str + ":" + dic[str]);
				
			}
			*/
			
			string close_html="</div>\n" +
				"</body>\n" +
				"</html>\n";
			
			System.IO.StreamReader stream=new System.IO.StreamReader(core.html_skel);
			string final_html=stream.ReadToEnd();
			stream.Close();
			
			final_html=final_html.Replace("%%NAME%%",Mono.Unix.Catalog.GetString("Name"));
			final_html=final_html.Replace("%%USER%%",Mono.Unix.Catalog.GetString("User"));
			final_html=final_html.Replace("%%PASSWORD%%",Mono.Unix.Catalog.GetString("Password"));
			final_html=final_html.Replace("%%PRINT%%",Mono.Unix.Catalog.GetString("Print"));
			
			
			bool impar=false;
			

			
			
			
			foreach(CookComputing.XmlRpc.XmlRpcStruct dic in list)
			{
				bool ok=false;
				if (user_list != null)
					if (search_mode == 0) {
						foreach (LdapUser user in user_list) {
							if ((string)dic ["uid"] == user.uid) {
								if (groupsCombobox.Active == 0) {
									ok = true;
									break;
								} else {
									ok = user.groups.Contains (groupsCombobox.ActiveText);
									break;
								}
							}
						}
					} else {
						ok = true;
					}

				else
					ok=true;
				
				if(ok)
				{
					if(!impar)
					{
	
						final_html+="\n<div class='row'><div class='left'>\n";
						final_html+=dic["sn"]+", " + dic["cn"];
						final_html+="\n</div><div class='middle'>\n";
						final_html+=dic["uid"];
						final_html+="\n</div><div class='right'>\n";
						final_html+=dic["passwd"];
						final_html+="\n</div></div>\n";
						
									
						impar=true;
					}
					else
					{
						final_html+="\n<div class='row impar'><div class='left'>\n";
						final_html+=dic["sn"]+", " + dic["cn"];
						final_html+="\n</div><div class='middle'>\n";
						final_html+=dic["uid"];
						final_html+="\n</div><div class='right'>\n";
						final_html+=dic["passwd"];
						final_html+="\n</div></div>\n";			
						impar=false;
					}
				}
			}
			
			final_html+=close_html;
			
			string file_name="/tmp/." + RandomString(10);
			
			while(System.IO.File.Exists(file_name))
				file_name="/tmp/." + RandomString(10);
			
			System.IO.StreamWriter sw=new System.IO.StreamWriter(file_name);
			sw.Write(final_html);
			sw.Close();
			
			
			
			
			Mono.Unix.Native.Syscall.chmod(file_name,Mono.Unix.Native.FilePermissions.S_IRWXU);
			
			System.Threading.ThreadStart start=delegate{
			
			System.Diagnostics.Process p = new System.Diagnostics.Process();
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardOutput = true ;
			p.StartInfo.RedirectStandardError = true;
			p.StartInfo.FileName = "/usr/share/llum/llum-browser";
			p.StartInfo.Arguments=file_name;
			p.Start();	
						
				

			};
			
			System.Threading.Thread thread=new System.Threading.Thread(start);
			
			thread.Start();
			
			
		}
		
		
	}
}
