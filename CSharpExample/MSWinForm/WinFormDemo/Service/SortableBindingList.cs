using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinFormDemo.Service
{
    public class SortedBindingList<T> : BindingList<T>, IRaiseItemChangedEvents
    {
        private bool m_Sorted = false;

        private ListSortDirection m_SortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor m_SortProperty = null;

        protected override bool SupportsSearchingCore
        {
            get
            {
                return true;
            }
        }

        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        protected override bool IsSortedCore
        {
            get
            {
                return m_Sorted;
            }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return m_SortDirection;
            }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return m_SortProperty;
            }
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            m_SortDirection = direction;
            m_SortProperty = prop;
            BOSortComparer<T> comparer = new BOSortComparer<T>(prop, direction);
            ApplySortInternal(comparer);
        }

        private void ApplySortInternal(BOSortComparer<T> comparer)
        {
            List<T> listRef = this.Items as List<T>;
            if (listRef == null)
                return;

            listRef.Sort(comparer);
            m_Sorted = true;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
    }

    public class BOSortComparer<T> : IComparer<T>
    {
        private PropertyDescriptor m_PropDesc = null;
        private ListSortDirection m_Direction = ListSortDirection.Ascending;

        public BOSortComparer(PropertyDescriptor propDesc, ListSortDirection direction)
        {
            m_PropDesc = propDesc;
            m_Direction = direction;
        }

        int IComparer<T>.Compare(T x, T y)
        {
            object xValue = m_PropDesc.GetValue(x);
            object yValue = m_PropDesc.GetValue(y);
            return CompareValues(xValue, yValue, m_Direction);
        }

        private int CompareValues(object xValue, object yValue, ListSortDirection direction)
        {
            int retValue = 0;
            if (xValue is IComparable) //can ask the x value
            {
                retValue = ((IComparable)xValue).CompareTo(yValue);
            }
            else if (yValue is IComparable) //can ask the y value
            {
                retValue = ((IComparable)yValue).CompareTo(xValue);
            }
            else if (xValue != null && yValue != null && !xValue.Equals(yValue))
            {
                retValue = xValue.ToString().CompareTo(yValue.ToString());
            }

            if (direction == ListSortDirection.Ascending)
                return retValue;
            else
                return retValue * -1;
        }
    }
}