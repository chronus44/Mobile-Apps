using System;
using System.Collections.Generic;

namespace HM.Source.search
{
    public class SearchResultFactory
    {
        public SearchResultFactory()
        {
        }

        internal static List<SearchResult> getSearchResults()
        {
            List<SearchResult> results = new List<SearchResult>();
            SearchResult a = new SearchResult
            {
                imgResId = Resource.Mipmap.placeholder,
                title = "Home & Property Maintenance",
                address = "329 Lillian Ave, Brisbane QLD 4107",
                phone = "0731 510 342",
                distance = "200m",
                isFav = false,
            };
            results.Add(a);
            SearchResult b = new SearchResult
            {
                imgResId = Resource.Mipmap.placeholder,
                title = "Jade Garden Property Maintenance",
                address = "81 McCullough St, Sunnybank QLD 4109",
                phone = "0422 777 052",
                distance = "420m",
                isFav = false,
            };
            results.Add(b);
            SearchResult c = new SearchResult
            {
                imgResId = Resource.Mipmap.placeholder,
                title = "Anglicare Southern Queensland Home Maintenance and Modifications",
                address = "21 Martin St, Wooloongabba QLD 4102",
                phone = "1300 610 610",
                distance = "560m",
                isFav = false,
            };
            results.Add(c);
            SearchResult d = new SearchResult
            {
                imgResId = Resource.Mipmap.placeholder,
                title = "Maximum Home Maintenance Services",
                address = "Stellaris Way, Rochedale South QLD 4123",
                phone = "0414 061 789",
                distance = "1.3km",
                isFav = false,
            };
            results.Add(d);
            SearchResult e = new SearchResult
            {
                imgResId = Resource.Mipmap.placeholder,
                title = "Express Home Maintenance",
                address = "24 Morehead Ave, Norman Park QLD 4170",
                phone = "0419 026 397",
                distance = "1.8km",
                isFav = false,
            };
            results.Add(e);
            SearchResult f = new SearchResult
            {
                imgResId = Resource.Mipmap.placeholder,
                title = "NO MESS Property Maintenance Services Pty Ltd",
                address = "1 Tristan St, Carindale, Brisbane QLD 4152",
                phone = "0411 155 611",
                distance = "2.6km",
                isFav = false,
            };
            results.Add(f);
            return results;
        }
    }
}
