using AutoMapper;
using Muvykive.Model.Movies;
using Muvykive.Service.Mapping;
using Muvykive.Service.ViewModels;

namespace Muvykive.Service
{
    public class InitAutoMapper
    {
        /// <summary>
        /// Initialize Automapper
        /// </summary>
        public static void Initialize()
        {
            // Movie
            Mapper.CreateMap<Movie, MovieListView>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.ConverToGenreListView()));

            Mapper.CreateMap<Movie, MovieDetailView>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.ConverToGenreListView()));

            Mapper.CreateMap<Genre, GenreListView>();

            Mapper.CreateMap<Certification, CertificationListView>();
        }
    }
}