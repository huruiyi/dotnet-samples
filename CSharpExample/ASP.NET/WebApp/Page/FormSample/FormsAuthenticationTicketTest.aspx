<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    private void Login_Click(Object sender, EventArgs e)
    {
        /*
            FormsAuthenticationTicket 类用于创建表示身份验证票证的对象，Forms 身份验证使用这些票证来标识已经过身份验证的用户。
            Forms 身份验证票证的属性和值将转换为加密字符串存储在 Cookie 或 URL 中；这些加密字符串也会转换回票证的属性和值。
            FormsAuthentication 类提供了 Encrypt 方法，用于从 FormsAuthenticationTicket 创建一个可存储在 Cookie 或 URL 中的字符串值。
            FormsAuthentication 类还提供了一个 Decrypt 方法，用于从检索自 Forms 身份验证 Cookie 或 URL 的加密身份验证票证创建一个 FormsAuthenticationTicket 对象。
            可以使用 FormsIdentity 类的 Ticket 属性访问当前经过身份验证的用户的 FormsAuthenticationTicket。
            通过将当前 User 的 Identity 属性强制转换为类型 FormsIdentity，可以访问当前 FormsIdentity 对象。
         */
        // Create a custom FormsAuthenticationTicket containing
        // application specific data for the user.

        string username = UserNameTextBox.Text;
        string password = UserPassTextBox.Text;
        bool isPersistent = PersistCheckBox.Checked;

        if (Membership.ValidateUser(username, password))
        {
            const string userData = "ApplicationSpecific data for this user.";

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
              username,
              DateTime.Now,
              DateTime.Now.AddMinutes(30),
              isPersistent,
              userData,
              FormsAuthentication.FormsCookiePath);

            string encTicket = FormsAuthentication.Encrypt(ticket);

            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            Response.Redirect(FormsAuthentication.GetRedirectUrl(username, isPersistent));
        }
        else
        {
            Msg.Text = "Login failed. Please check your user name and password and try again.";
        }
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Forms Authentication Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <span style="background: #80ff80; font-weight: bold">Login Page
        </span>
        <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
        <table border="0">
            <tbody>
                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:TextBox ID="UserNameTextBox" runat="server" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="*"
                            Display="Static"
                            ControlToValidate="UserNameTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox ID="UserPassTextBox" TextMode="Password" runat="server" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ErrorMessage="*"
                            Display="Static"
                            ControlToValidate="UserPassTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>Check here if this is
                        <span style="text-decoration: underline">not</span>
                        <br />
                        a public computer:</td>
                    <td>
                        <asp:CheckBox ID="PersistCheckBox" runat="server" AutoPostBack="true" /></td>
                </tr>
            </tbody>
        </table>
        <input type="submit" value="Login" runat="server" onserverclick="Login_Click" />
    </form>
</body>
</html>