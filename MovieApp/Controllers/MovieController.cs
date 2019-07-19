using MovieApp.Logic.Managers;
using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<MovieModel> movies = new List<MovieModel>();

            movies = MovieManager.GetMovies().Select(m => MovieModel.FromData(m)).ToList();

            return View(movies);
        }
        [HttpGet]
        public ActionResult Edit(int? id, int? cinemaId)
        {
            MovieModel movie = null;
            if (!id.HasValue)
            {
                movie = new MovieModel()
                {
                    CinemaId = cinemaId.Value,
                };
            }
            else
            {
                movie = MovieModel.FromData(MovieManager.GetMovie(id.Value));
                movie.MovieSessions = MovieSessionManager.GetSessions(id.Value)
                    .Select(s => MovieSessionModel.FromData(s))
                    .ToList();
            }
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(MovieModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    MovieManager.Create(model.ToData());
                }
                else
                {
                    MovieManager.Update(model.ToData());
                }

                //sutam atpakal uz kino redigesanas formu
                return RedirectToAction("Edit", "Cinema", new { id = model.CinemaId });
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id, int cinemaId)
        {
            MovieManager.Delete(id);

            return RedirectToAction("Edit", "Cinema", new { id = cinemaId });
        }
    }
}