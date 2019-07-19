using MovieApp.Logic.Managers;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? id)
        {
            MainViewModel model = new MainViewModel();

            model.Cinemas = CinemaManager.GetCinemas()
                .Select(c => CinemaModel.FromData(c))
                .ToList();
            foreach(var cinema in model.Cinemas)
            {
                cinema.MovieCount = CinemaManager.CountMovies(cinema.Id);
            }

            if(id.HasValue)
            {
                model.Movies = MovieManager.GetMovies(id.Value)
                    .Select(m => MovieModel.FromData(m))
                    .ToList();
            }
            else
            {
                model.Movies = new List<MovieModel>();
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Movie(int id)
        {
            MovieReservationModel model = new MovieReservationModel();

            //1.Atlasit filmas datus pec ID 
            model.Movie = MovieModel.FromData(MovieManager.GetMovie(id));

            //2.Atlasit filmas seansuns pec filmas ID 
            model.Sessions = MovieSessionManager.GetSessions(id)
                .Select(s => MovieSessionModel.FromData(s))
                .ToList();

            //3.Ielikt rezultatus modeli
            
            //4.Realizet Movie.cshtml failu - attelot filmas datus un sarakstu ar seansiem 

            return View(model);
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            //seansa dati
            MovieSessionModel session = MovieSessionModel.FromData(MovieSessionManager.Get(id));

            //nolasam lietotaja sessijas datus un papildinam grozu ar izveleto seansu
            var basket = Session.Get().Basket;
            basket.Add(session);
            return RedirectToAction("movie", new { id = session.MovieId });
        }
    }
}