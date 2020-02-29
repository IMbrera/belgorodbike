using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.BelBike.Areas.Dashboard.ViewModel
{
    public class PlaceModel
    {
        public IEnumerable<Place> Places { get; set; }
        public string Search { get; set; }
    }
    public class PlaceActionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Coords { get; set; }
    }
}