
using System;

namespace llum
{


	
	public class LdapUser: System.IComparable<LdapUser>
	{

/*		
		self.attributes.append(("uid",uid))
		self.attributes.append(("cn",givenname))
		self.attributes.append(("sn",surname))
		self.attributes.append(("description",self.properties["description"]))
		self.attributes.append(('objectClass',list))
		self.attributes.append(("loginShell","/bin/bash"))
		self.attributes.append(("homeDirectory","/home/"+uid))		
*/		

		
		private class LdapUserComparer : System.Collections.Generic.IComparer<LdapUser>
		{
			public int Compare(LdapUser first, LdapUser second)
			{
				if(first==null & second==null)	
					return 0;
				else 
					if(first==null)
						return -1;
					else
						if(second==null)
							return 1;
						else
							if(first.uid.CompareTo(second.uid)<0)
								return -1;
							else
								if(first.uid.CompareTo(second.uid)==0)
									return 0;
								else
									return 1;
			}
		}
		
		public static System.Collections.Generic.IComparer<LdapUser> UserSorter
		{
			get {return new LdapUserComparer();}	
		}
		
		
		
		public string path;
		public string name;
		public string surname;
		public string uid;
		public string uidn;
		public string description;
		public System.Collections.Generic.List<string> groups;
		public string main_group;
		public bool ok_to_delete;
		public string user_type;
		public string nia;
		public string dni;
		public bool is_admin;
		
		
		
		
		public LdapUser (string path,string uid, string uidn, string name, string surname, string[] groups,string profile,string user_type,string nia, string dni, bool is_admin)
		{
			this.path=path;
			this.uid=uid;
			this.uidn=uidn;

			this.name=name;
			this.surname=surname;
			this.groups=new System.Collections.Generic.List<string>();
			if(groups!=null)
				foreach(string str in groups)
					this.groups.Add(str);
			this.main_group=profile;
			
			this.nia=nia;
			this.dni=dni;
			this.user_type=user_type;
			this.is_admin=is_admin;
			
			
		}
		
		public int CompareTo(LdapUser user)
		{
			if(user==null)	
				return 1;
			else
				if(this.uid.CompareTo(user.uid)<0)
					return -1;
				else
					if(this.uid.CompareTo(user.uid)==0)
						return 0;
					else
						return 1;
			
		}
	}
}
