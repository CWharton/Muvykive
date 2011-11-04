using System;
using System.Collections.Generic;
using System.Linq;
using Muvykive.Model;
using Muvykive.Model.Movies;
using Muvykive.Service.Interfaces;
using Muvykive.Service.Mapping;
using Muvykive.Service.Messaging.Movie;

namespace Muvykive.Service.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _uow;

        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository, IUnitOfWork uow)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _uow = uow;
        }

        #region IMovieService Members

        /// <summary>
        /// Retrieve movie full list
        /// </summary>
        /// <returns></returns>
        public GetMovieListResponse GetMovies()
        {
            IEnumerable<Movie> movies = _movieRepository.FindAll();
            var response = new GetMovieListResponse {Successful = true, Movies = movies.ConvertToMovieListView()};
            return response;
        }

        /// <summary>
        /// Retrieve movie details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GetMovieDetailResponse GetMovie(int id)
        {
            Movie movie = _movieRepository.FindBy(id) ?? new Movie();
            var response = new GetMovieDetailResponse {Successful = true, Movie = movie.ConvertToMovieDetailView()};
            return response;
        }

        /// <summary>
        /// Add/Update movie
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AddUpdateMovieResponse AddUpdateMovie(AddUpdateMovieRequest request)
        {
            Movie movie = _movieRepository.FindBy(request.Id) ?? new Movie();

            movie.Name = request.Name;
            movie.CertificationId = request.CertificationId > 0 ? request.CertificationId : null;
            movie.Released = request.Released;
            movie.RunTime = request.RunTime;

            if (request.GenresId != 0 && !IsGenreInList(movie.Genres, request.GenresId))
            {
                Genre genre = _genreRepository.FindBy(request.GenresId);
                if (movie.Genres == null)
                    movie.Genres = new List<Genre>();
                movie.Genres.Add(genre);
            }

            var response = new AddUpdateMovieResponse();
            try
            {
                _movieRepository.Save(movie);
                _uow.Commit();
                response.Successful = true;
                response.Id = movie.Id;
                response.Movie = movie.ConvertToMovieDetailView();
            }
            catch
            {
                response.Successful = false;
                response.Message = "An Error occurred while trying to save.";
                response.Id = movie.Id;
                response.Movie = movie.ConvertToMovieDetailView();
            }

            return response;
        }

        /// <summary>
        /// Add genre to specified movie
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AddMovieGenreResponse AddMovieGenre(AddMovieGenreRequest request)
        {
            var response = new AddMovieGenreResponse();
            if (request.Id > 0 && request.GenreId > 0)
            {
                Movie movie = _movieRepository.FindBy(request.Id) ?? new Movie();

                if (!IsGenreInList(movie.Genres, request.GenreId))
                {
                    Genre genre = _genreRepository.FindBy(request.GenreId);
                    movie.Genres.Add(genre);

                    _movieRepository.Save(movie);
                    _uow.Commit();

                    response.Successful = true;
                    response.GenreName = genre.Name;
                }
                else
                {
                    response.Successful = false;
                    response.Message = "Genre is already assign to movie";
                }
            }
            else
                response.Successful = false;
            return response;
        }

        /// <summary>
        /// Returns random movie selection
        /// </summary>
        public GetMovieListResponse GetRandomMovieList()
        {
            var response = new GetMovieListResponse();
            var rand = new Random();
            var randList = new List<Movie>();
            var movies = _movieRepository.FindAll();

            if (movies != null)
            {
                var listcount = movies.Count() > 3 ? 2 : movies.Count();
                for (var ctr = 0; ctr <= listcount; )
                {
                    var i = rand.Next(0, movies.Count());
                    if (IsMovieInList(randList, movies[i])) continue;
                    randList.Add(movies[i]);
                    ctr++;
                }
                response.Successful = true;
                response.Movies = randList.ConvertToMovieListView();
            }
            else
            {
                response.Successful = false;
                response.Message = "No movies to select from.";
            }
            
            return response;
        }

        #endregion

        private static bool IsMovieInList(IEnumerable<Movie> movieList, Movie movie)
        {
            if (movieList == null) return false;
            return movieList.Where(m => m == movie).Count() != 0;
        }

        private static bool IsGenreInList(IEnumerable<Genre> genres, int genreId)
        {
            if (genres == null) return false;
            return genres.Where(g => g.Id == genreId).Count() != 0;
        }
    }
}