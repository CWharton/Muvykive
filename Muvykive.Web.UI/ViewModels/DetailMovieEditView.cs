using System.Web.Mvc;
using Muvykive.Service.ViewModels;

namespace Muvykive.Web.UI.ViewModels
{
    public class DetailMovieEditView
    {
        public MovieDetailView Movie { get; set; }
        public SelectList Genres { get; set; }
        public SelectList Certifications { get; set; }
    }
}