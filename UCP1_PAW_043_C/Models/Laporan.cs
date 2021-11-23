using System;
using System.Collections.Generic;

namespace UCP1_PAW_043_C.Models
{
    public partial class Laporan
    {
        public int IdLaporan { get; set; }
        public int? IdAdmin { get; set; }
        public int? IdCat { get; set; }
        public int? TotalPem { get; set; }
        public int? TotalPen { get; set; }

        public virtual Admin IdAdminNavigation { get; set; }
        public virtual Catatan IdCatNavigation { get; set; }
    }
}
