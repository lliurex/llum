
using System;

namespace llum
{


	public class AnimatedButton : Gtk.Button
	{

		public int height;
		public int width;
		private int inc_width;
		private int dec_width;
		
		private int speed=1;
		private Gtk.Image custom_image;
		private Gtk.Label custom_label;
		private Gtk.HBox custom_hbox;
		
		
		
		public AnimatedButton (string label,bool from_zero)
		{
			custom_hbox=new Gtk.HBox();
			custom_label=new Gtk.Label(label);
			
			custom_label.LineWrap=true;
			custom_label.LineWrapMode=Pango.WrapMode.Word;
			custom_label.MaxWidthChars=30;
			
			custom_image=new Gtk.Image();
			custom_image.Pixbuf=Gdk.Pixbuf.LoadFromResource("llum.arrow.svg");
			
			custom_hbox.PackStart(custom_image,false,false,5);
			custom_hbox.PackStart(custom_label,false,false,5);
			
			
			
			
			custom_hbox.ShowAll();
			custom_image.Hide();
			custom_label.Hide();
				
			this.Add(custom_hbox);
			
			
			
			
			
			height=50;
			width=150;
			dec_width=width;
			
			this.Show();
			
			if(!from_zero)
				this.SetSizeRequest(width,height);
			else
			{
				appear();
			}
			
			
		}
		
		
		
		
		public void appear()
		{
			
			inc_width=0;
			GLib.Timeout.Add(2,increassing_size);	
			this.SetSizeRequest(0,height);
			this.Visible=true;
			
		}
		
		public void disappear()
		{
			custom_image.Hide();
			custom_label.Hide();
			dec_width=width;
			GLib.Timeout.Add(2,decreassing_size);	
			
		}
		
		private bool increassing_size()
		{
		
			if(inc_width>=width)
			{
				
				custom_image.Show();
				custom_label.Show();
				return false;	
			}
			else
			{
				
				inc_width+=speed;
				this.SetSizeRequest(inc_width,height);
				return true;
			}
		}
		
		private bool decreassing_size()
		{
			
			if(dec_width<=2)
			{
				
				this.Visible=false;
				return false;
			}
			else
			{
				
				
				dec_width-=speed;
				this.SetSizeRequest(dec_width,height);
				return true;
			}
		}
		
		
	}
}
