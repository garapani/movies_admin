using System.Collections.Generic;

namespace MoviesWeb.ViewModels.Actor
{
    public class ActorIndexViewModel
    {
        public List<ActorViewModel> Actors { get; set; }
        public string SearchString { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
