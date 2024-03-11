using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MVC.Sample.Infrastructure
{
    public class RouteConstraint
    {
        public class YearRouteConstraint : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                if (routeDirection == RouteDirection.IncomingRequest &&
                    parameterName.ToLower() == "year")
                {
                    var year = 0;
                    if (int.TryParse(values["year"].ToString(), out year))
                    {
                        return year >= 2000 && year <= 2012;
                    }
                    return false;
                }
                return false;
            }
        }

        public class MonthRouteConstraint : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                if (routeDirection == RouteDirection.IncomingRequest &&
                    parameterName.ToLower() == "month")
                {
                    var month = 0;
                    if (int.TryParse(values["month"].ToString(), out month))
                    {
                        return month >= 1 && month <= 12;
                    }
                    return false;
                }
                return false;
            }
        }

        public class DayRouteConstraint : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                if (routeDirection == RouteDirection.IncomingRequest &&
                    parameterName.ToLower() == "day")
                {
                    var month = 0;
                    if (!int.TryParse(values["month"].ToString(), out month)) return false;
                    if (month <= 0 || month > 12) return false;

                    var day = 0;
                    if (!int.TryParse(values["day"].ToString(), out day)) return false;

                    switch (month)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 8:
                        case 10:
                        case 12:
                            return day <= 31;
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            return day <= 31;
                        case 2:
                            return day <= 28;//不计闰年
                    }
                }
                return false;
            }
        }
    }
}