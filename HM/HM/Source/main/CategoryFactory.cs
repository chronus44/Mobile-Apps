using System;
using System.Collections.Generic;

namespace HM
{
    public class CategoryFactory
    {
        public static List<Category> produceAvailableCategories()
        {
            List<Category> categories = new List<Category>();
            Category homePayment = new Category
            {
                title = "Home Payments",
                imgResId = Resource.Mipmap.homepayments,
                key = 0
            };
            categories.Add(homePayment);
            Category repairAndMaint = new Category
            {
                title = "Repair & Maint",
                imgResId = Resource.Mipmap.repair,
                key = 1

            };
            categories.Add(repairAndMaint);
            Category security = new Category
            {
                title = "Home Security",
                imgResId = Resource.Mipmap.security,
                key = 2
            };
            categories.Add(security);
            Category laundry = new Category
            {
                title = "Laundry",
                imgResId = Resource.Mipmap.laundry,
                key = 3
            };
            categories.Add(laundry);
            Category electricity = new Category
            {
                title = "Electricity Service",
                imgResId = Resource.Mipmap.electricity,
                key = 4
            };
            categories.Add(electricity);
            Category gardening = new Category
            {
                title = "Gardening",
                imgResId = Resource.Mipmap.gardening,
                key = 5
            };
            categories.Add(gardening);
            Category cleaning = new Category
            {
                title = "Home Cleaning",
                imgResId = Resource.Mipmap.cleaning,
                key = 6
            };
            categories.Add(cleaning);
            Category eventAndCalendar = new Category
            {
                title = "Event & Calendar",
                imgResId = Resource.Mipmap.calendar,
                key = 7,
            };
            categories.Add(eventAndCalendar);
            Category poolServices = new Category
            {
                title = "Pool Services",
                imgResId = Resource.Mipmap.pool,
                key = 8
            };
            categories.Add(poolServices);
            Category favouriteCo = new Category
            {
                title = "Favourite Co.",
                imgResId = Resource.Mipmap.favourite,
                key = 9
            };
            categories.Add(favouriteCo);
            return categories;
        }
    }
}
