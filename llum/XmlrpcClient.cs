using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;


using CookComputing.XmlRpc;


namespace llum
{

	public interface Client : IXmlRpcProxy
	{
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct login(string[] user_info, string class_name,string[] user_pass);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct add_user(string[]user_info,string class_name,string plantille, CookComputing.XmlRpc.XmlRpcStruct user_properties,bool generic);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct exist_home_or_create(string[]user_info,string class_name, CookComputing.XmlRpc.XmlRpcStruct user_properties);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct restore_groups_folders(string[]user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct restore_acls(string[]user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct restore_acls_via_thread(string[]user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct is_acl_thread_alive(string[]user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct get_admin_function_list(string[]user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct change_own_password(string[] user_info, string class_name, string[] user_info2, string new_password);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct get_student_list(string[] user_info, string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct get_user_list(string[] user_info, string class_name,string filter);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct get_available_groups(string[] user_info, string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct add_to_group(string[] user_info, string class_name, string uid, string group_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct remove_from_group(string[] user_info, string class_name, string uid, string group_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct change_student_personal_data(string[] user_info, string class_name, string uid, string name, string surname);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct change_password(string[] user_info,string class_name,string path, string password,string uid, string cn, string sn, bool auto);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct change_student_password(string[] user_info,string class_name,string uid, string password);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct delete_student(string[] user_info,string class_name, string uid, bool delete_data);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct delete_teacher(string[] user_info,string class_name, string uid, bool delete_data);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct delete_other(string[] user_info, string class_name, string uid, bool delete_data);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct add_teacher_to_admins(string[] user_info,string class_name,string uid);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct change_group_description(string[] user_info,string class_name,string gid, string description);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct del_teacher_from_admins(string[] user_info, string class_name,string uid);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct delete_group(string[] user_info,string class_name,string gid);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct light_get_user_list(string[] user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct add_group(string[] user_info, string class_name,CookComputing.XmlRpc.XmlRpcStruct dic);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct add_generic_users(string[] user_info,string class_name, string template, string group_cn,int number, string generic_name, int pwd_generation_type, string pwd);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct get_students_passwords(string[] user_info, string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct get_all_passwords(string[] user_info, string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct get_teachers_passwords(string[] user_info, string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct delete_students(string[] user_info, string class_name, bool delete_data);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct delete_teachers(string[] user_info, string class_name, bool delete_data);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct delete_all(string[] user_info, string class_name, bool delete_data);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct generic_student_to_itaca(string[] user_info,string class_name,string uid, string nia);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct generic_teacher_to_itaca(string[] user_info,string class_name,string uid, string nif);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct send_xml_to_server(string[] user_info, string class_name, string base64data, string file_name, string passwd);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct gescen_groups(string[] user_info, string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct gescen_partial(string[] user_info,string class_name,string[] user_list);
		[XmlRpcMethod]	
		CookComputing.XmlRpc.XmlRpcStruct gescen_full(string[] user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct empty_students(string[] user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct empty_teachers(string[] user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct empty_others(string[] user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct empty_all(string[] user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct freeze_user(string[] user_info,string class_name,string[] uid);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct unfreeze_user(string[] user_info,string class_name,string[] uid);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct freeze_group(string[] user_info,string class_name,string[] cn);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct unfreeze_group(string[] user_info,string class_name,string[] cn);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct get_frozen_groups(string[] user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct get_frozen_users(string[] user_info, string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct get_methods();
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct get_variable(string variable_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct export_llum_info(string[] user_info,string class_name);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct import_llum_info(string[] user_info,string class_name,CookComputing.XmlRpc.XmlRpcStruct dic);
		[XmlRpcMethod]
		CookComputing.XmlRpc.XmlRpcStruct is_roadmin_available(string[] user_info,string class_name);
	}	
	

	public class XmlrpcClient
	{
		
		public Client client;

		public int RANDOM_PASSWORDS=0;
		public int SAME_PASSWORD=1;
		public int PASS_EQUALS_USER=2;
		
		private string[] get_groups(CookComputing.XmlRpc.XmlRpcStruct item)
		{
			Object[] groups_object=(Object[])item["groups"];
			string[] groups=new string[groups_object.Length];
			int i=0;
			foreach(Object a2 in groups_object)
			{
				groups[i]=Convert.ToString(a2);
				
				i++;
			}
			
			return groups;
		}		
		
		
		public XmlrpcClient ()
		{

			
			try
			{
				ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
				client=XmlRpcProxyGen.Create<Client>();
				if(llum.Core.getCore().server=="https://server:9779")

					llum.Core.getCore().server="https://"+System.Net.Dns.GetHostEntry("server").AddressList[0].ToString()+":9779";


				client.Url=llum.Core.getCore().server;
				//Core.getCore().mw.statusText=Mono.Unix.Catalog.GetString("Conexión al servidor con éxito");
			}
			catch
			{
				//Core.getCore().mw.statusText=Mono.Unix.Catalog.GetString("Conexión al servidor fallida");
			}			
			
		}
		
		public string get_master_ip()
		{
			try
			{
				return (string)client.get_variable("MASTER_SERVER_IP")["return"];
			}
			catch
			{
				//Console.WriteLine(e);
				return null;	
			}
			
			
		}
		
		public System.Collections.Generic.List<string> get_available_groups()
		{
			llum.Core core=llum.Core.getCore();
			CookComputing.XmlRpc.XmlRpcStruct new_ret=client.get_available_groups(core.user_info,"Golem");
			System.Array groups=((System.Array)new_ret["return"]);
			System.Collections.Generic.List<string> group_list=new System.Collections.Generic.List<string>();
			foreach(CookComputing.XmlRpc.XmlRpcStruct item in groups)
			{
				group_list.Add(((string[])item["cn"])[0]);
			}
		
			
			return group_list;
			
			
		}
		
		public System.Collections.Generic.List<llum.LdapGroup> get_available_groups_info()
		{
			llum.Core core=llum.Core.getCore();
			CookComputing.XmlRpc.XmlRpcStruct new_ret=client.get_available_groups(core.user_info,"Golem");
			System.Array groups=((System.Array)new_ret["return"]);
			
			System.Collections.Generic.List<llum.LdapGroup> group_list=new System.Collections.Generic.List<llum.LdapGroup>();
			
			llum.LdapGroup group_;
			
			foreach(CookComputing.XmlRpc.XmlRpcStruct item in groups)
			{
				/*
				
					public string gid;
					public string gid_number;
					public string description;
					public System.Collections.Generic.List<string> member_list;
					public string path;				
				*/

				string gid=((string[])item["cn"])[0];
				string gid_number=((string[])item["gidNumber"])[0];
				string description=((string[])item["description"])[0];
				System.Collections.Generic.List<string> member_list=new System.Collections.Generic.List<string>();
				
				if(item.ContainsKey("memberUid"))
					foreach(string str in (string[])item["memberUid"])
						member_list.Add(str);	
				
				string path=(string)item["path"];
				group_=new LdapGroup(gid,gid_number,description,member_list,path);
				group_list.Add(group_);
				
			}
			
			return group_list;
			
		}
		
		
		public string add_to_group(string user, string group_name)
		{
			llum.Core core=llum.Core.getCore();
			string ret;
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.add_to_group(core.user_info,"Golem",user,group_name);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="false";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="false";
			}
			
			return ret;
		}

		public string remove_from_group(string user,string group_name)
		{
			llum.Core core=llum.Core.getCore();
			
			string ret;
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.remove_from_group(core.user_info,"Golem",user,group_name);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="false";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="false";
			}
			
			return ret;
			
		}
		
		public string change_student_personal_data(string user, string name, string surname)
		{
			llum.Core core=llum.Core.getCore();
			
			string ret;
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.change_student_personal_data(core.user_info,"Golem",user,name,surname);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="false";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="false";
			}
			
			return ret;
			

		}
		
		public string change_student_password(string uid, string password)
		{
			llum.Core core=llum.Core.getCore();
			string ret;
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.change_student_password(core.user_info,"Golem",uid,password);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="false";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="false";
			}
			
			return ret;
		}
		
		public string change_password(string path, string password,bool auto)
		{
			llum.Core core=llum.Core.getCore();
			string ret;
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.change_password(core.user_info,"Golem",path,password,"","","",auto);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="false";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="false";
			}

			return ret;
			
		}
		
		public string change_teacher_password(string path, string password,string uid, string cn, string sn, bool auto)
		{
			llum.Core core=llum.Core.getCore();
			string ret;
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.change_password(core.user_info,"Golem",path,password,uid,cn,sn,auto);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="false";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="false";
			}
			

			return ret;
		}
		
		public string delete_student(string uid, bool delete_data)
		{
			llum.Core core=llum.Core.getCore();
			string ret="";
			try
			{
				
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.delete_student(core.user_info,"Golem",uid, delete_data);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="XMLRPC ERROR";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="XMLRPC ERROR";
			}
			return ret;
		}
		
		public string delete_other(string uid, bool delete_data)
		{
			llum.Core core=llum.Core.getCore();
			string ret="";
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.delete_other(core.user_info,"Golem",uid, delete_data);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="XMLRPC ERROR";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="XMLRPC ERROR";
			}
			return ret;
		}

		public string delete_teacher(string uid, bool delete_data)
		{
			llum.Core core=llum.Core.getCore();
			string ret="";
			try
			{
				//ret=client.delete_teacher(core.user_info,"Golem",uid, delete_data);
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.delete_teacher(core.user_info,"Golem",uid, delete_data);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="XMLRPC ERROR";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="XMLRPC ERROR";	
			}
			return ret;
		}		
		
		public string add_user(string plantille, CookComputing.XmlRpc.XmlRpcStruct user_properties)
		{
			//tring add_user(string[]user_info,string class_name,string plantille,string uid,string name,string surname,string password);			
			llum.Core core=llum.Core.getCore();
			string old_ret="";
			CookComputing.XmlRpc.XmlRpcStruct ret;
			try
			{
				ret=client.add_user(core.user_info,"Golem",plantille,user_properties,false);
				if(ret.ContainsKey("status"))
					if(Convert.ToInt32(ret["status"])==0)
						old_ret=Convert.ToString(ret["return"]);
				else
					old_ret="XMLRP ERROR";
					
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
				old_ret="XMLRPC ERROR";	
			}
			return old_ret;
			
			
		}
		public string add_teacher_to_admins(string uid)
		{
			llum.Core core=llum.Core.getCore();
			string ret="";
			try
			{
				//ret=client.add_teacher_to_admins(core.user_info,"Golem",uid);
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.add_teacher_to_admins(core.user_info,"Golem",uid);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="XMLRPC ERROR";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="XMLRPC ERROR";
			}
			
			return ret;
		}
		
		public string del_teacher_from_admins(string uid)
		{
			llum.Core core=llum.Core.getCore();
			string ret="";
			
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.del_teacher_from_admins(core.user_info,"Golem",uid);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="XMLRPC ERROR";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="XMLRPC ERROR";
			}

			return ret;
			

		}
		
		public string change_group_description(string gid, string description)
		{
			llum.Core core=llum.Core.getCore();
			string ret="";
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.change_group_description(core.user_info,"Golem",gid,description);	
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="false";
				else
					ret=(string)new_ret["return"];
			}
			catch
			{
				ret="false";
			}
			
			return ret;

		}
		
		public System.Collections.Generic.List<LdapUser>get_user_list()
		{
			llum.Core core=llum.Core.getCore();

			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.get_user_list(core.user_info,"Golem","*");
				if(Convert.ToInt32(new_ret["status"])!=0)
					return null;
				
				System.Array array=(System.Array)new_ret["return"];
				System.Collections.Generic.List<LdapUser> user_list=new System.Collections.Generic.List<LdapUser>();
				
				foreach(CookComputing.XmlRpc.XmlRpcStruct item in array)
				{

					
					string user_type="";
					string nia="";
					string dni="";
					
	
					if(item.ContainsKey("x-lliurex-usertype"))
					{
						user_type=Convert.ToString(item["x-lliurex-usertype"]);
						
					}
					
					if(item.ContainsKey("x-lliurex-nia"))
					{
						nia=Convert.ToString(item["x-lliurex-nia"]);
						
					}
					
					if(item.ContainsKey("x-lliurex-nif"))
					{
						dni=Convert.ToString(item["x-lliurex-nif"]);
						
					}
					
				
					
					LdapUser user=new LdapUser(
					                           Convert.ToString(item["path"]),
					                           Convert.ToString(item["uid"]),
					                           Convert.ToString(item["uidNumber"]),
					                           Convert.ToString(item["cn"]),
					                           Convert.ToString(item["sn"]),
					                           get_groups(item),
					                           Convert.ToString(item["profile"]),
					                           user_type,
					                           nia,
					                           dni,
					                           Convert.ToBoolean(item["is_admin"]));
					
					
					                           
					 user_list.Add(user);
	         
					
					
				}
				
				
				
				user_list.Sort(LdapUser.UserSorter);
				
				return user_list;
			}
			catch(Exception e)
			{
				Console.WriteLine (e);
				return null;	
			}
			
		}
		
		public string delete_group(string gid)
		{
			llum.Core core=llum.Core.getCore();
			
			string ret="";
			
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.delete_group(core.user_info,"Golem",gid);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="XMLRPC ERROR";
				else
					ret=(string)new_ret["return"];				
			}
			catch
			{
				ret="XMLRPC ERROR";
			}
			return ret;
			
			
		}
		
		public System.Collections.Generic.List<LdapUser>  light_get_user_list()
		{
			System.Collections.Generic.List<LdapUser>users=new System.Collections.Generic.List<llum.LdapUser>();
			llum.Core core=llum.Core.getCore();
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.light_get_user_list(core.user_info,"Golem");
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					System.Array array_list=(System.Array)new_ret["return"];
				
					foreach(string[] array in array_list)
					{
						LdapUser user=new LdapUser(array[0],array[1],array[2],array[3],array[4],null,array[5],"","","",false);
						users.Add(user);
					}
				
					users.Sort();
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
			
			return users;				
			
		}

		public System.Collections.Generic.List<string> add_generic_users(string template, string group_cn, int number, string generic_name, int pwd_generation_type, string pwd)
		{
			llum.Core core=llum.Core.getCore();
			System.Collections.Generic.List<string> ret=new System.Collections.Generic.List<string>();
			
			
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.add_generic_users(core.user_info,"Golem",template,group_cn, number, generic_name, pwd_generation_type, pwd);
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					System.Array array=(System.Array)new_ret["return"];
					foreach(CookComputing.XmlRpc.XmlRpcStruct item in array)
					{
							if(item.ContainsKey("ERROR"))
							{
								
								ret.Add((string)item["ERROR"]);
								
							}
							else
								ret.Add((string)item["uid"]);
					}
				}
			
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
			
			return ret;
			
		}
		
		
		public string add_group(CookComputing.XmlRpc.XmlRpcStruct dic)
		{
			llum.Core core=llum.Core.getCore();
			string ret="";
			
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.add_group(core.user_info,"Golem",dic);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="XMLRPC ERROR";
				else
					ret=(string)new_ret["return"];				
			}
			catch
			{
				ret="XMLRPC ERROR";
			}
			return ret;			
			
		}
		
		public System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct> get_all_passwords()
		{
		
			llum.Core core=llum.Core.getCore();
			
			System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct> ret=new System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct>();
			
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.get_all_passwords(core.user_info,"Golem");
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					System.Array res=(System.Array)new_ret["return"];
				
					foreach(CookComputing.XmlRpc.XmlRpcStruct item in res)
					{
						ret.Add(item);
					}
				
					
				}
				return ret;
			}
			catch
			{
				return new System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct>();	
			}
			
		}
		
		public System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct> get_students_passwords()
		{
			llum.Core core=llum.Core.getCore();
			try
			{
				System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct> ret=new System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct>();
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.get_students_passwords(core.user_info,"Golem");
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					System.Array res=(System.Array)new_ret["return"];
				
					foreach(CookComputing.XmlRpc.XmlRpcStruct item in res)
					{
						ret.Add(item);
					}
				
					
				}
				return ret;
			}
			catch
			{
				return new System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct>();	
			}
			
		}
		
		public System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct> get_teachers_passwords()
		{
			

			llum.Core core=llum.Core.getCore();
			try
			{
				System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct> ret=new System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct>();
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.get_teachers_passwords(core.user_info,"Golem");
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					System.Array res=(System.Array)new_ret["return"];
				
					foreach(CookComputing.XmlRpc.XmlRpcStruct item in res)
					{
						ret.Add(item);
					}
				
					
				}
				return ret;
			}
			catch
			{
				return new System.Collections.Generic.List<CookComputing.XmlRpc.XmlRpcStruct>();	
			}			
			
		}
		
		public System.Collections.Generic.List<string> delete_students(bool delete_data)
		{
			System.Collections.Generic.List<string>ret_list=new System.Collections.Generic.List<string>();
			llum.Core core=llum.Core.getCore();
			CookComputing.XmlRpc.XmlRpcStruct new_ret=client.delete_students(core.user_info,"Golem",delete_data);
			if(Convert.ToInt32(new_ret["status"])==0)
			{	
				try
				{
					string[] ret_array=(string[])new_ret["return"];
					foreach(string str in ret_array)
					{
						ret_list.Add(str);	
					}
				}
				catch
					return ret_list;
			}
			
			return ret_list;
			
		}

		public System.Collections.Generic.List<string> delete_teachers(bool delete_data)
		{
			System.Collections.Generic.List<string>ret_list=new System.Collections.Generic.List<string>();
			llum.Core core=llum.Core.getCore();
			CookComputing.XmlRpc.XmlRpcStruct new_ret=client.delete_teachers(core.user_info,"Golem",delete_data);
			if(Convert.ToInt32(new_ret["status"])==0)
			{
				try
				{
					string[] ret_array=(string[])new_ret["return"];
					foreach(string str in ret_array)
					{
						ret_list.Add(str);	
					}
				}
				catch
					return ret_list;
			}
			
			return ret_list;
			
		}		
		
		public System.Collections.Generic.List<string> delete_all(bool delete_data)
		{
			System.Collections.Generic.List<string>ret_list=new System.Collections.Generic.List<string>();
			llum.Core core=llum.Core.getCore();
			CookComputing.XmlRpc.XmlRpcStruct new_ret=client.delete_all(core.user_info,"Golem",delete_data);
			if(Convert.ToInt32(new_ret["status"])==0)
			{
				try
				{
					string[] ret_array=(string[])new_ret["return"];
					foreach(string str in ret_array)
					{
						ret_list.Add(str);	
					}
				}
				catch
					return ret_list;
			}
			
			return ret_list;
			
		}
		
		public string generic_student_to_itaca(string uid,string nia)
		{
			llum.Core core=llum.Core.getCore();
			
			string ret="";
			
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.generic_student_to_itaca(core.user_info,"Golem",uid,nia);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="XMLRPC ERROR";
				else
					ret=(string)new_ret["return"];				
			}
			catch
			{
				ret="XMLRPC ERROR";
			}
			return ret;	
			
			
		}
		
		public string generic_teacher_to_itaca(string uid,string nif)
		{
			llum.Core core=llum.Core.getCore();
			
			string ret="";
			
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.generic_teacher_to_itaca(core.user_info,"Golem",uid,nif);
				if(Convert.ToInt32(new_ret["status"])!=0)
					ret="XMLRPC ERROR";
				else
					ret=(string)new_ret["return"];				
			}
			catch
			{
				ret="XMLRPC ERROR";
			}
			return ret;	
		}
		
		
		public string send_xml_to_server(string local_file_path,string passwd)
		{
			llum.Core core=llum.Core.getCore();
			
			if(System.IO.File.Exists(local_file_path))
			{
				string data64=Convert.ToBase64String(System.IO.File.ReadAllBytes(local_file_path));
				string[] list=local_file_path.Split('/');
				string file_name=list[list.Length-1];
				try
				{
					CookComputing.XmlRpc.XmlRpcStruct new_ret=client.send_xml_to_server(core.user_info,"Golem",data64,file_name,passwd);
					if(Convert.ToInt32(new_ret["status"])==0)
					{
						string ret=(string)new_ret["return"];
						data64=null;
						switch(ret)
						{
							case "true":
								
								return "true";
							
							
							case "false:xml_error":
							
								return Mono.Unix.Catalog.GetString("The XML file generated by Gescen/Itaca contains errors. Importation failed");
							
							case "false:send_error":
							
								return Mono.Unix.Catalog.GetString("The XML file could not be sent to the server.");
							
							case "false:xml_encrypted":
							
								return "false:encrypted:" + Mono.Unix.Catalog.GetString ("XML is encrypted. You need to enter a password to decrypt the file.");
							
							case "false:invalid_xml":
							
								return Mono.Unix.Catalog.GetString("It's not a valid XML file.");
							
							case "false:xml_bad_password":
							
								return Mono.Unix.Catalog.GetString ("Invalid ITACA password");
							
							default:
							
								return Mono.Unix.Catalog.GetString("Unknown error");
							
						}
					}
					
					return Mono.Unix.Catalog.GetString("N4D Call failed.");	
					

				}
				catch(Exception e)
				{
					Console.WriteLine (e);
					return Mono.Unix.Catalog.GetString("XML parsing error.");	
				}
				
			}
			else 
				return Mono.Unix.Catalog.GetString("The XML file doesn't exist");
				
		}
		
		public System.Collections.Generic.List<string> gescen_groups()
		{
			llum.Core core=llum.Core.getCore();
			System.Collections.Generic.List<string> list=new System.Collections.Generic.List<string>();
			
			try
			
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.gescen_groups(core.user_info,"Golem");
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					string[] ret=(string[])new_ret["return"];
					
					foreach(string str in ret)
					{
						list.Add(str);	
					}
				}
				
				return list;
			}
			catch
			{
				return null;	
			}
				
			
		}
		
		public bool gescen_partial(string[] user_list)
		{
			llum.Core core=llum.Core.getCore();
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.gescen_partial(core.user_info,"Golem",user_list);	
				if(Convert.ToInt32(new_ret["status"])==0)
				{
				
					string ret=(string)new_ret["return"];
					
					if (ret=="true")
						return true;
					else
						return false;
				}
				else
					return false;
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
				return false;	
			}
			
		}
		
