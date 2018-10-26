
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using HM.Source.calendar;
using HM.Source.payment;
using HM.Source.search;

namespace HM
{
    [Register("com.companyname.HM.MainFragment")]
    public class MainFragment : Fragment, IMainView
    {
        public View mView;
        public GridView mGridView;
        private List<Category> mCategories;
        public MainPresenter mPresenter = new MainPresenter();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            mView = inflater.Inflate(Resource.Layout.Fragment_main, container, false);
            mGridView = mView.FindViewById<GridView>(Resource.Id.gridView);
            mPresenter.init(this);
            return mView;
        }

        public void updateMainView(List<Category> categories)
        {
            MainAdpater adapter = new MainAdpater(categories, Context);
            mGridView.Adapter = adapter;
            mCategories = categories;
            mGridView.ItemClick += OnItemClick;
        }

        void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (mCategories == null || mCategories.Count == 0) {
                return;
            }
            if (e.Position == 0) {
                Intent intent = new Intent(Context, typeof(PaymentAcitivity));
                Context.StartActivity(intent);
            } else if (e.Position == 7) {
                Intent intent = new Intent(Context, typeof(CalendarActivity));
                Context.StartActivity(intent);
            } else {
                Intent intent = new Intent(Context, typeof(SearchActivity));
                intent.PutExtra("categoryTitle", mCategories[e.Position].title);
                intent.PutExtra("categoryImgResId", mCategories[e.Position].imgResId);
                intent.PutExtra("categoryKey", mCategories[e.Position].key);
                Context.StartActivity(intent);
            }
        }
    }
}
