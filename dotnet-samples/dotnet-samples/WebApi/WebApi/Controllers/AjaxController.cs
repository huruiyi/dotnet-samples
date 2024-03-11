using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebApi.Controllers
{
    public class AjaxController : Controller
    {
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
