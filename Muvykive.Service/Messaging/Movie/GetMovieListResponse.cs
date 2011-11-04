using System.Collections.Generic;
using Muvykive.Service.ViewModels;

namespace Muvykive.Service.Messaging.Movie
{
    public class GetMovieListResponse : Response
    {
        public IEnumerable<MovieListView> Movies { get; set; }
    }
}