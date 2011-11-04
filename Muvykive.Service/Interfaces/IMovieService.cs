using Muvykive.Service.Messaging.Movie;

namespace Muvykive.Service.Interfaces
{
    public interface IMovieService
    {
        GetMovieListResponse GetMovies();
        GetMovieDetailResponse GetMovie(int id);
        AddUpdateMovieResponse AddUpdateMovie(AddUpdateMovieRequest request);
        AddMovieGenreResponse AddMovieGenre(AddMovieGenreRequest request);

        /// <summary>
        /// Returns random movie selection
        /// </summary>
        GetMovieListResponse GetRandomMovieList();
    }
}