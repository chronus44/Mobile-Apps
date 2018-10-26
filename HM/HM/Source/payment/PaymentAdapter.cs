using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace HM.Source.payment
{
    public class PaymentAdapter : BaseExpandableListAdapter
    {
        private readonly Activity mActivity;
        private List<Payment> mData;

        public static readonly int ADD = 1;
        public static readonly int EDIT = 0;

        public PaymentAdapter(Activity activity, List<Payment> data)
        {
            mActivity = activity;
            mData = data;
        }

        public override int GroupCount => mData.Count;

        public override bool HasStableIds => true;

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return mData[groupPosition];
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return 1;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return mData[groupPosition];
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                var inflater = mActivity.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(Resource.Layout.Layout_item_payment_child, null);
            }

            TextView tvName = view.FindViewById<TextView>(Resource.Id.tv_name);
            TextView tvAmount = view.FindViewById<TextView>(Resource.Id.tv_amount);
            TextView tvDate = view.FindViewById<TextView>(Resource.Id.tv_date);
            TextView tvBSB = view.FindViewById<TextView>(Resource.Id.tv_bsb);
            TextView tvAccount = view.FindViewById<TextView>(Resource.Id.tv_account);
            View addToCalendar = view.FindViewById<View>(Resource.Id.tv_add_to_calendar);

            View add = view.FindViewById<View>(Resource.Id.add);

            View edit = view.FindViewById<View>(Resource.Id.edit);

            View delete = view.FindViewById<View>(Resource.Id.delete);


            Payment data = mData[groupPosition];

            tvName.Text = "Name: " + data.name;
            tvAmount.Text = "Payment amount: $" + data.amount;
            tvDate.Text = "Due Date: " + data.date;
            tvBSB.Text = "- BSB Number: " + data.BSBNumber;
            tvAccount.Text = "Account Number: " + data.account;

            addToCalendar.Click += (o, e) => {
                var progressDialog = ProgressDialog.Show(view.Context, "Please wait...", "Adding to calendar...", true);
                progressDialog.SetCanceledOnTouchOutside(true);
                Handler h = new Handler();
                Action myAction = () =>
                {
                    progressDialog.Dismiss();
                    Toast.MakeText(view.Context, "Add successfully", ToastLength.Short).Show();
                };
                h.PostDelayed(myAction, 2000);
            };

            add.Click += (o, e) => {
                Intent intent = new Intent(mActivity, typeof(PaymentEditActivity));
                Bundle bundle = new Bundle();
                intent.PutExtras(bundle);
                mActivity.StartActivityForResult(intent, ADD);
            };

            edit.Click += (o, e) => {
                Intent intent = new Intent(mActivity, typeof(PaymentEditActivity));
                intent.PutExtra("index", groupPosition);
                intent.PutExtra("title", data.title);
                intent.PutExtra("name", data.name);
                intent.PutExtra("amount", data.amount);
                intent.PutExtra("date", data.date);
                intent.PutExtra("bsb", data.BSBNumber);
                intent.PutExtra("account", data.account);
                mActivity.StartActivityForResult(intent, EDIT);
            };

            delete.Click += (o, e) => {
                mData.Remove(data);
                NotifyDataSetChanged();
            };

            return view;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                var inflater = mActivity.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(Resource.Layout.Layout_item_payment_parent, null);
            }
            TextView tvTitle = view.FindViewById<TextView>(Resource.Id.tv_title);
            Payment data = mData[groupPosition];

            tvTitle.Text = data.getTitle();

            return view;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }
    }

}
