using MovieApp.Logic.Database;
using MovieApp.Logic.Managers;
using MovieApp.Models;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                string error = UserManager.Register(new Users()
                {
                    Epasts = model.Epasts,
                    Vards = model.Vards,
                    Parole = model.Parole
                });
                //nav kluda -> lietotajs registrets
                if (error == null)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", error);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = UserManager.Login(model.Epasts, model.Parole);
                if (user == null)
                {
                    ModelState.AddModelError("", "Nepareizs e-pasts/parole!");
                }
                else
                {
                    Session.Set(new UserSessionModel()
                    {
                        User = UserModel.FromData(user)
                    });
                    return RedirectToAction("Index", "Main");
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Main");
        }

        [HttpGet]
        public ActionResult MyBasket()
        {

            return View(Session.Get().Basket);
        }
    }
}





