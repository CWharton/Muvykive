using System.Web.Mvc;
using Muvykive.Service.Interfaces;
using Muvykive.Service.Messaging.Movie;

namespace Muvykive.Web.UI.Controllers
{
    public class MovieAjaxController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieAjaxController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Add genre to movie
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="genreId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddMovieGenre(int movieId, int genreId)
        {
            var request = new AddMovieGenreRequest {Id = movieId, GenreId = genreId};
            AddMovieGenreResponse response = _movieService.AddMovieGenre(request);

            return Json(response);
        }

        [HttpPost]
        public JsonResult GetRandomMovies()
        {
            GetMovieListResponse response = _movieService.GetRandomMovieList();

            return Json(response);
        }
    }
}