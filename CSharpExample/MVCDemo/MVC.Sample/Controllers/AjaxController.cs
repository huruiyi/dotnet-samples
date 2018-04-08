using MVC.Sample.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVC.Sample.Controllers
{
    public class AjaxController : Controller
    {
        public ActionResult AjaxComment()
        {
            return View();
        }

        public ActionResult AjaxTarget()
        {
            return Content("Target page return :" + Request["resource"]);
        }

        public ActionResult AjaxHelper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DisplayPerson()
        {
            string name = Request["Name"];
            string age = Request["Age"];
            string telephone = Request["Telephone"];
            string comment = Request["Comment"];
            Person p = new Person();
            if (name != string.Empty && age != string.Empty && telephone != string.Empty && comment != string.Empty)
            {
                int intAge = 0;
                if (!int.TryParse(age, out intAge))
                {
                    return Content("<li>Age must be a integer number</li>");
                }

                p.Name = name;
                p.Age = Convert.ToInt32(age);
                p.Comment = comment;
                p.Telephone = telephone;
                StringBuilder strbComment = new StringBuilder();
                strbComment.Append($"<li>Name:{Request["Name"]}</li>");
                strbComment.Append($"<li>Age:{Request["Age"]}</li>");
                strbComment.Append($"<li>Telephone:{Request["Telephone"]}</li>");
                strbComment.Append($"<li>Comment:{Request["Comment"]}</li>");
                return Content(string.Join("\n", strbComment.ToString()));
            }

            return Content("<li>Information incomplete</li>");
        }

        public ActionResult JQueryHelper()
        {
            return View();
        }

        public ActionResult Jsonp()
        {
            return View();
        }

        public ContentResult JsonpDemo(string callback)
        {
            List<object> objList = new List<object>();
            for (int i = 0; i < 10; i++)
            {
                objList.Add(new
                {
                    Name = $"Name{i}",
                    Description = $"Description{i}"
                });
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            var json = js.Serialize(objList);
            json = callback + "(" + json + ")";
            return Content(json);
        }
    }
}