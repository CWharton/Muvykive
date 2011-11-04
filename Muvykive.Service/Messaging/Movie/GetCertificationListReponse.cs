using System.Collections.Generic;
using Muvykive.Service.ViewModels;

namespace Muvykive.Service.Messaging.Movie
{
    public class GetCertificationListReponse
    {
        public IEnumerable<CertificationListView> Certifications { get; set; }
    }
}
