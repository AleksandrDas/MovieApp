using MovieApp.Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Logic.Managers
{
    /// <summary>
    /// Filmu parvaldnieks
    /// </summary>
    public class MovieManager
    {
        /// <summary>
        /// Pilns filmu saraksts
        /// </summary>
        /// <returns>Saraksts ar filmam</returns>
        public static List<Movies> GetMovies()
        {
            using (var db = new DB())
            {
                return db.Movies.OrderBy(m => m.Title).ToList();
            }
        }
        /// <summary>
        /// Filmas atlase
        /// </summary>
        /// <param name="id">Filmas ID</param>
        /// <returns>Filmas atlase</returns>
        public static Movies GetMovie(int id)
        {
            using (var db = new DB())
                {
                return db.Movies.Find(id);
            }
        }
        /// <summary>
        /// Filmu atlase pec kinoteatra
        /// </summary>
        /// <param name="cinemaId">Kinoteatra ID</param>
        /// <returns>Saraksts ar filmam</returns>
        public static List<Movies> GetMovies(int cinemaId)
        {
            using (var db = new DB())
            {
                return db.Movies.Where(m => m.CinemaId == cinemaId)
                    .OrderBy(m => m.Title)
                    .ToList();
            }
        }
        /// <summary>
        /// Filmas dzesana
        /// </summary>
        /// <param name="id">Filmas ID</param>
        public static void Delete(int id)
        {
            using (var db = new DB())
            {
                db.Movies.Remove(db.Movies.Find(id));

                db.SaveChanges();
            }
        }
        /// <summary>
        /// FIlmas pievienosana
        /// </summary>
        /// <param name="movie">Filmas dati</param>
        /// <returns>Pievienota filma</returns>
        public static Movies Create(Movies movie)
        {
            using (var db = new DB())
            {
                movie = db.Movies.Add(movie);

                db.SaveChanges();

                return movie;
            }
        }
        /// <summary>
        /// Filmas atjaunosana
        /// </summary>
        /// <param name="movie">Filmas dati</param>
        /// <returns>Filmas dati</returns>
        public static Movies Update(Movies movie)
        {
            using (var db = new DB())
            {
                var existing = db.Movies.Find(movie.Id);
                existing.Title = movie.Title;
                existing.Year = movie.Year;

                db.SaveChanges();

                return existing;
            }
        }
    }
}
