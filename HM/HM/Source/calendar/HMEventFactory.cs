using System;
using System.Collections.Generic;
using Java.Text;
using Java.Util;

namespace HM.Source.calendar
{
    public class HMEventFactory
    {
        public HMEventFactory()
        {
        }

        public static Dictionary<string, List<HMEvent>> produceEvents()
        {

            Dictionary<string, List<HMEvent>> dict = new Dictionary<string, List<HMEvent>>();

            // one day
            List<HMEvent> ea = new List<HMEvent>();
            HMEvent ea1 = new HMEvent
            {
                name = "Pay electricty bill",
                location = "home",
                duraion = "45m",
                occurence = "Every three month",
                desc = "This is a notice"
            };
            Calendar cEa1 = Calendar.GetInstance(new Locale("en_AU"));
            // event 1 2018-10-10 9:00:00
            cEa1.Set(field: Calendar.Second, value: 0);
            cEa1.Set(Calendar.Minute, 0);
            cEa1.Set(Calendar.Hour, 9);
            cEa1.Set(Calendar.AmPm, Calendar.Am);
            cEa1.Set(Calendar.Month, Calendar.October);
            cEa1.Set(Calendar.DayOfMonth, 10);
            cEa1.Set(Calendar.Year, 2018);
            ea1.date = cEa1;
            ea.Add(ea1);
            HMEvent ea2 = new HMEvent
            {
                name = "JD MJ 101 Meeting",
                location = "Cafe Coffe",
                duraion = "1h 30m",
                occurence = "Once",
                desc = "This is a notice"
            };
            Calendar cEa2 = Calendar.GetInstance(new Locale("en_AU"));
            // event 2 2018-10-10 12:30:00
            cEa2.Set(Calendar.Second, 0);
            cEa2.Set(Calendar.Minute, 30);
            cEa2.Set(Calendar.Hour, 12);
            cEa2.Set(Calendar.AmPm, Calendar.Am);
            cEa2.Set(Calendar.Month, Calendar.October);
            cEa2.Set(Calendar.DayOfMonth, 10);
            cEa2.Set(Calendar.Year, 2018);
            ea2.date = cEa2;
            ea.Add(ea2);

            // Another day
            List<HMEvent> eb = new List<HMEvent>();
            HMEvent eb1 = new HMEvent
            {
                name = "Painting company comming",
                location = "home",
                duraion = "15m",
                occurence = "Once",
                desc = "This is a notice"
            };
            Calendar cEb1 = Calendar.GetInstance(new Locale("en_AU"));
            // 2018-10-10 9:00:00
            cEb1.Set(Calendar.Second, 0);
            cEb1.Set(Calendar.Minute, 0);
            cEb1.Set(Calendar.Hour, 9);
            cEb1.Set(Calendar.AmPm, Calendar.Am);
            cEb1.Set(Calendar.Month, Calendar.October);
            cEb1.Set(Calendar.DayOfMonth, 13);
            cEb1.Set(Calendar.Year, 2018);
            eb1.date = cEb1;
            eb.Add(eb1);

            //1
            List<HMEvent> ec = new List<HMEvent>();
            HMEvent ec1 = new HMEvent
            {
                name = "Pay rent",
                location = "home",
                duraion = "15m",
                occurence = "Every two weeks",
                desc = "This is a notice"
            };
            Calendar cEc1 = Calendar.GetInstance(new Locale("en_AU"));
            // 2018-10-28 9:00:00
            cEc1.Set(Calendar.Second, 0);
            cEc1.Set(Calendar.Minute, 0);
            cEc1.Set(Calendar.Hour, 9);
            cEc1.Set(Calendar.AmPm, Calendar.Am);
            cEc1.Set(Calendar.Month, Calendar.October);
            cEc1.Set(Calendar.DayOfMonth, 28);
            cEc1.Set(Calendar.Year, 2018);
            ec1.date = cEc1;
            ec.Add(ec1);


            //2
            List<HMEvent> ed = new List<HMEvent>();
            HMEvent ed1 = new HMEvent
            {
                name = "Pay rent",
                location = "home",
                duraion = "15m",
                occurence = "Every two weeks",
                desc = "This is a notice"
            };
            Calendar cEd1 = Calendar.GetInstance(new Locale("en_AU"));
            // 2018-10-14 9:00:00
            cEd1.Set(Calendar.Second, 0);
            cEd1.Set(Calendar.Minute, 0);
            cEd1.Set(Calendar.Hour, 9);
            cEd1.Set(Calendar.AmPm, Calendar.Am);
            cEd1.Set(Calendar.Month, Calendar.October);
            cEd1.Set(Calendar.DayOfMonth, 14);
            cEd1.Set(Calendar.Year, 2018);
            ed1.date = cEd1;
            ed.Add(ed1);

            //3
            List<HMEvent> ef = new List<HMEvent>();
            HMEvent ef1 = new HMEvent
            {
                name = "Pay rent",
                location = "home",
                duraion = "15m",
                occurence = "Every two weeks",
                desc = "This is a notice"
            };
            Calendar cEf1 = Calendar.GetInstance(new Locale("en_AU"));
            // 2018-11-11 9:00:00
            cEf1.Set(Calendar.Second, 0);
            cEf1.Set(Calendar.Minute, 0);
            cEf1.Set(Calendar.Hour, 9);
            cEf1.Set(Calendar.AmPm, Calendar.Am);
            cEf1.Set(Calendar.Month, Calendar.November);
            cEf1.Set(Calendar.DayOfMonth, 11);
            cEf1.Set(Calendar.Year, 2018);
            ef1.date = cEf1;
            ef.Add(ef1);


            //4
            List<HMEvent> eg = new List<HMEvent>();
            HMEvent eg1 = new HMEvent
            {
                name = "Pay rent",
                location = "home",
                duraion = "15m",
                occurence = "Every two weeks",
                desc = "This is a notice"
            };
            Calendar cEg1 = Calendar.GetInstance(new Locale("en_AU"));
            // 2018-11-25 9:00:00
            cEg1.Set(Calendar.Second, 0);
            cEg1.Set(Calendar.Minute, 0);
            cEg1.Set(Calendar.Hour, 9);
            cEg1.Set(Calendar.AmPm, Calendar.Am);
            cEg1.Set(Calendar.Month, Calendar.November);
            cEg1.Set(Calendar.DayOfMonth, 25);
            cEg1.Set(Calendar.Year, 2018);
            eg1.date = cEg1;
            eg.Add(eg1);

            //5
            List<HMEvent> eh = new List<HMEvent>();
            HMEvent eh1 = new HMEvent
            {
                name = "Pay rent",
                location = "home",
                duraion = "15m",
                occurence = "Every two weeks",
                desc = "This is a notice"
            };
            Calendar cEh1 = Calendar.GetInstance(new Locale("en_AU"));
            // 2018-12-9 9:00:00
            cEh1.Set(Calendar.Second, 0);
            cEh1.Set(Calendar.Minute, 0);
            cEh1.Set(Calendar.Hour, 9);
            cEh1.Set(Calendar.AmPm, Calendar.Am);
            cEh1.Set(Calendar.Month, Calendar.December);
            cEh1.Set(Calendar.DayOfMonth, 9);
            cEh1.Set(Calendar.Year, 2018);
            eh1.date = cEh1;
            eh.Add(eh1);


            //6
            List<HMEvent> ei = new List<HMEvent>();
            HMEvent ei1 = new HMEvent
            {
                name = "Pay rent",
                location = "home",
                duraion = "15m",
                occurence = "Every two weeks",
                desc = "This is a notice"
            };
            Calendar cEi1 = Calendar.GetInstance(new Locale("en_AU"));
            // 2018-12-23 9:00:00
            cEi1.Set(Calendar.Second, 0);
            cEi1.Set(Calendar.Minute, 0);
            cEi1.Set(Calendar.Hour, 9);
            cEi1.Set(Calendar.AmPm, Calendar.Am);
            cEi1.Set(Calendar.Month, Calendar.December);
            cEi1.Set(Calendar.DayOfMonth, 23);
            cEi1.Set(Calendar.Year, 2018);
            ei1.date = cEg1;
            ei.Add(ei1);


            //7
            List<HMEvent> ee = new List<HMEvent>();
            HMEvent ee1 = new HMEvent
            {
                name = "Pay electricty bill",
                location = "home",
                duraion = "45m",
                occurence = "Every three month",
                desc = "This is a notice"
            };
            Calendar cEe1 = Calendar.GetInstance(new Locale("en_AU"));
            // 2018-12-3 9:00:00
            cEe1.Set(Calendar.Second, 0);
            cEe1.Set(Calendar.Minute, 0);
            cEe1.Set(Calendar.Hour, 9);
            cEe1.Set(Calendar.AmPm, Calendar.Am);
            cEe1.Set(Calendar.Month, Calendar.December);
            cEe1.Set(Calendar.DayOfMonth, 1);
            cEe1.Set(Calendar.Year, 2018);
            ee1.date = cEe1;
            ee.Add(ee1);


            String cEa1str = new SimpleDateFormat("MM-dd-yyyy").Format(cEa1.Time);
            String cEb1str = new SimpleDateFormat("MM-dd-yyyy").Format(cEb1.Time);
            String cEc1str = new SimpleDateFormat("MM-dd-yyyy").Format(cEc1.Time);
            String cEd1str = new SimpleDateFormat("MM-dd-yyyy").Format(cEd1.Time);
            String cEe1str = new SimpleDateFormat("MM-dd-yyyy").Format(cEe1.Time);
            String cEf1str = new SimpleDateFormat("MM-dd-yyyy").Format(cEf1.Time);
            String cEg1str = new SimpleDateFormat("MM-dd-yyyy").Format(cEg1.Time);
            String cEh1str = new SimpleDateFormat("MM-dd-yyyy").Format(cEh1.Time);
            String cEi1str = new SimpleDateFormat("MM-dd-yyyy").Format(cEi1.Time);

            dict.Add(cEa1str, ea);
            dict.Add(cEb1str, eb);
            dict.Add(cEc1str, ec);
            dict.Add(cEd1str, ed);
            dict.Add(cEe1str, ee);
            dict.Add(cEf1str, ef);
            dict.Add(cEg1str, eg);
            dict.Add(cEh1str, eh);
            dict.Add(cEi1str, ei);

            return dict;
        }
    }
}
