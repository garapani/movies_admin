using System.Collections.Generic;

namespace MoviesWeb.ViewModels.Director
{
    public class DirectorIndexViewModel
    {
        public List<DirectorViewModel> Directors { get; set; }
        public string SearchString { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
