using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Calendar
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOrg { get; set; }
        
        public int PlaceID { get; set; }
        public virtual Place Place { get; set; }
    }
}
