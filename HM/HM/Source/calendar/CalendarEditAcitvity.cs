
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Java.Text;
using Java.Util;

namespace HM.Source.calendar
{
    [Activity(Name = "com.companyname.HM.Source.calendar.CalendarEditAcitvity")]
    public class CalendarEditAcitvity : Activity
    {
        private bool mIsAdd;

        private TextInputLayout mTilName;
        private TextInputLayout mTilDate;
        private TextInputLayout mTilTime;
        private TextInputLayout mTilLocation;
        private TextInputLayout mTilDuration;
        private TextInputLayout mTilDesc;
        private TextInputLayout mTilOcc;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity_calendar_edit);


            String title = Intent.GetStringExtra("title");
            mIsAdd = title == null;
            // Set toolbar
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = mIsAdd ? "Add a new item" : title;
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetDisplayShowHomeEnabled(true);

            mTilName = FindViewById<TextInputLayout>(Resource.Id.til_name);
            mTilDate = FindViewById<TextInputLayout>(Resource.Id.til_date);
            mTilTime = FindViewById<TextInputLayout>(Resource.Id.til_time);
            mTilLocation = FindViewById<TextInputLayout>(Resource.Id.til_location);
            mTilDuration = FindViewById<TextInputLayout>(Resource.Id.til_duration);
            mTilDesc = FindViewById<TextInputLayout>(Resource.Id.til_desc);
            mTilOcc = FindViewById<TextInputLayout>(Resource.Id.til_occ);

            if (!mIsAdd) {
                String name = Intent.GetStringExtra("name");
                Calendar date = (Java.Util.Calendar)Intent.GetSerializableExtra("date");
                SimpleDateFormat format = new SimpleDateFormat("MM-dd-yyyy");
                String dateStr = format.Format(date.Time);
                String time = Intent.GetStringExtra("time");
                String location = Intent.GetStringExtra("location");
                String duration = Intent.GetStringExtra("duration");
                String Description = Intent.GetStringExtra("desc");
                String Occurence = Intent.GetStringExtra("occ");

                mTilName.EditText.Text = name;
                mTilDate.EditText.Text = dateStr;
                mTilTime.EditText.Text = time;
                mTilLocation.EditText.Text = location;
                mTilDuration.EditText.Text = duration;
                mTilDesc.EditText.Text = Description;
                mTilOcc.EditText.Text = Occurence;
            }

            Button submit = FindViewById<Button>(Resource.Id.submit);
            submit.Click += (o, e) => {
                Intent intent = new Intent();
                intent.PutExtra("index", mIsAdd ? -1 : Intent.GetIntExtra("index", -1));
                intent.PutExtra("name", mTilName.EditText.Text);
                Calendar calendar = Calendar.GetInstance(new Locale("en_AU"));
                SimpleDateFormat sdf = new SimpleDateFormat("MM-dd-yyyy HH:mm a", new Locale("en_AU"));
                calendar.Time = sdf.Parse(mTilDate.EditText.Text + " " + mTilTime.EditText.Text);
                intent.PutExtra("date", calendar);
                intent.PutExtra("duration", mTilDuration.EditText.Text);
                intent.PutExtra("location", mTilLocation.EditText.Text);
                intent.PutExtra("desc", mTilDesc.EditText.Text);
                intent.PutExtra("occ", mTilOcc.EditText.Text);
                if (!mIsAdd) {
                    Calendar origin = (Java.Util.Calendar)Intent.GetSerializableExtra("date");
                    SimpleDateFormat format = new SimpleDateFormat("MM-dd-yyyy");
                    String dateStr = format.Format(origin.Time);
                    intent.PutExtra("originDate", dateStr);
                }
                SetResult(Result.Ok, intent);
                Finish();
            };

            Button cancel = FindViewById<Button>(Resource.Id.cancel);
            cancel.Click += (o, e) => {
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
