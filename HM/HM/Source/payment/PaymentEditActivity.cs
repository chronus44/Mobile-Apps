using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Runtime;
using System.Collections.Generic;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Content;

namespace HM.Source.payment
{
    [Activity(Name = "com.companyname.HM.Source.payment.PaymentEditActivity")]
    public class PaymentEditActivity : Activity
    {
        private bool mIsAdd;

        private TextInputLayout mTilName;
        private TextInputLayout mTilAmount;
        private TextInputLayout mTilDue;
        private TextInputLayout mTilBSB;
        private TextInputLayout mTilAccount;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity_payment_edit);


            String title = Intent.GetStringExtra("title");
            mIsAdd = title == null;
            // Set toolbar
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = mIsAdd ? "Add a new item" : title;
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetDisplayShowHomeEnabled(true);

            mTilName = FindViewById<TextInputLayout>(Resource.Id.til_name);
            mTilAmount = FindViewById<TextInputLayout>(Resource.Id.til_amount);
            mTilDue = FindViewById<TextInputLayout>(Resource.Id.til_due);
            mTilBSB = FindViewById<TextInputLayout>(Resource.Id.til_bsb);
            mTilAccount = FindViewById<TextInputLayout>(Resource.Id.til_account);

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);
            var adapter = new PaymentSpinnerAdapter(PaymentFactory.producePayments(), this);
            spinner.Adapter = adapter;
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            if (!mIsAdd)
            {
                restoreInfo(Intent);
                spinner.Visibility = ViewStates.Gone;
            }
            Button submit = FindViewById<Button>(Resource.Id.submit);
            submit.Click += (o, e) =>
            {
                var progressDialog = ProgressDialog.Show(this, "Please wait...", "Updating info...", true);
                progressDialog.SetCanceledOnTouchOutside(true);
                Handler h = new Handler();
                Action myAction = () =>
                {
                    progressDialog.Dismiss();
                    Toast.MakeText(this, "Submit successfully", ToastLength.Short).Show();
                    Intent intent = new Intent();
                    intent.PutExtra("index", mIsAdd ? -1 : Intent.GetIntExtra("index", -1));
                    intent.PutExtra("title", mIsAdd ? ((String)spinner.SelectedItem): intent.GetStringExtra("title"));
                    intent.PutExtra("name", mTilName.EditText.Text);
                    intent.PutExtra("amount", Convert.ToDouble(mTilAmount.EditText.Text));
                    intent.PutExtra("date", mTilDue.EditText.Text);
                    intent.PutExtra("bsb", mTilBSB.EditText.Text);
                    intent.PutExtra("account", mTilAccount.EditText.Text);
                    SetResult(Result.Ok, intent);
                    Finish();
                };
                h.PostDelayed(myAction, 2000);
            };

            Button cancel = FindViewById<Button>(Resource.Id.cancel);
            cancel.Click += (o, e) =>
            {
                Finish();
            };
        }

        private void restoreInfo(Intent intent)
        {
            if (intent == null) {
                return;
            }
            mTilName.EditText.Text = intent.GetStringExtra("name");
            mTilDue.EditText.Text = intent.GetStringExtra("date");
            mTilAmount.EditText.Text = intent.GetDoubleExtra("amount", 0) + "";
            mTilBSB.EditText.Text = intent.GetStringExtra("bsb");
            mTilAccount.EditText.Text = intent.GetStringExtra("account");
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
           
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
