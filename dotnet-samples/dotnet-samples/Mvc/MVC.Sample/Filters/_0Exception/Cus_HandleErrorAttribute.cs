using System;
using System.Web;
using System.Web.Mvc;

namespace MVC.Sample.Fliters._0Exception
{
    public class Cus_HandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            #region Demo1

            if (!filterContext.ExceptionHandled)
            {
                Exception innerException = filterContext.Exception;
                //如果错误码为500
                if ((new HttpException(null, innerException).GetHttpCode() == 500) && this.ExceptionType.IsInstanceOfType(innerException))
                {
                    //获取出现异常的controller名和action名，用于记录
                    string controllerName = (string)filterContext.RouteData.Values["controller"];
                    string actionName = (string)filterContext.RouteData.Values["action"];
                    //定义一个HandErrorInfo，用于Error页使用
                    HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                    //ViewResult是ActionResult，经常出现在controller中action方法return后面，但是出现形式是View()
                    ViewResult result = new ViewResult
                    {
                        ViewName = this.View,
                        MasterName = this.Master,
                        //定义ViewData，使用的是泛型
                        ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                        TempData = filterContext.Controller.TempData
                    };
                    filterContext.Result = result;
                    filterContext.ExceptionHandled = true;
                    filterContext.HttpContext.Response.Clear();
                    filterContext.HttpContext.Response.StatusCode = 500;
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                }
            }

            #endregion Demo1

            #region Demo2

            //if (!filterContext.ExceptionHandled)
            //{
            //    string actionName = (string)filterContext.RouteData.Values["action"];
            //    filterContext.Controller.ViewData["Exception"] = filterContext.Exception;
            //    //filterContext.RouteData.Values["controller"] = "Error";
            //    //filterContext.RouteData.Values["action"] = "Details";
            //    filterContext.Result = new ViewResult() { ViewName = actionName, ViewData = filterContext.Controller.ViewData };
            //    filterContext.ExceptionHandled = true;
            //    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            //    filterContext.ExceptionHandled = true;
            //}

            #endregion Demo2

            base.OnException(filterContext);
        }
    }
}
