using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"D:\Work\Github\res\demo.xml");
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/info/collage");
            List<Info> infos = new List<Info>();
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                Info info = new Info
                {
                    CollageName = xmlNode["name"].InnerText,
                    Students = xmlNode["students"].InnerText
                };
                infos.Add(info);
            }
            return View(infos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
