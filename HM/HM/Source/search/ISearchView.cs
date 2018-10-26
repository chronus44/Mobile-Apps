using System;
using System.Collections.Generic;

namespace HM.Source.search
{
    public interface ISearchView
    {
        void updateSearchResults(List<SearchResult> list);
    }
}
