using Muvykive.Service.ViewModels;

namespace Muvykive.Service.Messaging.Movie
{
    public class GetMovieDetailResponse : Response
    {
        public MovieDetailView Movie { get; set; }
    }
}