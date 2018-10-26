using System;
using System.Collections.Generic;

namespace HM
{
    public class MainModel
    {
        public MainModel()
        {
        }

        public List<Category> getAvailableCategories()
        {
            return CategoryFactory.produceAvailableCategories();
        }
    }
}
