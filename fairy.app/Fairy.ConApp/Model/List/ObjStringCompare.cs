using System;
using System.Collections.Generic;
using System.Reflection;

namespace Fairy.ConApp.Model.List
{
    public class ObjStringCompare : IEqualityComparer<Budge>
    {
        public ObjStringCompare(PropertyInfo property)
        {
        }

        public bool Equals(Budge x, Budge y)
        {
            return String.Compare(x.Year, y.Year, StringComparison.Ordinal) == 0;
        }

        public int GetHashCode(Budge obj)
        {
            return base.GetHashCode();
        }
    }
}