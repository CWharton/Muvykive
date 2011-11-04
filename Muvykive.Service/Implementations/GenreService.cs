using System.Collections.Generic;
using Muvykive.Model.Movies;
using Muvykive.Service.Interfaces;
using Muvykive.Service.Mapping;
using Muvykive.Service.Messaging.Movie;

namespace Muvykive.Service.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        #region IGenreService Members

        public GetGenreListResponse GetGenres()
        {
            IEnumerable<Genre> genres = _genreRepository.FindAll();
            var response = new GetGenreListResponse {Genres = genres.ConverToGenreListView()};
            return response;
        }

        #endregion
    }
}
