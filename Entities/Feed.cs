using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Feed
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime PublicDate { get; set; }

        public int PlaceID { get; set; }
        public virtual Place Place { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
       // public byte logo { get; set; }
       

    }
}
