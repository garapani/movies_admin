namespace ApplicationCore.Interfaces.Paging
{
    public interface ILinkInfo
    {
        string Href { get; set; }
        string Rel { get; set; }
        string Method { get; set; }
    }
}
