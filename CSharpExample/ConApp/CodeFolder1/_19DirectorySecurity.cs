using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Security.AccessControl;

namespace ConApp.CodeFolder1
{
    public static class Commons
    {
        private static bool CreateLocalWindowsAccount(string userName, string passWord, string displayName, string description, string groupName, bool canChangePwd, bool pwdExpires)
        {
            bool retIsSuccess = false;
            try
            {
                PrincipalContext context = new PrincipalContext(ContextType.Machine);
                UserPrincipal user = new UserPrincipal(context);
                user.SetPassword(passWord);
                user.DisplayName = displayName;
                user.Name = userName;
                user.Description = description;
                user.UserCannotChangePassword = canChangePwd;
                user.PasswordNeverExpires = pwdExpires;
                user.Save();

                GroupPrincipal group = GroupPrincipal.FindByIdentity(context, groupName);
                group.Members.Add(user);
                group.Save();
                retIsSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                retIsSuccess = false;
            }
            return retIsSuccess;
        }

        private static GroupPrincipal CreateGroup(string groupName, Boolean isSecurityGroup)
        {
            GroupPrincipal retGroup = null;
            try
            {
                retGroup = IsGroupExist(groupName);
                if (retGroup == null)
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Machine);
                    GroupPrincipal insGroupPrincipal = new GroupPrincipal(ctx);
                    insGroupPrincipal.Name = groupName;
                    insGroupPrincipal.IsSecurityGroup = isSecurityGroup;
                    insGroupPrincipal.GroupScope = GroupScope.Local;
                    insGroupPrincipal.Save();
                    retGroup = insGroupPrincipal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retGroup;
        }

        private static GroupPrincipal IsGroupExist(string groupName)
        {
            GroupPrincipal retGroup = null;
            try
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Machine);
                GroupPrincipal qbeGroup = new GroupPrincipal(ctx);
                PrincipalSearcher srch = new PrincipalSearcher(qbeGroup);
                foreach (GroupPrincipal ingrp in srch.FindAll())
                {
                    if (ingrp != null && ingrp.Name.Equals(groupName))
                    {
                        retGroup = ingrp;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retGroup;
        }

        public static int UpdateGroupUsers(string groupName, List<string> usersName)
        {
            List<string> addedUsers = new List<string>();
            int retAddCount = 0;

            GroupPrincipal qbeGroup = CreateGroup(groupName, false);
            foreach (UserPrincipal user in qbeGroup.GetMembers())
            {
                if (usersName.Contains(user.Name))
                {
                    addedUsers.Add(user.Name);
                    retAddCount++;
                }
                else
                {
                    user.Delete();
                }
            }
            foreach (string addedUserName in addedUsers)
            {
                usersName.Remove(addedUserName);
            }
            foreach (string addUserName in usersName)
            {
                bool isSuccess = CreateLocalWindowsAccount(addUserName, "password", addUserName, "", groupName, false, false);
                if (isSuccess) retAddCount++;
            }
            return retAddCount;
        }
    }

