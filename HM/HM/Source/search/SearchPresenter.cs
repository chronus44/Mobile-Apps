using System;
namespace HM.Source.search
{
    public class SearchPresenter
    {
        private SearchModel mModel = new SearchModel();
        private ISearchView mView;

        public SearchPresenter(ISearchView view)
        {
            mView = view;
        }

        public void search() {
            mView.updateSearchResults(mModel.getSearchResults());
        }
    }
}
