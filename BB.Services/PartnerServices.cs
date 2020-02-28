using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.Services
{
   public class PartnerServices
    {
        public IEnumerable<Partner> GetPartners()
        {
            var context = new BBDbContext();
            return context.Partners.ToList();
        }


        public IEnumerable<Partner> SearchPartners(string search)
        {
            var context = new BBDbContext();

            var partners = context.Partners.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                partners = partners.Where(a => a.Name.ToLower().Contains(search.ToLower()));
            }

            return partners.ToList();
        }
        public Partner GetPartnerID(int ID)
        {
            var context = new BBDbContext();

            return context.Partners.Find(ID);
        }
        public bool SavePartner(Partner partner)
        {
            var context = new BBDbContext();

            context.Partners.Add(partner);

            return context.SaveChanges() > 0;
        }
        public bool UpdatePartner(Partner partner)
        {
            var context = new BBDbContext();

            context.Entry(partner).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }
        public bool DeletePartner(Partner partner)
        {
            var context = new BBDbContext();

            context.Entry(partner).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
   