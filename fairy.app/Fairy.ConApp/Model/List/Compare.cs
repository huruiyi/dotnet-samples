using System;
using System.Collections.Generic;

namespace Fairy.ConApp.Model.List
{
    public class Compare<T, TC> : IEqualityComparer<T>
    {
        private readonly Func<T, TC> _getField;
        public Compare(Func<T, TC> getfield)
        {
            this._getField = getfield;
        }
        public bool Equals(T x, T y)
        {
            return EqualityComparer<TC>.Default.Equals(_getField(x), _getField(y));
        }
        public int GetHashCode(T obj)
        {
            return EqualityComparer<TC>.Default.GetHashCode(this._getField(obj));
        }
    }
}