		public System.Collections.Generic.List<LdapUser> gescen_full()
		{
			llum.Core core=llum.Core.getCore();	
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.gescen_full(core.user_info,"Golem");
				System.Collections.Generic.List<LdapUser> ret_list=new System.Collections.Generic.List<LdapUser>();
					
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					CookComputing.XmlRpc.XmlRpcStruct ret=(CookComputing.XmlRpc.XmlRpcStruct)new_ret["return"];
					foreach(string str in ret.Keys)
					{
					
						string path="";
						string uid=(string)((CookComputing.XmlRpc.XmlRpcStruct)ret[str])["uid"];
						string uidn=(string)((CookComputing.XmlRpc.XmlRpcStruct)ret[str])["uidNumber"];
						string name=(string)((CookComputing.XmlRpc.XmlRpcStruct)ret[str])["cn"];
						string surname=(string)((CookComputing.XmlRpc.XmlRpcStruct)ret[str])["sn"];
						string[] groups=null;
						string profile=(string)((CookComputing.XmlRpc.XmlRpcStruct)ret[str])["profile"];
						string user_type="";
						string nia="";
						string dni="";
						
						
						LdapUser user=new LdapUser(path,uid,uidn,name,surname,groups,profile,user_type,nia,dni,false);
						user.ok_to_delete=true;
						ret_list.Add(user);
						
						
					}
					return ret_list;

				}
				else
					return null;
				
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
			
		}

