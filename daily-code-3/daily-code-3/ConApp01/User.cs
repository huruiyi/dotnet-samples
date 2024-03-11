using System.Collections;
using System.Collections.Generic;

namespace ConApp01
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Data01 : User
    {
    }

    public class Data02 : Data01, IEqualityComparer, IEqualityComparer<Data02>
    {
        public bool Equals(Data02 x, Data02 y)
        {
            return x.ID == y.ID && x.Name == y.Name;
        }

        public new bool Equals(object x, object y)
        {
            if (x is Data02)
            {
                if (y is Data02)
                {
                    return Equals((Data02)x, (Data02)y);
                }
            }
            return false;
        }

        public int GetHashCode(Data02 obj)
        {
            return (ID + Name).GetHashCode();
        }

        public int GetHashCode(object obj)
        {
            if (obj is Data02)
            {
                return (obj as Data02).GetHashCode();
            }
            return obj.GetHashCode();
        }
    }
}