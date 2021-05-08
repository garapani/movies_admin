using System.Collections.Generic;

namespace MoviesWeb.ViewModels.Movie
{
    public class MovieIndexViewModel
    {
        public List<MovieViewModel> Movies { get; set; }
        public string SearchString { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set;}
    }
}
