namespace ApplicationCore.Paging
{
    public class LinkInfo : Interfaces.Paging.ILinkInfo
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
}
