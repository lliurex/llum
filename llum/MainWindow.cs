using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public llum.AnimatedButton button;
	public Gtk.Widget currentWidget;
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		
		
		
	//	button=new llum.AnimatedButton("textolargo",true);
	//	buttonVbox.PackStart(button,false,true,0);
	}

	
	public string statusText
	{
		set
		{
			statusLabel.Markup=value;	
			
		}
		
	}
	
	public bool logoutButtonSensitive
	{
		get
		{
			return disconnectButton.Sensitive;
		}
		set
		{
			disconnectButton.Sensitive=value;
		}	
	}
	
	
	public void clearMenuButton()
	{
		foreach(Gtk.Widget wid in buttonVbox.Children)
			buttonVbox.Remove(wid);
	}
	
	public void enableIcon(bool state)
	{
		if(state)
		{
			world_image.Show();
			statusLabel.Text=Mono.Unix.Catalog.GetString("Connection to Master server ready");
		}
		else
			world_image.Hide();
	}
	
	public void addMenuButton(Gtk.Button button)
	{
		

		
		
		buttonVbox.PackStart(button,false,false,5);
		
		
		
		
	}
	

	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected virtual void OnExitButtonClicked (object sender, System.EventArgs e)
	{
		Application.Quit();
		/*
		if(button.Visible)
			button.disappear();
		else
			button.appear();
		*/	
	}
	
	public void setCurrentWidget(Gtk.Widget widget)
	{
		if(currentWidget!=null)
			widgetVbox.Remove(currentWidget);
		
		currentWidget=widget;
		currentWidget.Show();
		widgetVbox.PackStart(currentWidget,true,true,5);
		
	}
	
	protected virtual void OnDisconnectButtonClicked (object sender, System.EventArgs e)
	{
		
		llum.Core core=llum.Core.getCore();
		core.available_widgets.Clear();
		foreach(Gtk.Widget wid in buttonVbox.Children)
			buttonVbox.Remove(wid);
		
		statusLabel.Text="";
		disconnectButton.Sensitive=false;
		core.loginwid=new llum.LoginWidget();
		setCurrentWidget(core.loginwid);
		
	}
	
	
	
}
