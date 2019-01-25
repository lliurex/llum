
using System;

namespace llum
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class AddGroupWidget : Gtk.Bin
	{

		
		public Gtk.Image image;
		public Gtk.Label label;
		protected virtual void OnNameEntryChanged (object sender, System.EventArgs e)
		{
			llum.Core core=llum.Core.getCore();
			
			nameEntry.Text=core.strip_special_chars(nameEntry.Text);
			bool result=false;
			if(nameEntry.Text.Length>0)
			{
				int test;
				string last_char=""+nameEntry.Text[nameEntry.Text.Length-1];
				result=int.TryParse(last_char,out test);
			}
			if(nameEntry.Text.Length>0)
			{

				if(result)
				{
					acceptButton.Sensitive=false;
					msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("Groups cannot end with a numerical character") + "</span>";
				}
				else
				{
					msgLabel.Text="";
					acceptButton.Sensitive=true;	
				}
			}
			
			if(nameEntry.Text.Length>0 && descriptionEntry.Text.Length>0 && !result)
				acceptButton.Sensitive=true;
			else
				acceptButton.Sensitive=false;
			
		}
		

		public void OnMenuButtonClicked(object sender, System.EventArgs e)
		{
			
			
			
			
			llum.Core.getCore().add_group_wid=new AddGroupWidget();
			
			llum.Core.getCore().mw.setCurrentWidget(llum.Core.getCore().add_group_wid);
			
		}		
		
		
		public AddGroupWidget ()
		{
			this.Build ();
			image=new Gtk.Image();
			image.SetFromIconName("gtk-add",Gtk.IconSize.Dnd);
			image.Show();
			label=new Gtk.Label(Mono.Unix.Catalog.GetString("Add Group"));
			label.Show();
			//gtk-dialog-authentication
			
			acceptButton.Sensitive=false;
			
			
			
			
			
			
			
		}
		protected virtual void OnDescriptionEntryChanged (object sender, System.EventArgs e)
		{
			bool result=false;
			if (nameEntry.Text.Length>0)
			{
				int test;
				
				string last_char=""+nameEntry.Text[nameEntry.Text.Length-1];
				result=int.TryParse(last_char,out test);
			}
			if(nameEntry.Text.Length>0 && descriptionEntry.Text.Length>0 && !result)
				acceptButton.Sensitive=true;
			else
				acceptButton.Sensitive=false;			
		}
		
		protected virtual void OnUndoButtonClicked (object sender, System.EventArgs e)
		{
			nameEntry.Text="";
			descriptionEntry.Text="";
		}
		

		
		protected virtual void OnAcceptButtonClicked (object sender, System.EventArgs e)
		{
			llum.Core core=llum.Core.getCore();
			
			CookComputing.XmlRpc.XmlRpcStruct properties=new CookComputing.XmlRpc.XmlRpcStruct();
			properties["cn"]=nameEntry.Text;
			properties["description"]=descriptionEntry.Text;
			properties["x-lliurex-grouptype"]="generic";
			
			string ret=core.xmlrpc.add_group(properties);
			
			if(ret=="true")
				msgLabel.Markup="<b>" + Mono.Unix.Catalog.GetString("Group successfully added") + "</b>";
			else
				msgLabel.Markup="<span foreground='red'>" + Mono.Unix.Catalog.GetString("An error was found when adding group:") + "\n" + ret + "</span>";
			
				
			
			
		}
		
		
		
		
		
	}
}
