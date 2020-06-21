using System;
using System.Collections.Generic;
using System.Text;

namespace WebLabs.DAL.Entities
{
   public class Tehnika
    {
        public int TehnikaId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Amount { get; set; }
        public string Images { get; set; }
        public int TehnikaGroupId { get; set; }
        public TehnikaGroup Group { get; set; }
    }
}
