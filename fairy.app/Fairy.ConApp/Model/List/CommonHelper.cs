using System;
using System.Collections.Generic;
using System.Linq;

namespace Fairy.ConApp.Model.List
{
    public static class CommonHelper
    {
        public static IEnumerable<T> Distinct<T, C>(this IEnumerable<T> source, Func<T, C> getfield)
        {
            return source.Distinct(new Compare<T, C>(getfield));
        }
    }

}
