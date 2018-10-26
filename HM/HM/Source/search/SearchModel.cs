using System;
using System.Collections.Generic;

namespace HM.Source.search
{
    public class SearchModel
    {
        public SearchModel()
        {
        }

        public List<SearchResult> getSearchResults() {
            return SearchResultFactory.getSearchResults();
        }
    }
}
