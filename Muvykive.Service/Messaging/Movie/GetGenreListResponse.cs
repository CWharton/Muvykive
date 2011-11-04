using System.Collections.Generic;
using Muvykive.Service.ViewModels;

namespace Muvykive.Service.Messaging.Movie
{
    public class GetGenreListResponse : Response
    {
        public IEnumerable<GenreListView> Genres { get; set; }
    }
}
