using MovieApp.Logic.Database;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Logic.Managers
{
    public class MovieSessionManager
    {
        public static Sessions Create(Sessions data)
        {
            using (var db = new DB())
            {
                data = db.Sessions.Add(data);
                db.SaveChanges();
                return data;
            }
        }
        public static void Delete(int id)
        {
            using (var db = new DB())
            {
                db.Sessions.Remove(db.Sessions.Find(id));
                db.SaveChanges();
            }
        }
        public static Sessions Update(Sessions data)
        {
            using (var db = new DB())
            {
                var existing = db.Sessions.Find(data.Id);
                existing.Time = data.Time;
                existing.Price = data.Price;
                db.SaveChanges();
                return data;
            }
        }
        public static Sessions Get(int id)
        {
            using (var db = new DB())
            {
                return db.Sessions.First(m => m.Id == id);
            }
        }
        public static List<Sessions> GetSessions(int movieId)
        {
            using (var db = new DB())
            {
                return db.Sessions.Where(m => m.MovieId == movieId).ToList();
            }
        }
    }
}
