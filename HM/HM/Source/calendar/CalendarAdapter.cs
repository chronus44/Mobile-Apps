using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Java.Text;

namespace HM.Source.calendar
{
    public class CalendarAdapter : RecyclerView.Adapter
    {
        private List<HMEvent> mData;
        private Activity mActivity;
        private BottomSheetDialog mDialog;
        public static readonly int EDIT = 1;
        public static readonly int ADD = 2;

        public CalendarAdapter(Activity activity, BottomSheetDialog dialog, List<HMEvent> list)
        {
            mData = list;
            mDialog = dialog;
            mActivity = activity;
            NotifyDataSetChanged();
        }

        public override int ItemCount => mData == null ? 0 : mData.Count;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                                          Inflate(Resource.Layout.Layout_item_event, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            VH vh = new VH(itemView);
            return vh;
        }

        private class VH : RecyclerView.ViewHolder
        {

            public TextView tvTime;
            public TextView tvDuration;
            public TextView tvName;
            public TextView tvLocation;
            public TextView tvDesc;
            public Button add;
            public Button edit;
            public Button delete;

            public VH(View itemView) : base(itemView)
            {
                // Locate and cache view references:
                tvTime = itemView.FindViewById<TextView>(Resource.Id.tv_time);
                tvDuration = itemView.FindViewById<TextView>(Resource.Id.tv_duration);
                tvName = itemView.FindViewById<TextView>(Resource.Id.tv_name);
                tvLocation = itemView.FindViewById<TextView>(Resource.Id.tv_location);
                tvDesc = itemView.FindViewById<TextView>(Resource.Id.tv_desc);
                add = itemView.FindViewById<Button>(Resource.Id.add);
                edit = itemView.FindViewById<Button>(Resource.Id.edit);
                delete = itemView.FindViewById<Button>(Resource.Id.delete);
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            VH vh = holder as VH;

            SimpleDateFormat format = new SimpleDateFormat("hh:mm a");
            String time = format.Format(mData[position].date.Time);
            vh.tvTime.Text = time;
            vh.tvDuration.Text = mData[position].duraion;
            vh.tvName.Text = mData[position].name;
            vh.tvLocation.Text = mData[position].location;
            vh.tvDesc.Text = mData[position].desc;
            vh.delete.Click += (o, e) => {
                if (position > ItemCount - 1) {
                    return;
                }
                mData.Remove(mData[position]);
                NotifyDataSetChanged();
                if (mData.Count == 0) {
                    mDialog.Dismiss();
                }
            };
            vh.edit.Click += (o, e) =>
            {
                HMEvent data = mData[position];
                Intent intent = new Intent(mActivity, typeof(CalendarEditAcitvity));
                intent.PutExtra("title", "Edit event");
                intent.PutExtra("name", data.name);
                intent.PutExtra("date", data.date);
                intent.PutExtra("time", time);
                intent.PutExtra("duration", data.duraion);
                intent.PutExtra("location", data.location);
                intent.PutExtra("desc", data.desc);
                intent.PutExtra("occ", data.occurence.ToString());
                intent.PutExtra("index", position);
                mActivity.StartActivityForResult(intent, EDIT);
            };
            vh.add.Click += (o, e) =>
            {
                Intent intent = new Intent(mActivity, typeof(CalendarEditAcitvity));
                mActivity.StartActivityForResult(intent, ADD);
            };
            if (position == mData.Count - 1) {
                vh.add.Visibility = ViewStates.Visible;
            } else {
                vh.add.Visibility = ViewStates.Gone;
            }
        }
    }
}
