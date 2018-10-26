using Android.App;
using Android.OS;
using System;
using Android.Runtime;
using System.Collections.Generic;
using Android.Views;
using Com.Applandeo.Materialcalendarview;
using Android.Widget;
using CalendarView = Com.Applandeo.Materialcalendarview.CalendarView;
using Android.Support.Constraints;
using Java.Util;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Content;
using Java.Text;

namespace HM.Source.calendar
{
    [Activity(Name = "com.companyname.HM.Source.calendar.CalendarActivity")]
    public class CalendarActivity : Activity, IDialogInterfaceOnDismissListener
    {
        private Dictionary<string, List<HMEvent>> mDict = HMEventFactory.produceEvents();
        private Dictionary<string, CalendarAdapter> mAdapterDict = new Dictionary<string, CalendarAdapter>();

        private CalendarView mCalendarView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity_calendar);

            // Set toolbar
            Android.Widget.Toolbar toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Calendar";
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetDisplayShowHomeEnabled(true);

            mCalendarView = FindViewById<CalendarView>(Resource.Id.calendar);
            initCalendar();
            mCalendarView.DayClick += (o, e) => {
                bool hasEvent = false;
                foreach (KeyValuePair<string, List<HMEvent>> entry in mDict) {
                    String dateStr = new SimpleDateFormat("MM-dd-yyyy").Format(e.P0.Calendar.Time);
                    if (entry.Key.Equals(dateStr)) {
                        List<HMEvent> events = entry.Value;
                        RecyclerView recyclerView = new RecyclerView(this);
                        recyclerView.SetLayoutManager(new LinearLayoutManager(this));
                        BottomSheetDialog dialog = new BottomSheetDialog(this);
                        CalendarAdapter adapter = new CalendarAdapter(this, dialog, events);
                        recyclerView.SetAdapter(adapter);
                        dialog.SetContentView(recyclerView);
                        dialog.Show();
                        dialog.SetOnDismissListener(this);
                        if (!mAdapterDict.ContainsKey(dateStr)) {
                            mAdapterDict.Add(dateStr, adapter);
                        }
                        hasEvent = true;
                        break;
                    }
                }
                if (!hasEvent) {
                    Intent intent = new Intent(this, typeof(CalendarEditAcitvity));
                    StartActivityForResult(intent, CalendarAdapter.ADD);
                }
            };
        }


        private void removeUselessData()
        {
            List<string> useless = new List<string>();
            foreach (KeyValuePair<string, List<HMEvent>> entry in mDict)
            {
                if (entry.Value.Count == 0)
                {
                    useless.Add(entry.Key);
                }
            }

            foreach (String s in useless) {
                mDict.Remove(s);
            }
        }

        private void initCalendar()
        {
            removeUselessData();
            List<EventDay> events = new List<EventDay>();
            foreach (KeyValuePair<string, List<HMEvent>> entry in mDict)
            {
                Calendar calendar = Calendar.GetInstance(new Locale("en_AU"));
                SimpleDateFormat sdf = new SimpleDateFormat("MM-dd-yyyy", new Locale("en_AU"));
                calendar.Time = sdf.Parse(entry.Key);
                EventDay eventDay = new EventDay(calendar, Resource.Mipmap.cleaning);
                events.Add(eventDay);
            }
            mCalendarView.SetEvents(events);
        }

        public void OnDismiss(IDialogInterface dialog)
        {
            initCalendar();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                HMEvent e = new HMEvent
                {
                    name = data.GetStringExtra("name"),
                    date = (Java.Util.Calendar)data.GetSerializableExtra("date"),
                    location = data.GetStringExtra("location"),
                    duraion = data.GetStringExtra("duration"),
                    desc = data.GetStringExtra("desc"),
                    occurence = data.GetStringExtra("occ")
                };
                String occ = data.GetStringExtra("occ");
                SimpleDateFormat sdf = new SimpleDateFormat("MM-dd-yyyy", new Locale("en_AU"));
                String dateStr = sdf.Format(e.date.Time);
                if (requestCode == CalendarAdapter.ADD)
                {
                    if (mDict.ContainsKey(dateStr)) {
                        mDict[dateStr].Add(e);
                    } else {
                        List<HMEvent> hMEvents = new List<HMEvent>();
                        hMEvents.Add(e);
                        mDict.Add(dateStr, hMEvents);
                    }
                }
                else if (requestCode == CalendarAdapter.EDIT)
                {
                    int index = data.GetIntExtra("index", -1);
                    string originDate = data.GetStringExtra("originDate");
                    if (index >= 0)
                    {
                        if (mDict.ContainsKey(originDate))
                        {
                            mDict[originDate].RemoveAt(index);
                        }
                        if (mDict.ContainsKey(dateStr))
                        {
                            mDict[dateStr].Add(e);
                        }
                        else
                        {
                            List<HMEvent> hMEvents = new List<HMEvent>();
                            hMEvents.Add(e);
                            mDict.Add(dateStr, hMEvents);
                        }
                        if (mAdapterDict.ContainsKey(originDate)) {
                            mAdapterDict[originDate].NotifyDataSetChanged();
                        }
                    }
                }
                initCalendar();
               
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
