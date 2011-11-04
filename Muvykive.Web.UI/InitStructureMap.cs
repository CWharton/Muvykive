using Muvykive.Model;
using Muvykive.Model.Movies;
using Muvykive.Repository;
using Muvykive.Repository.Repositories;
using Muvykive.Service.Implementations;
using Muvykive.Service.Interfaces;
using StructureMap;

namespace Muvykive.Web.UI
{
    /// <summary>
    /// Initialize StructureMap to handle Dependency Injection
    /// </summary>
    public class InitStructureMap
    {
        public static void InitializeDependencies()
        {
            ObjectFactory.Initialize(x =>
                                         {
                                             x.For<IUnitOfWork>().Use<NHUnitOfWork>();

                                             // Repositories
                                             x.For<IMovieRepository>().Use<MovieRepository>();
                                             x.For<IGenreRepository>().Use<GenreRepository>();
                                             x.For<ICertificationRepository>().Use<CertificationRepository>();

                                             // Service
                                             x.For<IMovieService>().Use<MovieService>();
                                             x.For<IGenreService>().Use<GenreService>();
                                             x.For<ICertificationService>().Use<CertificationService>();

                                         });
        }
    }
}