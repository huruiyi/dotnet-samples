using System;

namespace WebApp.Demo.Execute.Transfer
{
    public partial class b : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(string.Format("a={0}<br/>", Request["a"]));
            Response.Write(string.Format("b={0}<br/>", Request["b"]));
            Response.Write(string.Format("c={0}<br/>", Request["c"]));
        }
    }
}