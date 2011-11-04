using System.Web.Mvc;
using Muvykive.Service.Interfaces;

namespace Muvykive.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public ActionResult Index()
        {
            var model = _movieService.GetMovies();
            return View(model);
        }

    }
}