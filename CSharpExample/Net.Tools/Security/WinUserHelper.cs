using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace Net.Tools.Security
{
    public static class WinUserHelper
    {
        private static void CreateLocalWindowsAccount(string userName, string passWord, string displayName, string description, string groupName, bool canChangePwd, bool pwdExpires)
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
            if (group != null)
            {
                group.Members.Add(user);
                group.Save();
            }
        }

        private static GroupPrincipal CreateGroup(string groupName, Boolean isSecurityGroup)
        {
            GroupPrincipal retGroup = IsGroupExist(groupName);
            if (retGroup == null)
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Machine);
                GroupPrincipal insGroupPrincipal = new GroupPrincipal(ctx)
                {
                    Name = groupName,
                    IsSecurityGroup = isSecurityGroup,
                    GroupScope = GroupScope.Local
                };
                insGroupPrincipal.Save();
                retGroup = insGroupPrincipal;
            }

            return retGroup;
        }

        private static GroupPrincipal IsGroupExist(string groupName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Machine);
            GroupPrincipal qbeGroup = new GroupPrincipal(ctx);
            PrincipalSearcher srch = new PrincipalSearcher(qbeGroup);

            return srch.FindAll().Cast<GroupPrincipal>().FirstOrDefault(ingrp => ingrp != null && ingrp.Name.Equals(groupName));
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
                CreateLocalWindowsAccount(addUserName, "password", addUserName, "", groupName, false, false);
            }
            return retAddCount;
        }
    }
}