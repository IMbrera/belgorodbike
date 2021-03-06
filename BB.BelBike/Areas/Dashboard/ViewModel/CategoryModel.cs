﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.BelBike.Areas.Dashboard.ViewModel
{
    public class CategoryModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public string Search { get; set; }

    }
    public class ActionCategoryModel 
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}