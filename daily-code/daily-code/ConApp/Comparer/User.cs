using System.Collections;
using System.Collections.Generic;

namespace ConApp.Comparer
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User()
        { }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Data01 : User
    {
        public Data01()
        { }

        public Data01(int id, string name) : base(id, name)
        {
        }
    }

    public class Data02 : Data01, IEqualityComparer, IEqualityComparer<Data02>
    {
        public Data02()
        { }

        public Data02(int id, string name) : base(id, name)
        {
        }

        public bool Equals(Data02 x, Data02 y)
        {
            return y != null && x != null && x.Id == y.Id && x.Name == y.Name;
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
            return (Id + Name).GetHashCode();
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