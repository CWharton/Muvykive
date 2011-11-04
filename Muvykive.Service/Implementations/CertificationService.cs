using System.Collections.Generic;
using Muvykive.Model.Movies;
using Muvykive.Service.Interfaces;
using Muvykive.Service.Mapping;
using Muvykive.Service.Messaging.Movie;

namespace Muvykive.Service.Implementations
{
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository _certificationRepository;

        public CertificationService(ICertificationRepository certificationRepository)
        {
            _certificationRepository = certificationRepository;
        }

        #region ICertificationService Members

        public GetCertificationListReponse GetCertification()
        {
            IEnumerable<Certification> certification = _certificationRepository.FindAll();
            var reponse = new GetCertificationListReponse {Certifications = certification.ConverToCertificationListView()};
            return reponse;
        }

        #endregion
    }
}
