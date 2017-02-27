using System;

namespace WebApp.page
{
    public partial class Page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Page=" + Request.QueryString["page"] + " PathInfo=" + Request.PathInfo;
        }
    }
}