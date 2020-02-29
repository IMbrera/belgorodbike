using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.Services
{
   public class PlaceService
    {
        public IEnumerable<Place> GetPlaces()
        {
            var context = new BBDbContext();
            return context.Places.ToList();
        }
    public IEnumerable<Place> SearchPlaces(string search)
        {
            var context = new BBDbContext();
            var place = context.Places.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                place = place.Where(p => p.Name.ToLower().Contains(search.ToLower()));
            }
            return place.ToList();
        }
    public Place GetPlaceID(int ID)
        {
            var context = new BBDbContext();
            return context.Places.Find(ID);
        }
        public bool SavePlace(Place place)
        {
            var context = new BBDbContext();
            context.Places.Add(place);
            return context.SaveChanges()>0;
        }
        public bool UpdatePlace(Place place)
        {
            var context = new BBDbContext();
            context.Entry(place).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        public bool DeletePlace(Place place)
        {
            var context = new BBDbContext();

            context.Entry(place).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
