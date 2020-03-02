using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.Services
{
   public class CalendarService
    {
        public IEnumerable<Calendar> GetCalendars()
        {
            var context = new BBDbContext();
            return context.Calendars.ToList();
        }
       public IEnumerable<Calendar> SearchCalendar(string search, int? placeID, int page, int recordSize)
        {
            var context = new BBDbContext();
            var calendar = context.Calendars.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                calendar = calendar.Where(a => a.Name.ToLower().Contains(search.ToLower()));
            }
            if (placeID.HasValue && placeID.Value > 0)
            {
                calendar = calendar.Where(a => a.PlaceID == placeID.Value);
            }

            var skip = (page - 1) * recordSize;
            return calendar.OrderBy(c=>c.PlaceID).Skip(skip).Take(recordSize).ToList();
        }

        public int SearchCalendarCount(string searchTerm, int? placeID)
        {
            var context = new BBDbContext();

            var calendar = context.Calendars.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                calendar = calendar.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (placeID.HasValue && placeID.Value > 0)
            {
                calendar = calendar.Where(a => a.PlaceID == placeID.Value);
            }

            return calendar.Count();
        }
        public Calendar GetCalendarID(int ID)
        {
            using (var context = new BBDbContext())
            {
                return context.Calendars.Find(ID);
            }
        }
        public bool SaveCalendar(Calendar calendar)
        {
            var context = new BBDbContext();
            context.Calendars.Add(calendar);
            context.SaveChanges();
            return context.SaveChanges() > 0;
        }
        public bool UpdateCalendar(Calendar calendar)
        {
            var context = new BBDbContext();
            context.Entry(calendar).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        public bool DeleteCalendar(Calendar calendar)
        {
            var context = new BBDbContext();

            context.Entry(calendar).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
