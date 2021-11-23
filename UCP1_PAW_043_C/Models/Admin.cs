using System;
using System.Collections.Generic;

namespace UCP1_PAW_043_C.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Laporan = new HashSet<Laporan>();
        }

        public int IdAdmin { get; set; }
        public string NamaAdmin { get; set; }
        public string PasswordAdmin { get; set; }

        public virtual ICollection<Laporan> Laporan { get; set; }
    }
}
