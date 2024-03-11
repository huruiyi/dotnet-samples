using System;
using System.IO;
using System.Net;
using System.Xml;

namespace WebApp.Page
{
    public partial class ApiDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private const string Url = "http://localhost:40143/Api/RESTAPI.svc/json";

        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(Url + "/1"));
            req.Method = "Get";
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream sw = res.GetResponseStream();
                StreamReader reader = new StreamReader(sw);
                Response.Write("Your GET Request response XML value:" + reader.ReadToEnd());
                res.Close();
                sw.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnSendPostRequest_Click(object sender, EventArgs e)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                req.Method = "POST";
                req.ContentType = "application/xml; charset=utf-8";

                var xmlDoc = new XmlDocument { XmlResolver = null };
                xmlDoc.Load(Server.MapPath("~/Resource/PostData.xml"));
                string sXml = xmlDoc.InnerXml;
                req.ContentLength = sXml.Length;
                var sw = new StreamWriter(req.GetRequestStream());
                sw.Write(sXml);
                sw.Close();

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream responseStream = res.GetResponseStream();
                var streamReader = new StreamReader(responseStream);

                var xml = new XmlDocument();
                xml.LoadXml(streamReader.ReadToEnd());

                Response.Write("Your POST Request response XML value:" + xml.InnerXml);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}