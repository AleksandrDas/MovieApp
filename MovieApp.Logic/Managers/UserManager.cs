using MovieApp.Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Logic.Managers
{
    public class UserManager
    {
        public static string Register(Users user)
        {
            using(var db = new DB())
            {
                if(db.Users.Any(u => u.Epasts == user.Epasts))
                {
                    return "Šāds e-pasts jau ir reģistrēts!";
                }
                db.Users.Add(user);
                db.SaveChanges();
                return null;
            }
        }
        public static Users Login(string epasts, string parole)
        {
            using(var db = new DB())
            {
                return db.Users.FirstOrDefault(u => u.Epasts == epasts && u.Parole == parole);
            }
        }
    }
}
