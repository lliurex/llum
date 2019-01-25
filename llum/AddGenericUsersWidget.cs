
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class AddGenericUsersWidget : Gtk.Bin
	{

		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			
			llum.Core.getCore().add_generic_users_wid=new AddGenericUsersWidget();
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().add_generic_users_wid);
		}		
		
		
		
		public Gtk.Image image;
		public Gtk.Label label;
		
		private Gtk.TreeStore store;
		private System.Collections.Generic.List<string> group_list;
		public AddGenericUsersWidget ()
		{
			this.Build ();
			group_list=llum.Core.getCore().xmlrpc.get_available_groups();
			foreach(string str in group_list)
				groupCombobox.AppendText(str);
			
			if(group_list.Capacity>0)
				groupCombobox.Active=0;
			else
			{
				acceptButton.Sensitive=false;
				msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("You must create a group before adding generic users") + "</b>";
			}
			
			store=new Gtk.TreeStore(typeof(string),typeof(string));
			
			store.AppendValues(Mono.Unix.Catalog.GetString("Students"),"Students");
			store.AppendValues(Mono.Unix.Catalog.GetString("Teachers"),"Teachers");
			//store.AppendValues(Mono.Unix.Catalog.GetString("Other"),"Other");
			
			templateCombobox.Model=store;
			
			templateCombobox.Active=0;
			
			
			
			image=new Gtk.Image();
			image.SetFromIconName("gtk-add",Gtk.IconSize.Dnd);
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Add Generic Users"));
			label.Show();		
			
		}

		protected virtual void OnSetPasswordRadiobuttonClicked (object sender, System.EventArgs e)
		{
			if(setPasswordRadiobutton.Active)
			{
				passwordEntry.Sensitive=true;	
			}
			else
			{
				passwordEntry.Sensitive=false;	
				passwordEntry.Text="";
			}
		}
		
		protected virtual void OnSameAsUserRadiobuttonClicked (object sender, System.EventArgs e)
		{
			if(setPasswordRadiobutton.Active)
			{
				passwordEntry.Sensitive=true;	
			}
			else
			{
				passwordEntry.Sensitive=false;	
				passwordEntry.Text="";
			}	
			
			
			
			
		}
		
		protected virtual void OnRandomPasswordradiobuttonClicked (object sender, System.EventArgs e)
		{
			if(setPasswordRadiobutton.Active)
			{
				passwordEntry.Sensitive=true;
				
				if(genericNameEntry.Text!="")
				{
					acceptButton.Sensitive=true;
					if(passwordEntry.Text=="")
						acceptButton.Sensitive=false;


						
					
				}
				else
					acceptButton.Sensitive=false;						
				
				
			}
			else
			{
				passwordEntry.Sensitive=false;	
				passwordEntry.Text="";
			}
			
		
			
			
		}
		
		protected virtual void OnAcceptButtonClicked (object sender, System.EventArgs e)
		{
			
			System.Threading.Thread thread=null;
			string msg2="";
			msg2=Mono.Unix.Catalog.GetString("Creating generic users...");
						
			llum.Core.getCore().progress_window=new ProgressWindow(msg2);
			llum.Core.getCore().progress_window.ShowAll();
			llum.Core.getCore().progress_window.ShowNow();			
			
			System.Threading.ThreadStart progressTStart = delegate 
			{
				//ACTIONS
				
			llum.Core core=llum.Core.getCore();
			
			Gtk.TreeIter iter;
			templateCombobox.GetActiveIter(out iter);
			string template=(string)store.GetValue(iter,1);
			
			
			
			int number=(int)numberSpinbutton.Value;
			string group_cn=groupCombobox.ActiveText;
			string generic_name=genericNameEntry.Text;
			string password="";
			int option=core.xmlrpc.RANDOM_PASSWORDS;
			if(sameAsUserRadiobutton.Active)
				option=core.xmlrpc.PASS_EQUALS_USER;
			if(setPasswordRadiobutton.Active)
			{
				option=core.xmlrpc.SAME_PASSWORD;
				password=passwordEntry.Text;	
			}
			if(randomPasswordradiobutton.Active)
				option=core.xmlrpc.RANDOM_PASSWORDS;
			
			System.Collections.Generic.List<string>ret=core.xmlrpc.add_generic_users(template,group_cn,number,generic_name,option,password);
				
			Gtk.Application.Invoke(delegate{
				
				string msg="\n<b>" + Mono.Unix.Catalog.GetString("The following users were created:") + "\n";
					
				foreach(string str in ret)
				{
					msg+="[*] " + str + "\n";	
				}
				
				msg+="</b>";
					
				msgLabel.Markup=msg;
					
				Core.getCore().progress_window.Hide();
					
				});				

			};
			
			thread=new System.Threading.Thread(progressTStart);
			thread.Start();

	

			
			
			
			
		}
		
		protected virtual void OnUndoButtonClicked (object sender, System.EventArgs e)
		{
			passwordEntry.Text="";
			genericNameEntry.Text="";
			randomPasswordradiobutton.Active=true;
			groupCombobox.Active=0;
			templateCombobox.Active=0;
			numberSpinbutton.Value=1;
		}
		
		
		public static bool IsValidAlphaNumeric(string inputStr)
		{
		    //make sure the user provided us with data to check
		    //if not then return false
		    if (string.IsNullOrEmpty(inputStr)) 
		        return false;
		 
		    //now we need to loop through the string, examining each character
		    for (int i = 0; i < inputStr.Length; i++)
		    {
		        //if this character isn't a letter and it isn't a number then return false
		        //because it means this isn't a valid alpha numeric string
		        if (!(char.IsLetter(inputStr[i])))
		            return false;
		    }
		    //we made it this far so return true
		    return true;
		}		
		
		
		protected virtual void OnGenericNameEntryChanged (object sender, System.EventArgs e)
		{
			/*
			genericNameEntry.Text=llum.Core.getCore().strip_special_chars(genericNameEntry.Text);
			
			
			if(genericNameEntry.Text!="" && IsValidAlphaNumeric(genericNameEntry.Text))
			{
				if(setPasswordRadiobutton.Active)
				{
					if(passwordEntry.Text!="")
						acceptButton.Sensitive=true;
					else
						acceptButton.Sensitive=false;
				}
				else
					acceptButton.Sensitive=true;
				
			}
			else
				acceptButton.Sensitive=false;
			*/
				
		}
		
		protected virtual void OnPasswordEntryChanged (object sender, System.EventArgs e)
		{
			if(genericNameEntry.Text!="")
			{
				if(setPasswordRadiobutton.Active)
				{
					if(passwordEntry.Text!="")
						acceptButton.Sensitive=true;
					else
						acceptButton.Sensitive=false;
				}
				else
					acceptButton.Sensitive=true;
				
			}
			else
				acceptButton.Sensitive=false;			
		}
		
		protected virtual void OnGroupComboboxChanged (object sender, System.EventArgs e)
		{
			genericNameEntry.Text=groupCombobox.ActiveText;
			exampleLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("User sample:") + "</b> " + genericNameEntry.Text + "01";
		}
		
		
		
		
		
		
		
		
		
		
		
	}
}
