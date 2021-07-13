
using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Globalization;
using System.Security.Cryptography;


namespace llum
{


	public class Core
	{

		public static Core singleton;
		
		public System.Collections.Generic.Dictionary <string,string> llxvars;
		public llum.LoginWidget loginwid;
		public llum.XmlrpcClient xmlrpc;
		public llum.EditUser edit_user_wid;
		public llum.DeleteUserWidget delete_users_wid;
		public llum.ProgressWindow progress_window;
		public llum.AddUser add_user_wid;
		public llum.PromoteUserWidget promote_users_wid;
		public llum.SearchGroupWidget search_group_wid;
		public llum.EditGroupWidget edit_group_wid;
		public llum.DemoteUserWidget demote_users_wid;
		public llum.DeleteGroupsWidget delete_groups_wid;
		public llum.AddGroupWidget add_group_wid;
		public llum.AddGenericUsersWidget add_generic_users_wid;
		public llum.PasswordListWidget pass_list_wid;
		public llum.DeleteEveryUserWidget delete_every_user_wid;
		public llum.GescenImportWidget gescen_wid;
		public llum.DeleteHomeWidget delete_home_wid;
		public llum.FreezeWidget freeze_wid;
		public llum.ResetPasswordsWidget reset_wid;
		public llum.RegenerateHomesWidget regen_wid;
		public llum.ImportExportWidget imex_wid;
		public llum.ReadOnlyAdminWidget roadmin_wid;
		
		public string[] user_info;
		public string[] function_list;
		public string user_group;
		public bool user_ip;

		public string forced_string;
		
		public MainWindow mw;
		
		public ChangeOwnPassword cop;
		public SearchUser search_user;
		
		public System.Collections.Generic.List<Gtk.Widget> available_widgets;
		public string server="https://server:9779";
		public string html_skel="/usr/share/llum/html_skel.html";
		
		
		public Core ()
		{
			Mono.Unix.Catalog.Init("llum","/usr/share/locale/");

			this.user_ip=false;
			Core.singleton=this;
			mw=new MainWindow();
			available_widgets=new System.Collections.Generic.List<Gtk.Widget>();
			loginwid=new LoginWidget();
			mw.setCurrentWidget(loginwid);

		}
		
		public Gtk.Button create_button(Gtk.Label label, Gtk.Image image)
		{
			Gtk.Button button=new Gtk.Button();
			Gtk.VBox vbox=new Gtk.VBox();

			label.WidthChars=24;
			label.MaxWidthChars=24;
			label.LineWrap=true;
			label.Justify=Gtk.Justification.Center;

			vbox.Add(image);
			vbox.Add(label);
			button.Add(vbox);
			button.ShowAll();

			int h=46+label.SizeRequest().Height;
			if (h < 80)
				h=80;

			button.SetSizeRequest(1,h);
			
			return button;
		}
		
		public string strip_special_chars(string url)
		{
			
			url = Regex.Replace(url, @"[^\w\.@-]","");
			string stFormD = url.Normalize(NormalizationForm.FormD);
			StringBuilder sb = new StringBuilder();
		 
			for (int ich = 0; ich < stFormD.Length; ich++)
			{
				
				UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
				if (uc != UnicodeCategory.NonSpacingMark)
				{
					sb.Append(stFormD[ich]);
				}
			}
		 
			return (sb.ToString());
		}	
		
		public void set_function_list(string type)
		{
			
			available_widgets.Clear();
			available_widgets=new System.Collections.Generic.List<Gtk.Widget>();

			
			// DEFAULT FUNCTIONS FOR EVERYONE
			
				// CHANGE OWN PASSWORD //
			cop=new ChangeOwnPassword();
			available_widgets.Add(cop);
			mw.setCurrentWidget(cop);
			Gtk.Button button=create_button(cop.label,cop.image);
			button.Clicked+=cop.OnMenuButtonClicked;
			mw.addMenuButton(button);			
			
			
			
			
			
			
			// CUSTOM FUNCTIONS
			switch(type)
			{
				case "students":
						

					break;
				
				case "teachers":
				
					search_user=new SearchUser(true);
					available_widgets.Add(search_user);
					button=create_button(search_user.label,search_user.image);
					button.Clicked+=search_user.OnMenuButtonClicked;
					mw.addMenuButton(button);
				
					
				
					
					 
					add_user_wid=new AddUser();
					available_widgets.Add(add_user_wid);
					button=create_button(add_user_wid.label,add_user_wid.image);
					button.Clicked+=add_user_wid.OnMenuButtonClicked;				
					mw.addMenuButton(button); 
					 
					add_generic_users_wid=new AddGenericUsersWidget();
					available_widgets.Add(add_generic_users_wid);
					button=create_button(add_generic_users_wid.label, add_generic_users_wid.image);
					button.Clicked+=add_generic_users_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);
				
					add_group_wid=new AddGroupWidget();
					available_widgets.Add(add_group_wid);
					button=create_button(add_group_wid.label, add_group_wid.image);
					button.Clicked+=add_group_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);	
					
					
				
