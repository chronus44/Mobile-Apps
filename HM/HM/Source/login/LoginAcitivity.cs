using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Runtime;
using System.Collections.Generic;
using Android.Views;

namespace HM.Source.login
{
    [Activity(Name = "com.companyname.HM.Source.login.LoginAcitivity")]
    public class LoginAcitivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity_login);

            // Set toolbar
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Login";
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetDisplayShowHomeEnabled(true);

            Button submit = FindViewById<Button>(Resource.Id.submit);
            submit.Click += (o, e) =>
            {
                var progressDialog = ProgressDialog.Show(this, "Please wait...", "Checking account info...", true);
                progressDialog.SetCanceledOnTouchOutside(true);
                Handler h = new Handler();
                Action myAction = () =>
                {
                    progressDialog.Dismiss();
                    Toast.MakeText(this, "Submit successfully", ToastLength.Short).Show();
                    SetResult(Result.Ok);
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
