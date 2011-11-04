using System;
using System.Web.Mvc;
using Muvykive.Service.Interfaces;
using Muvykive.Service.Messaging.Movie;
using Muvykive.Web.UI.ViewModels;

namespace Muvykive.Web.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly ICertificationService _certificationService;
        private readonly IGenreService _genreService;
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService, IGenreService genreService, ICertificationService certificationService)
        {
            _movieService = movieService;
            _genreService = genreService;
            _certificationService = certificationService;
        }

        /// <summary>
        /// Movie Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            GetMovieDetailResponse movie = _movieService.GetMovie(id);
            var model = new DetailMovieView {Movie = movie.Movie};
            return View(model);
        }

        /// <summary>
        /// Edit Movie (Display)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            GetMovieDetailResponse movie = _movieService.GetMovie(id);
            GetGenreListResponse genres = _genreService.GetGenres();
            GetCertificationListReponse certifications = _certificationService.GetCertification(); //new GetCertificationListReponse();

            var model = new DetailMovieEditView
                            {
                                Movie = movie.Movie,
                                Genres = new SelectList(genres.Genres, "Id", "Name"),
                                Certifications = new SelectList(certifications.Certifications, "Id", "Abbreviation", movie.Movie.CertificationId)
                            };
            return View(model);
        }

        /// <summary>
        /// Edit Movie (Submit)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieView"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, DetailMovieEditView movieView, FormCollection collection)
        {
            var request = new AddUpdateMovieRequest
                                {
                                    Id = id,
                                    Name = movieView.Movie.Name,
                                    CertificationId = collection["CertificationId"] != "" ? Convert.ToInt32(collection["CertificationId"]) : 0,
                                    Released = movieView.Movie.Released,
                                    RunTime = movieView.Movie.RunTime,
                                    GenresId = collection["GenreId"] != "" ? Convert.ToInt32(collection["GenreId"]) : 0
                                };
            var response = _movieService.AddUpdateMovie(request);
            if (response.Successful)
                return RedirectToAction("Details", new {id = response.Id});

            return View(response);
        }

    }
}