					pass_list_wid=new PasswordListWidget();
					available_widgets.Add(pass_list_wid);
					button=create_button(pass_list_wid.label,pass_list_wid.image);
					button.Clicked+=pass_list_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);
				
					/*
					if (xmlrpc.get_methods().Contains("get_frozen_users"))
					{
						freeze_wid=new FreezeWidget();
						available_widgets.Add(freeze_wid);
						button=create_button(freeze_wid.label,freeze_wid.image);
						button.Clicked+=freeze_wid.OnMenuButtonClicked;
						mw.addMenuButton(button);			
					}
					*/
				
								
				
				
					break;
				
				case "admin":
				
			
					search_user=new SearchUser(true);
					available_widgets.Add(search_user);
					button=create_button(search_user.label,search_user.image);
					button.Clicked+=search_user.OnMenuButtonClicked;
					mw.addMenuButton(button);
					
					add_user_wid=new AddUser();
					available_widgets.Add(add_user_wid);
					button=create_button(add_user_wid.label,add_user_wid.image);
					button.Clicked+=add_user_wid.OnMenuButtonClicked;				
					mw.addMenuButton(button);
				
				
					add_generic_users_wid=new AddGenericUsersWidget();
					available_widgets.Add(add_generic_users_wid);
					button=create_button(add_generic_users_wid.label, add_generic_users_wid.image);
					button.Clicked+=add_generic_users_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);
				
					search_group_wid=new SearchGroupWidget();
					available_widgets.Add(search_group_wid);
					button=create_button(search_group_wid.label,search_group_wid.image);
					button.Clicked+=search_group_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);
				
					add_group_wid=new AddGroupWidget();
					available_widgets.Add(add_group_wid);
					button=create_button(add_group_wid.label, add_group_wid.image);
					button.Clicked+=add_group_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);

					freeze_wid=new FreezeWidget();
					available_widgets.Add(freeze_wid);
					button=create_button(freeze_wid.label,freeze_wid.image);
					button.Clicked+=freeze_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);			
									
					pass_list_wid=new PasswordListWidget();
					available_widgets.Add(pass_list_wid);
					button=create_button(pass_list_wid.label,pass_list_wid.image);
					button.Clicked+=pass_list_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);

					reset_wid=new ResetPasswordsWidget();
					available_widgets.Add(reset_wid);
					button=create_button(reset_wid.label,reset_wid.image);
					button.Clicked+=reset_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);
				
					gescen_wid=new GescenImportWidget();
					available_widgets.Add(gescen_wid);
					button=create_button(gescen_wid.label,gescen_wid.image);
					button.Clicked+=gescen_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);
				
					regen_wid=new RegenerateHomesWidget();
					available_widgets.Add(regen_wid);	
					button=create_button(regen_wid.label,regen_wid.image);
					button.Clicked+=regen_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);

					imex_wid=new ImportExportWidget();
					available_widgets.Add(imex_wid);	
					button=create_button(imex_wid.label,imex_wid.image);
					button.Clicked+=imex_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);

					roadmin_wid=new ReadOnlyAdminWidget();
					available_widgets.Add(roadmin_wid);
					button=create_button(roadmin_wid.label,roadmin_wid.image);
					button.Clicked+=roadmin_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);

					delete_home_wid=new DeleteHomeWidget();
					available_widgets.Add(delete_home_wid);
					button=create_button(delete_home_wid.label,delete_home_wid.image);
					button.Clicked+=delete_home_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);
				
					delete_every_user_wid=new DeleteEveryUserWidget();
					available_widgets.Add(delete_every_user_wid);
					button=create_button(delete_every_user_wid.label, delete_every_user_wid.image);
					button.Clicked+=delete_every_user_wid.OnMenuButtonClicked;
					mw.addMenuButton(button);
					
					break;
				
				case "others":
				
					break;
				
				default:
				
					
					break;

			}
			
			mw.logoutButtonSensitive=true;
			
			
			
		}
		

	
		

		
		
		public static Core getCore()
		{
			if(Core.singleton==null)
			{
				return new Core();
				
					
			}
			
			
			
			return Core.singleton;
		}
		
	}
}
