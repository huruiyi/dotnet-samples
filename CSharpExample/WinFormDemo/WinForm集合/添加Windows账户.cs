using System;
using System.DirectoryServices.AccountManagement;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class 添加Windows账户 : Form
    {
        public 添加Windows账户()
        {
            InitializeComponent();
        }

        public static bool CreateLocalWindowsAccount(string username, string password, string displayName, string description, bool canChangePwd, bool pwdExpires)
        {
            try
            {
                PrincipalContext context = new PrincipalContext(ContextType.Machine);
                UserPrincipal user = new UserPrincipal(context);
                user.SetPassword(password);
                user.DisplayName = displayName;
                user.Name = username;
                user.Description = description;
                user.UserCannotChangePassword = canChangePwd;
                user.PasswordNeverExpires = pwdExpires;
                user.Save();
                //now add user to "Users" group so it displays in Control Panel
                GroupPrincipal group = GroupPrincipal.FindByIdentity(context, "Users");
                group.Members.Add(user);
                group.Save();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating account: {0}", ex.Message);
                return false;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string userPwd = txtPassword.Text.Trim();
            string dispName = txtDisplayName.Text.Trim();
            string description = txtDescription.Text.Trim();

            bool flag = CreateLocalWindowsAccount(userName, userPwd, dispName, description, true, true);
            MessageBox.Show("添加用户" + (true ? "成功" : "失败"));
        }
    }
}