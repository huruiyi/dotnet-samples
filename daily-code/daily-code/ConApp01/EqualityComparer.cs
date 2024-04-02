using System.Collections.Generic;

namespace ConApp01
{
    public class EqualityComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return x.ID == y.ID && x.Name == y.Name;
        }

        public int GetHashCode(User obj)
        {
            return (obj.ID + obj.Name).GetHashCode();
        }
    }
}