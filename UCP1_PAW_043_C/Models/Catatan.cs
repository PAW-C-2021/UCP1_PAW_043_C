using System;
using System.Collections.Generic;

namespace UCP1_PAW_043_C.Models
{
    public partial class Catatan
    {
        public Catatan()
        {
            Laporan = new HashSet<Laporan>();
        }

        public int IdCat { get; set; }
        public DateTime? Tanggal { get; set; }
        public int? IdKategori { get; set; }
        public int? HargaCat { get; set; }
        public string KeteranganCat { get; set; }

        public virtual KategoriCatatan IdKategoriNavigation { get; set; }
        public virtual ICollection<Laporan> Laporan { get; set; }
    }
}
