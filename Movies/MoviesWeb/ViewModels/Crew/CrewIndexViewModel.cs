using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWeb.ViewModels.Crew
{
    public class CrewIndexViewModel
    {
        public List<CrewViewModel> Crew { get; set; }
        public string SearchString { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
