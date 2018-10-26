using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using HM.Source.login;
using System.Collections.Generic;
using HM.Source.payment;
using HM.Source.search;
using Android.Views;
using HM.Source.calendar;

namespace HM
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private ImageView login;
        private List<Category> mCategories = CategoryFactory.produceAvailableCategories();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource


            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            login = FindViewById<ImageView>(Resource.Id.img_login);
            login.Click += (o, e) =>
            {
                Intent intent = new Intent(this, typeof(LoginAcitivity));
                StartActivityForResult(intent, 1);
            };
            ImageView drawer = FindViewById<ImageView>(Resource.Id.img_drawer);
            drawer.Click += (o, e) => {
                spinner.PerformClick();
            };
            String[] say = new string[] { };
            var adapter = new SpinnerAdapter(mCategories, this);
            spinner.DropDownVerticalOffset = 100;
            spinner.Adapter = adapter;

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 1)
            {
                if (resultCode == Result.Ok) {
                    login.Visibility = Android.Views.ViewStates.Gone;
                }
            }
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (mCategories == null || mCategories.Count == 0)
            {
                return;
            }
            if (e.Position == 0)
            {
                Intent intent = new Intent(this, typeof(PaymentAcitivity));
                StartActivity(intent);
            }
            else if (e.Position == 7)
            {
                Intent intent = new Intent(this, typeof(CalendarActivity));
                StartActivity(intent);
            }
            else
            {
                Intent intent = new Intent(this, typeof(SearchActivity));
                intent.PutExtra("categoryTitle", mCategories[e.Position].title);
                intent.PutExtra("categoryImgResId", mCategories[e.Position].imgResId);
                intent.PutExtra("categoryKey", mCategories[e.Position].key);
                StartActivity(intent);
            }
        }

        public void OnNothingSelected(AdapterView parent)
        {

        }
    }

}