		public System.Collections.Generic.List<string> empty_students()
		{
			System.Collections.Generic.List<string>ret_list=new System.Collections.Generic.List<string>();
			llum.Core core=llum.Core.getCore();
			
			CookComputing.XmlRpc.XmlRpcStruct new_ret=client.empty_students(core.user_info,"Golem");	
			if(Convert.ToInt32(new_ret["status"])==0)
			{
				string[] ret_array=(string[])new_ret["return"];
				foreach(string str in ret_array)
				{
					ret_list.Add(str);	
				}
			}
			
			return ret_list;
			
		}		
		
		public System.Collections.Generic.List<string> empty_teachers()
		{
			System.Collections.Generic.List<string>ret_list=new System.Collections.Generic.List<string>();
			llum.Core core=llum.Core.getCore();
			
			CookComputing.XmlRpc.XmlRpcStruct new_ret=client.empty_teachers(core.user_info,"Golem");	
			if(Convert.ToInt32(new_ret["status"])==0)
			{
				string[] ret_array=(string[])new_ret["return"];
				foreach(string str in ret_array)
				{
					ret_list.Add(str);	
				}
			}
			
			return ret_list;
			
		}
		
		public System.Collections.Generic.List<string> empty_others()
		{
			System.Collections.Generic.List<string>ret_list=new System.Collections.Generic.List<string>();
			llum.Core core=llum.Core.getCore();
			
			CookComputing.XmlRpc.XmlRpcStruct new_ret=client.empty_others(core.user_info,"Golem");	
			if(Convert.ToInt32(new_ret["status"])==0)
			{
				string[] ret_array=(string[])new_ret["return"];
				foreach(string str in ret_array)
				{
					ret_list.Add(str);	
				}
			}
			
			return ret_list;
			
		}