    public class WindwosUser
    {
        //创建NT用户
        //传入参数：Username要创建的用户名，Userpassword用户密码，Path主文件夹路径
        public static bool CreateNTUser(string Username, string Userpassword, string Path)
        {
            DirectoryEntry obDirEntry = null;
            try
            {
                obDirEntry = new DirectoryEntry("WinNT://" + Environment.MachineName);

                DirectoryEntry obUser = obDirEntry.Children.Add(Username, "User"); //增加用户名
                obUser.Properties["FullName"].Add(Username); //用户全称
                obUser.Invoke("SetPassword", Userpassword); //用户密码
                obUser.Invoke("Put", "Description", "Test User from .NET");//用户详细描述
                                                                           //obUser.Invoke("Put","PasswordExpired",1); //用户下次登录需更改密码
                obUser.Invoke("Put", "UserFlags", 66049); //密码永不过期
                obUser.Invoke("Put", "HomeDirectory", Path); //主文件夹路径
                obUser.CommitChanges();//保存用户
                DirectoryEntry grp = obDirEntry.Children.Find("Users", "group");//Users组
                if (grp.Name != "")
                {
                    grp.Invoke("Add", obUser.Path.ToString());//将用户添加到某组
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //删除NT用户
        //传入参数：Username用户名
        public static bool DelNTUser(string Username)
        {
            try
            {
                DirectoryEntry obComputer = new DirectoryEntry("WinNt://" + Environment.MachineName);//获得计算机实例
                DirectoryEntry obUser = obComputer.Children.Find(Username, "User");//找得用户
                obComputer.Children.Remove(obUser);//删除用户
                return true;
            }
            catch
            {
                return false;
            }
        }

        //修改NT用户密码
        //传入参数：Username用户名，Userpassword用户新密码
        public static bool InitNTPwd(string Username, string Userpassword)
        {
            try
            {
                DirectoryEntry obComputer = new DirectoryEntry("WinNt://" + Environment.MachineName);
                DirectoryEntry obUser = obComputer.Children.Find(Username, "User");
                obUser.Invoke("SetPassword", Userpassword);
                obUser.CommitChanges();
                obUser.Close();
                obComputer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    internal class _19DirectorySecurity
    {
        private static void Main30(string[] args)
        {
            Console.WriteLine("_30DirectorySecurity");

            Console.ReadKey();
        }

        /// <summary>
        /// 创建Windows帐户_目录权限
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="description"></param>
        public static void CreateLocalUser(string username, string password, string description)
        {
            DirectoryEntry dirEntry = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            var NewUser = dirEntry.Children.Add(username, "user");
            NewUser.Invoke("SetPassword", new object[] { password });
            NewUser.Invoke("Put", new object[] { "Description", description });
            NewUser.CommitChanges();
        }

        /// <summary>
        /// 更改Windows帐户密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        public static void ChangeWinUserPasswd(string username, string oldPwd, string newPwd)
        {
            DirectoryEntry dirEntry = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntry userEntry = dirEntry.Children.Find(username, "user");
            object[] password = new object[] { newPwd, oldPwd };
            object ret = userEntry.Invoke("ChangePassword", password);
            userEntry.CommitChanges();
        }

        /// <summary>
        /// 给目录添加用户和权限
        /// </summary>
        /// <param name="pathname"></param>
        /// <param name="username"></param>
        /// <param name="qx"></param>
        public static void AddPathRights(string pathname, string username, FloderRights qx)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(pathname);
            if ((dirinfo.Attributes & FileAttributes.ReadOnly) != 0)
            {
                dirinfo.Attributes = FileAttributes.Normal;
            }
            //取得访问控制列表
            DirectorySecurity dirsecurity = dirinfo.GetAccessControl();
            // string strDomain = Dns.GetHostName();
            switch (qx)
            {
                case FloderRights.FullControl:
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(username, FileSystemRights.FullControl, AccessControlType.Allow));
                    break;

                case FloderRights.Read:
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(username, FileSystemRights.Read, AccessControlType.Allow));
                    break;

                case FloderRights.Write:
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(username, FileSystemRights.Write, AccessControlType.Allow));
                    break;

                default:
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(username, FileSystemRights.FullControl, AccessControlType.Deny));
                    break;
            }

            dirinfo.SetAccessControl(dirsecurity);

            //取消目录从父继承
            DirectorySecurity dirSecurity = System.IO.Directory.GetAccessControl(pathname);
            dirSecurity.SetAccessRuleProtection(true, false);
            System.IO.Directory.SetAccessControl(pathname, dirSecurity);

            //AccessControlType.Allow允许访问受保护对象//Deny拒绝访问受保护对象
            //FullControl、Read 和 Write 完全控制,读,写
            //FileSystemRights.Write写入//Delete删除 //DeleteSubdirectoriesAndFiles删除文件夹和文件//ListDirectory读取
            //Modify读写删除-修改//只读打开文件和复制//
        }

        /// <summary>
        /// 判断Windows用户是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool ExistWinUser(string username)
        {
            try
            {
                using (DirectoryEntry dirEntry = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer"))
                {
                    //删除存在用户
                    var delUser = dirEntry.Children.Find(username, "user");
                    return delUser != null;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除Windows用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool DeleteWinUser(string username)
        {
            try
            {
                using (DirectoryEntry dirEntry = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer"))
                {
                    //删除存在用户
                    var delUser = dirEntry.Children.Find(username, "user");
                    if (delUser != null)
                    {
                        dirEntry.Children.Remove(delUser);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public enum FloderRights
    {
        FullControl,
        Read,
        Write
    }
}