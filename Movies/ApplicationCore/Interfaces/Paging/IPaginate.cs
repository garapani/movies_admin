using System.Collections.Generic;

namespace ApplicationCore.Interfaces.Paging
{
    public interface IPaginate<T>
    {
        int From { get; }

        int Index { get; }

        int Size { get; }

        int Count { get; }

        int Pages { get; }

        IList<T> Items { get; }

        bool HasPrevious { get; }

        bool HasNext { get; }

        ILinkInfo PrevLink { get; set; }
        ILinkInfo NextLink { get; set; }
        ILinkInfo CurrentLink { get; set; }
    }
}
