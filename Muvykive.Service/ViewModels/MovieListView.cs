using System;
using System.Collections.Generic;

namespace Muvykive.Service.ViewModels
{
    public class MovieListView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CertificationAbbreviation { get; set; }
        public string CertificationRating { get; set; }
        public DateTime Released { get; set; }
        public int RunTime { get; set; }

        public IEnumerable<GenreListView> Genres { get; set; }
    }
}