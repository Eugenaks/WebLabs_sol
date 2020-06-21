using System;
using System.Collections.Generic;
using System.Text;

namespace WebLabs.DAL.Entities
{
   public class TehnikaGroup
    {
        public int TehnikaGroupId { get; set; }
        public string GroupName { get; set; }
        
        public List<Tehnika> Tehniks { get; set; }
    }
}
