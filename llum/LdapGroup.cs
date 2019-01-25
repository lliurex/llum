
using System;

namespace llum
{


	public class LdapGroup
	{
		public string gid;
		public string gid_number;
		public string description;
		public System.Collections.Generic.List<string> member_list;
		public string path;
		
		
		
		
		public LdapGroup (string gid, string gid_number, string description,System.Collections.Generic.List<string> member_list,string path)
		{
			this.gid=gid;
			this.gid_number=gid_number;
			this.description=description;
			this.member_list=member_list;
			this.path=path;
		}
	}
}
