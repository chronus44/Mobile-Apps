using System;
using Android.Views;
using Android.Content;
using Android.Widget;
using Java.Lang;
using System.Collections.Generic;
using HM.Source.login;
using HM.Source.search;
using HM.Source.payment;

namespace HM
{
    public class SpinnerAdapter : BaseAdapter<string>
    {
        private List<Category> mCategories;
        private Context mContext;

        public SpinnerAdapter(List<Category> categories, Context context)
        {
            mCategories = categories;
            mContext = context;
        }

        public override string this[int position] => mCategories[position].title;

        public override int Count => mCategories == null ? 0 : mCategories.Count;

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {  // if it's not recycled, initialize some attributes
                convertView = View.Inflate(mContext, Resource.Layout.Layout_spinner_item, null);
            }
            TextView textView = convertView.FindViewById<TextView>(Resource.Id.tv_title);
            textView.Text = (mCategories[position].title);
            return convertView;
        }
    }
}
