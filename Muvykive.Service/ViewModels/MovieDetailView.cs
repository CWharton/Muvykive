using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Muvykive.Service.ViewModels
{
    public class MovieDetailView
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        [DisplayName("Movie")]
        public string Name { get; set; }

        public string CertificationAbbreviation { get; set; }
        public string CertificationRating { get; set; }

        public int? CertificationId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Release Date")]
        public DateTime? Released { get; set; }

        [DisplayName("Run time")]
        public int? RunTime { get; set; }

        public IEnumerable<GenreListView> Genres { get; set; }
    }
}