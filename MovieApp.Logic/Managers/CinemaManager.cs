using MovieApp.Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Logic.Managers
{
    
    public class CinemaManager
    {
        /// <summary>
        /// Jauna ieraksta pievienosana
        /// </summary>
        /// <param name="cinema">Dati</param>
        /// <returns>Izveidotais ieraksts</returns>
        public static Cinemas Create(Cinemas cinema)
        {
            using (var db = new DB())
            {
                cinema = db.Cinemas.Add(cinema);

                db.SaveChanges();

                return cinema;
            }
        }
        /// <summary>
        /// Ieraksta dzesana
        /// </summary>
        /// <param name="id">Kinoteatra ID</param>
        public static void Delete(int id)
        {
            using (var db = new DB())
            {
                //vispirms filmas
                db.Movies.RemoveRange(db.Movies.Where(m => m.CinemaId == id));
                //tad pasu kino 
                db.Cinemas.Remove(db.Cinemas.Find(id));

                db.SaveChanges();
            }
        }
        /// <summary>
        /// Kino atjaunosana
        /// </summary>
        /// <param name="cinema">Kino dati</param>
        /// <returns>Kino dati</returns>
        public static Cinemas Update(Cinemas cinema)
        {
            using (var db = new DB())
            {
                var existing = db.Cinemas.Find(cinema.Id);
                existing.Name = cinema.Name;
                existing.Adress = cinema.Adress;

                db.SaveChanges();

                return existing;
            }
        }
        /// <summary>
        /// Kino atlase
        /// </summary>
        /// <param name="id">Kino ID</param>
        /// <returns>Kino atlase</returns>
        public static Cinemas GetCinema(int id)
        {
            using (var db = new DB())
            {
                return db.Cinemas.Find(id);
            }
        }
        /// <summary>
        /// Pilnms kino saraksts
        /// </summary>
        /// <returns>Saraksts ar kino</returns>
        public static List<Cinemas> GetCinemas()
        {
            using (var db = new DB())
            {
                return db.Cinemas.OrderBy(m => m.Name).ToList();
            }
        }
        /// <summary>
        /// Filmu skaits pec kinoteatra
        /// </summary>
        /// <param name="cinemaId">Kinoteatra ID</param>
        /// <returns>Skaits</returns>
        public static int CountMovies(int cinemaId)
        {
            using(var db = new DB())
            {
                return db.Movies.Count(m => m.CinemaId == cinemaId);
            }
        }

    }
}
