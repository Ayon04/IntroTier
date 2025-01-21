using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepo
    {
        CMSContext db;
        public UserRepo() {
            db = new CMSContext();
        }
        public void Create(User u) { 
            db.Users.Add(u);
            db.SaveChanges();
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
            return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

    }
}
