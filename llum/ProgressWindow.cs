
using System;

namespace llum
{


	public partial class ProgressWindow : Gtk.Window
	{

		public ProgressWindow (string msg) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.Title=msg;
			GLib.Timeout.Add(100,pulse_func);
		}
		
		public bool pulse_func()
		{
			progressbar1.Pulse();
			
			return this.Visible;
		}
		
	}
}
