using System.Collections.Generic;
using AutoMapper;
using Muvykive.Model.Movies;
using Muvykive.Service.ViewModels;

namespace Muvykive.Service.Mapping
{
    /// <summary>
    /// Conversion function to flatten domain model
    /// </summary>
    public static class GenreMapping
    {
        public static IEnumerable<GenreListView> ConverToGenreListView(this IEnumerable<Genre> genre)
        {
            return Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreListView>>(genre);
        }
    }
}