using System.Collections.Generic;
using AutoMapper;
using Muvykive.Model.Movies;
using Muvykive.Service.ViewModels;

namespace Muvykive.Service.Mapping
{
    /// <summary>
    /// Conversion function to flatten domain model
    /// </summary>
    public static class CertificationMapping
    {
        public static IEnumerable<CertificationListView> ConverToCertificationListView(this IEnumerable<Certification> certification)
        {
            return Mapper.Map<IEnumerable<Certification>, IEnumerable<CertificationListView>>(certification);
        }
    }
}