using MovieApp.Logic.Managers;
using MovieApp.Models;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class MovieSessionController : Controller
    {

        [HttpGet]
        public ActionResult Edit(int? id, int movieId)
        {
            MovieSessionModel model = null;
            if (!id.HasValue)
            {
                model = MovieSessionModel.FromData(MovieSessionManager.Get(id.Value));
            }
            else
            {
                model = new MovieSessionModel();
                model.MovieId = movieId;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MovieSessionModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    MovieSessionManager.Create(model.ToData());
                }
                else
                {
                    MovieSessionManager.Update(model.ToData());
                }

                //sutam atpakal uz kino redigesanas formu
                return RedirectToAction("Edit", "Movie", new { id = model.MovieId });
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id, int movieId)
        {
            MovieSessionManager.Delete(id);

            return RedirectToAction("Edit", "Movie", new { id = movieId });
        }
    }
}

