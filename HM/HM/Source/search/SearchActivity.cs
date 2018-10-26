using Android.App;
using Android.OS;
using System;
using Android.Runtime;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;

namespace HM.Source.search
{
    [Activity(Name = "com.companyname.HM.Source.search.SearchActivity")]
    public class SearchActivity : Activity, ISearchView
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        SearchPresenter mPresenter;
        int yDelta;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity_search);

            // Get title
            string categoryTitle = Intent.GetStringExtra("categoryTitle");
            if (categoryTitle == null) {
                return;
            }
            // Set toolbar
            Android.Widget.Toolbar toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = categoryTitle;
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetDisplayShowHomeEnabled(true);

            // Init recycler view
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            // Init bar
            SetUpBar();

            mPresenter = new SearchPresenter(this);
            mPresenter.search();
        }

        private void SetUpBar() {
            LinearLayout listLayout = FindViewById<LinearLayout>(Resource.Id.ll_list);
            View imgBar = FindViewById<View>(Resource.Id.img_bar);
            int minY = 0;
            listLayout.ViewTreeObserver.GlobalLayout += (s, e) =>
            {
                minY = (int)listLayout.GetY();
            };
            imgBar.Touch += (s, e) =>
            {
                var handled = false;
                if (e.Event.Action == MotionEventActions.Down)
                {
                    // do stuff
                    yDelta = (int)(listLayout.GetY() - e.Event.RawY);
                    handled = true;
                }
                else if (e.Event.Action == MotionEventActions.Up)
                {
                    // do other stuff
                    handled = true;
                }
                else if (e.Event.Action == MotionEventActions.Move)
                {
                    if (listLayout.GetY() <= minY || e.Event.RawY + yDelta <= minY) {
                        listLayout.Animate().Y(e.Event.RawY + yDelta).SetDuration(0).Start();
                    }
                }
                e.Handled = handled;
            };
        }

        public void updateSearchResults(List<SearchResult> list)
        {
            SearchAdapter adapter = new SearchAdapter(list);
            mRecyclerView.SetAdapter(adapter);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}
