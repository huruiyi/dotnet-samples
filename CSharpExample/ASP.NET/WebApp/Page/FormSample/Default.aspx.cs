using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Page.FormSample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void RenderChildren(HtmlTextWriter output)
        {
            if (HasControls())
            {
                // Render Children in reverse order.
                for (int i = Controls.Count - 1; i >= 0; --i)
                {
                    Controls[i].RenderControl(output);
                }
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            output.Write("<br>Message from Control : ");
            output.Write("Showing Custom controls created in reverse order");

            // Render Controls.
            RenderChildren(output);
        }
    }
}