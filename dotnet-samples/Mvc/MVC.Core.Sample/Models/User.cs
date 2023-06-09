using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Sample.Models
{
    // A class to work-around with out data source
    public class Model
    {
        // Example data source
        private static List<User> users = new List<User>()
        {
            new User { ID = 1, Name = "Afzaal Ahmad Zeeshan", Gender = true, Interests = new string[] { "Programming", "Songs" } },
            new User { ID = 2, Name = "Shani", Gender = true, Interests = new string[] { "Eminem", "Eating" } },
            new User { ID = 3, Name = "Daniyal Ahmad Rizwan", Gender = true, Interests = new string[] { "Games", "Movies" } },
            new User { ID = 4, Name = "Marshall Bruce Mathers III", Gender = true, Interests = new string[] { "Rapping", "Parenting" } }
        };

        // C part of CRUD
        public static void CreateUser(User user)
        {
            users.Add(user);
        }

        // R part of CRUD
        public static List<User> GetAll()
        {
            return users;
        }

        public static User GetUser(int id)
        {
            return users.Find(x => x.ID == id); // Find one user and return him
        }

        // U part of CRUD
        public static void UpdateUser(int id, User user)
        {
            users.Remove(users.Find(x => x.ID == id)); // Remove the previous User
            users.Add(user);
        }

        // D part of CRUD 
        public static void DeleteUser(int id)
        {
            users.Remove(users.Find(x => x.ID == id)); // Find and remove the user
        }
    }


    // Actual data model
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string[] Interests { get; set; }
    }
}
