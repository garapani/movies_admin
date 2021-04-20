using System.Runtime.Serialization;

namespace ApplicationCore.Paging
{
    [DataContract]
    public sealed class QueryParams
    {
        private int _pageNumber = 1;
        [DataMember(Name = "pageNumber")]
        public int PageNumber { get { return _pageNumber; } set { _pageNumber = value; } }
        [DataMember(Name = "itemsPerPage")]
        public int? ItemsPerPage { get; set; }
        [DataMember(Name = "searchString")]
        public string SearchString { get; set; }
    }
}
