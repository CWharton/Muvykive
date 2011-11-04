using System;

namespace Muvykive.Service.Messaging.Movie
{
    public class AddUpdateMovieRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CertificationId { get; set; }
        public DateTime? Released { get; set; }
        public int? RunTime { get; set; }
        public int GenresId { get; set; }
    }
}