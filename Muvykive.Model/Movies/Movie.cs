using System;
using System.Collections.Generic;

namespace Muvykive.Model.Movies
{
    public class Movie
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Certification Certification { get; set; }
        public virtual int? CertificationId { get; set; }
        public virtual DateTime? Released { get; set; }
        public virtual int? RunTime { get; set; }

        public virtual IList<Genre> Genres { get; set; }
    }
}