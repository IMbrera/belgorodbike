using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BBDbContext : DbContext
    {
        public BBDbContext() :  base("BBConnectionString")
        {
        }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}
