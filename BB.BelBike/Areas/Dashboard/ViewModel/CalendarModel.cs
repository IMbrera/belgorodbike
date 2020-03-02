using BB.BelBike.ViewModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.BelBike.Areas.Dashboard.ViewModel
{
    public class CalendarModel
    {
        public int? PlaceID { get; set; }
        public IEnumerable<Place> Places { get; set; }
        public IEnumerable<Calendar> Calendars { get; set; }
        public string Search { get; set; }
        public Pager Pager { get; set; }
    }
    public class CalendarActionModel
    {
        public int ID { get; set; }
        public int PlaceID { get; set; }
        public Place Place { get; set; }
        public string Name { get; set; }
        public DateTime DateOrg { get; set; }  
        public IEnumerable<Place> Places { get; set; }
    }
}