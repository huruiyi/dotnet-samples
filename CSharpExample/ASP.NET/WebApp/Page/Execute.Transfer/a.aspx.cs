using System;

namespace WebApp.Page.Execute.Transfer
{
    public partial class a : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("a.aspx Page_Load Begin<br/>");
            //  Server.Execute("b.aspx?a=123&b=456",false);

            Server.Transfer("b.aspx?a=123&b=456", false);//重定向

            Response.Write("a.aspx Page_Load End<br/>");
        }
    }
}