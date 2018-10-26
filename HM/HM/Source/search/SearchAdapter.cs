using System;
using System.Collections.Generic;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace HM.Source.search
{
    public class SearchAdapter : RecyclerView.Adapter
    {
        private List<SearchResult> mSearchResults;

        public SearchAdapter(List<SearchResult> list)
        {
            mSearchResults = list;
            NotifyDataSetChanged();
        }

        public override int ItemCount => mSearchResults == null ? 0 : mSearchResults.Count;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                                          Inflate(Resource.Layout.Layout_item_search_result, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            VH vh = new VH(itemView);
            return vh;
        }

        private class VH : RecyclerView.ViewHolder
        {

            public ImageView imgDesc;
            public TextView tvTitle;
            public TextView tvAddress;
            public TextView tvPhone;
            public TextView tvDistance;
            public ImageView imgFav;

            public VH(View itemView) : base(itemView)
            {
                // Locate and cache view references:
                imgDesc = itemView.FindViewById<ImageView>(Resource.Id.img_desc);
                tvTitle = itemView.FindViewById<TextView>(Resource.Id.tv_title);
                tvAddress = itemView.FindViewById<TextView>(Resource.Id.tv_address);
                tvPhone = itemView.FindViewById<TextView>(Resource.Id.tv_phone);
                tvDistance = itemView.FindViewById<TextView>(Resource.Id.tv_distance);
                imgFav = itemView.FindViewById<ImageView>(Resource.Id.img_fav);
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            VH vh = holder as VH;

            vh.imgDesc.SetImageResource(mSearchResults[position].imgResId);
            vh.tvTitle.Text = mSearchResults[position].title;
            vh.tvAddress.Text = mSearchResults[position].address;
            vh.tvPhone.Text = mSearchResults[position].phone;
            vh.tvDistance.Text = mSearchResults[position].distance;
            if (mSearchResults[position].isFav) {
                vh.imgFav.SetImageResource(Resource.Mipmap.star_select);
            }
            else
            {
                vh.imgFav.SetImageResource(Resource.Mipmap.star);
            }
            vh.imgFav.Click += (o, e) => {
                if (holder.AdapterPosition < 0) {
                    return;
                }
                mSearchResults[holder.AdapterPosition].isFav = !mSearchResults[holder.AdapterPosition].isFav;
                NotifyDataSetChanged();
            };
        }
    }
}
