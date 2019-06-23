using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pmsManager.Models
{
    public class ImpExpAssociated
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isExport { get; set; }
        public bool isImport { get; set; }
        public int sysFormat { get; set; }
        public int PmsId { get; set; }
    }
}