		public System.Collections.Generic.List<string> empty_all()
		{
			System.Collections.Generic.List<string>ret_list=new System.Collections.Generic.List<string>();
			llum.Core core=llum.Core.getCore();
			
			CookComputing.XmlRpc.XmlRpcStruct new_ret=client.empty_all(core.user_info,"Golem");	
			if(Convert.ToInt32(new_ret["status"])==0)
			{
				string[] ret_array=(string[])new_ret["return"];
				foreach(string str in ret_array)
				{
					ret_list.Add(str);	
				}
			}
			
			return ret_list;
			
		}
		
		public System.Collections.Generic.List<string> get_frozen_groups()
		{
			System.Collections.Generic.List<string> ret=new System.Collections.Generic.List<string>();
			llum.Core core=llum.Core.getCore();
			
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.get_frozen_groups(core.user_info,"Golem");
				Console.WriteLine(1);
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					if(((System.Object[])new_ret["return"]).Length>0)
					{
						string[] ret_strings=(string[])new_ret["return"];
						foreach(string str in ret_strings)
							ret.Add(str);
					}
				}
				return ret;
			}
			catch(Exception e)
			{
				Console.WriteLine("get_frozen_groups not ready");
				Console.WriteLine(e);
				return ret;	
			}
			
		}
		
		public System.Collections.Generic.List<string> get_frozen_users()
		{
			System.Collections.Generic.List<string> ret=new System.Collections.Generic.List<string>();
			try
			{
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.get_frozen_users(llum.Core.getCore().user_info,"Golem");	
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					if(((System.Object[])new_ret["return"]).Length>0)
					{
						string[] ret_strings=(string[])new_ret["return"];
						foreach(string str in ret_strings)
							ret.Add(str);
					}
				}
				
				return ret;
				
			}
			catch(Exception e)
			{
				Console.WriteLine("get_frozen_users");
				Console.WriteLine(e);
				return ret;
			}
		}
		
		public bool freeze_user(string uid)
		{
			llum.Core core=llum.Core.getCore();
			try
			{
				string[] param=new string[1];
				param[0]=uid;
				
				client.freeze_user(core.user_info,"Golem",param);
				return true;
			}
			catch
			{
				return false;
			}
		}
		
		public bool regenerate_net_files()
		{
			try
			{
				
				llum.Core core=llum.Core.getCore();	
				 
				foreach(LdapUser user in this.light_get_user_list())
				{
					CookComputing.XmlRpc.XmlRpcStruct user_properties=new CookComputing.XmlRpc.XmlRpcStruct();
					user_properties["profile"]=user.main_group;
					user_properties["uid"]=user.uid;
					user_properties["uidNumber"]=user.uidn;
					try{
						this.client.exist_home_or_create(core.user_info,"Golem",user_properties);
					}
					catch
					{
						
					}
					
				}				
				
				try
				{
					this.client.restore_groups_folders(core.user_info,"Golem");
				}
				catch
				{
					
				}
				
				return true;
			}
			catch
			{
				//Console.WriteLine(e);
				return false;
			}
			
		}
		
		public string restore_acls()
		{
			
			try
			{
				llum.Core core=llum.Core.getCore();
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.restore_acls(core.user_info,"NetFoldersManager");
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					System.Array ret=(System.Array)new_ret["return"];

					if((bool)ret.GetValue(0))
					{
						return null;
					}
					else
					{
						return (string)ret.GetValue(1);	
					}
				}
				else
					return (string)new_ret["msg"];
			}
			catch(Exception e)
			{
				
					return e.ToString();
					
			}
		}
		
		public bool restore_acls_via_thread()
		{
			try
			{
				llum.Core core=llum.Core.getCore();
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.restore_acls_via_thread(core.user_info,"NetFoldersManager");
				
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					return (bool)new_ret["return"];


				}
				else
				{
					Console.WriteLine((string)new_ret["msg"]);
					return false;
				}
				
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
				return false;
			}
			
		}
		
		public int is_acl_thread_alive()
		{
			try
			{
				llum.Core core=llum.Core.getCore();
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.is_acl_thread_alive(core.user_info,"NetFoldersManager");
				
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					if((bool)new_ret["return"])
						return 0;
					else
						return 1;


				}
				else
				{
					return -2;
				}
				

			}
			catch(Exception e)
			{
				Console.WriteLine (e);
				return -2;	
			}
			
			
		}
		
		
		public bool unfreeze_user(string uid)
		{
			llum.Core core=llum.Core.getCore();
			try
			{
				string[] param=new string[1];
				param[0]=uid;
				client.unfreeze_user(core.user_info,"Golem",param);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool freeze_group(string cn)
		{
			llum.Core core=llum.Core.getCore();
			try
			{
				string[] param=new string[1];
				param[0]=cn;
				client.freeze_group(core.user_info,"Golem",param);
				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
				return false;
				
			}
		}		
		

		public bool unfreeze_group(string cn)
		{
			llum.Core core=llum.Core.getCore();
			try
			{
				string[] param=new string[1];
				param[0]=cn;
				client.unfreeze_group(core.user_info,"Golem",param);
				return true;
			}
			catch
			{
				return false;
			}
		}
		
		public CookComputing.XmlRpc.XmlRpcStruct get_methods()
		{
			
			try
			{
				return (CookComputing.XmlRpc.XmlRpcStruct)client.get_methods()["return"];
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
				return null;	
			}
		}

		public bool export_llum_info(string file_path)
		{
			try
			{
				llum.Core core=llum.Core.getCore();
				
				CookComputing.XmlRpc.XmlRpcStruct new_ret=client.export_llum_info(core.user_info,"Golem");
				
				if(Convert.ToInt32(new_ret["status"])==0)
				{
					System.Array ret=(System.Array)new_ret["return"];

					if((bool)ret.GetValue(0))
					{
						CookComputing.XmlRpc.XmlRpcStruct s=(CookComputing.XmlRpc.XmlRpcStruct)ret.GetValue(1);
						string data=JsonConvert.SerializeObject(s,Newtonsoft.Json.Formatting.Indented);
						System.IO.File.WriteAllText(file_path,data,Encoding.UTF8);

						return(true);
					}
					else
						return(false);
				}
				return(false);
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
				return(false);
			}
		}

		public bool is_roadmin_available()
		{
			try
			{
				return (bool)client.is_roadmin_available(llum.Core.getCore().user_info,"Golem")["return"];
			}
			catch
			{
				return false;
			}
		}

		public bool import_llum_info(string file_path)
		{
			try{
				System.IO.StreamReader file = System.IO.File.OpenText(file_path);
				string data= file.ReadToEnd();
				System.Collections.Generic.Dictionary<string,object> ss=JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string,object>>(data);
				CookComputing.XmlRpc.XmlRpcStruct dic=new XmlRpcStruct();
				XmlRpcStruct users=new XmlRpcStruct();
				XmlRpcStruct groups=new XmlRpcStruct();

				string tmp;
				tmp=JsonConvert.SerializeObject(ss["users"]);
				System.Collections.Generic.Dictionary<string,object> tmp2=JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string,object>>(tmp);

				foreach( string x in tmp2.Keys)
				{
					System.Collections.Generic.Dictionary<string,object> tmp3=JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string,object>>(JsonConvert.SerializeObject(tmp2[x]));
					XmlRpcStruct user=new XmlRpcStruct();
					user["cn"]=(string)tmp3["cn"];
					user["sn"]=(string)(tmp3["sn"]);
					user["is_admin"]=(bool)(tmp3["is_admin"]);
					user["profile"]=(string)(tmp3["profile"]);
					user["userPassword"]=(string)(tmp3["userPassword"]);
					user["sambaLMPassword"]=(string)(tmp3["sambaLMPassword"]);
					user["sambaNTPassword"]=(string)(tmp3["sambaNTPassword"]);
					if(tmp3.ContainsKey("uidNumber"))
						user["uidNumber"]=(string)(tmp3["uidNumber"]);
					if(tmp3.ContainsKey("x-lliurex-usertype"))
						user["x-lliurex-usertype"]=(string)(tmp3["x-lliurex-usertype"]);
					else
						user["x-lliurex-usertype"]="generic";
					if(tmp3.ContainsKey("known_password"))
                                                user["known_password"]=(string)(tmp3["known_password"]);
					
					user["groups"]=JsonConvert.DeserializeObject<string[]>(JsonConvert.SerializeObject(tmp3["groups"]));
					users[x]=user;
				}
					
				tmp=JsonConvert.SerializeObject(ss["groups"]);
				tmp2=JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string,object>>(tmp);

				foreach( string x in tmp2.Keys)
				{
					System.Collections.Generic.Dictionary<string,object> tmp3=JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string,object>>(JsonConvert.SerializeObject(tmp2[x]));
					XmlRpcStruct grp=new XmlRpcStruct();
					grp["description"]=(string)tmp3["description"];
					grp["members"]=JsonConvert.DeserializeObject<string[]>(JsonConvert.SerializeObject(tmp3["members"]));
					groups[x]=grp;
				}

				dic["users"]=users;
				dic["groups"]=groups;
				
				
				client.import_llum_info(llum.Core.getCore().user_info,"Golem",dic);

				return(true);
			}
			catch(Exception e){
				Console.WriteLine(e);
				return(false);
			}
		}

		
	}
}
