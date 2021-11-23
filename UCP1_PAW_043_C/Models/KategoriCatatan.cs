using System;
using System.Collections.Generic;

namespace UCP1_PAW_043_C.Models
{
    public partial class KategoriCatatan
    {
        public KategoriCatatan()
        {
            Catatan = new HashSet<Catatan>();
        }

        public int IdKategori { get; set; }
        public string NamaKategori { get; set; }

        public virtual ICollection<Catatan> Catatan { get; set; }
    }
}
