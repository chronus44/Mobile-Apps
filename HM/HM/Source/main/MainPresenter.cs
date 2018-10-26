using System;
namespace HM
{
    public class MainPresenter
    {
        private IMainView mView;
        private MainModel mModel = new MainModel();

        public MainPresenter()
        {
        }

        public void init(IMainView view) {
            mView = view;
            mView.updateMainView(mModel.getAvailableCategories());
        }
    }
}
