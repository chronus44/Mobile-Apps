using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Runtime;
using System.Collections.Generic;
using Android.Views;
using Android.Content;

namespace HM.Source.payment
{
    [Activity(Name = "com.companyname.HM.Source.payment.PaymentAcitivity")]
    public class PaymentAcitivity : Activity
    {
        private ExpandableListView mListView;
        private PaymentAdapter mAdapter;

        private List<Payment> mData = PaymentFactory.producePayments();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity_payment);

            // Set toolbar
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Home Payments";
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetDisplayShowHomeEnabled(true);

            mListView = FindViewById<ExpandableListView>(Resource.Id.expandable_list);
            mAdapter = new PaymentAdapter(this, mData);
            mListView.SetAdapter(mAdapter);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                Payment payment = new Payment
                {
                    name = data.GetStringExtra("name"),
                    title = data.GetStringExtra("title"),
                    date = data.GetStringExtra("date"),
                    amount = data.GetDoubleExtra("amount", 0),
                    BSBNumber = data.GetStringExtra("bsb"),
                    account = data.GetStringExtra("account")
                };

                if (requestCode == PaymentAdapter.ADD) {
                    mData.Add(payment);
                } else if (requestCode == PaymentAdapter.EDIT) {
                    int index = data.GetIntExtra("index", -1);
                    if (index >= 0) {
                        mData[index] = payment;
                    }
                }
                mAdapter.NotifyDataSetChanged();
            }
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
