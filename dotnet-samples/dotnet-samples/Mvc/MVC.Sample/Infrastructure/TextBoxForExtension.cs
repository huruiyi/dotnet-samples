using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MVC.Sample.Infrastructure
{
    public static class TextBoxForExtension
    {
        public static MvcHtmlString TextBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, uint>> expression)
        {
            return htmlHelper.TextBoxFor(expression, new { @class = "uint form-control" });
        }

        public static MvcHtmlString TextBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, DateTime>> expression)
        {
            return htmlHelper.TextBoxFor(expression, new { @class = "date form-control" });
        }

        public static MvcHtmlString TextBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression)
        {
            return htmlHelper.TextBoxFor(expression, new { @class = "string form-control" });
        }

        public static MvcHtmlString TextBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, decimal>> expression)
        {
            return htmlHelper.TextBoxFor(expression, new { @class = "rmb form-control" });
        }
    }
}