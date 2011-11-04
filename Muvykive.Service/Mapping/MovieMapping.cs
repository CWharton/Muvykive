using System.Collections.Generic;
using AutoMapper;
using Muvykive.Model.Movies;
using Muvykive.Service.ViewModels;

namespace Muvykive.Service.Mapping
{
    /// <summary>
    /// Conversion function to flatten domain model
    /// </summary>
    public static class MovieMapping
    {
        public static IEnumerable<MovieListView> ConvertToMovieListView(this IEnumerable<Movie> movies)
        {
            return Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieListView>>(movies);
        }

        public static MovieDetailView ConvertToMovieDetailView(this Movie movie)
        {
            return Mapper.Map<Movie, MovieDetailView>(movie);
        }   
    }
}