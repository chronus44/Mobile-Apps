using System;
using Android.Views;
using Android.Content;
using Android.Widget;
using Java.Lang;
using System.Collections.Generic;
using HM.Source.search;
using Android.OS;

namespace HM
{
    public class MainAdpater: BaseAdapter<Category>
    {
        private List<Category> mCategories;
        private Context mContext;

        public MainAdpater(List<Category> categories, Context context)
        {
            mCategories = categories;
            mContext = context;
        }

        public override Category this[int position] => mCategories[position];

        public override int Count => mCategories == null ? 0 : mCategories.Count;

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {  // if it's not recycled, initialize some attributes
                convertView = View.Inflate(mContext, Resource.Layout.Layout_main_item, null);
            }

            ImageView imageView = convertView.FindViewById<ImageView>(Resource.Id.img);
            TextView textView = convertView.FindViewById<TextView>(Resource.Id.tv_title);
            imageView.SetImageResource(mCategories[position].imgResId);
            textView.Text = (mCategories[position].title);
            return convertView;
        }
    }
}
