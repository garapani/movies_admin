using System.Runtime.Serialization;

namespace ApplicationCore.Paging
{
    [DataContract]
    public sealed class QueryParams
    {
        [DataMember(Name = "itemsPerPage")]
        public int? ItemsPerPage { get; set; }

        [DataMember(Name = "pageNumber")]
        public int? PageNumber { get; set; }

        [DataMember(Name = "searchString")]
        public string SearchString { get; set; }

        [DataMember(Name = "pageId")]
        public string PageId { get; set; }
    }
}
