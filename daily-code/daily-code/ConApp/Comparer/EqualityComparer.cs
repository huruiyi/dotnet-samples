using System.Collections.Generic;

namespace ConApp.Comparer
{
    public class EqualityComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return x != null && y != null && x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode(User obj)
        {
            return (obj.Id + obj.Name).GetHashCode();
        }
    }
}