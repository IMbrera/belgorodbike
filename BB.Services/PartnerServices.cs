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

        public bool SavePartner(Partner partner)
        {
            var context = new BBDbContext();

            context.Partners.Add(partner);

            return context.SaveChanges() > 0;
        }
    }
}
   