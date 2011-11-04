using Muvykive.Service.ViewModels;

namespace Muvykive.Service.Messaging.Movie
{
    public class AddUpdateMovieResponse : Response
    {
        public int Id { get; set; }
        public MovieDetailView Movie { get; set; }
    }
}