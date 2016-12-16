using MVC.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

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
            int intAge;
            Person p = new Person();
            if (name != string.Empty && age != string.Empty && telephone != string.Empty && comment != string.Empty)
            {
                if (!int.TryParse(age, out intAge))
                {
                    return Content("<li>Age must be a integer number</li>");
                }
                else
                {
                    p.Name = name;
                    p.Age = Convert.ToInt32(age);
                    p.Comment = comment;
                    p.Telephone = telephone;
                    StringBuilder strbComment = new StringBuilder();
                    strbComment.Append(String.Format("<li>Name:{0}</li>", Request["Name"]));
                    strbComment.Append(String.Format("<li>Age:{0}</li>", Request["Age"]));
                    strbComment.Append(String.Format("<li>Telephone:{0}</li>", Request["Telephone"]));
                    strbComment.Append(String.Format("<li>Comment:{0}</li>", Request["Comment"]));
                    return Content(string.Join("\n", strbComment.ToString()));
                }
            }
            else
            {
                return Content("<li>Information incomplete</li>");
            }
        }

        public ActionResult JQueryHelper()
        {
            return View();
        }
    }
}