using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pmsManager.Models
{
    public class Pms
    {
        public int pmsId { get; set; }
        public string pmsName { get; set; }
        public int numberOfManagers { get; set; }
        public virtual ICollection<ImpExpAssociated> formats { get; set; } 
    }
}