using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class TblMenaxhimiKerkesave
    {
        public TblMenaxhimiKerkesave()
        {
            Kerkesat = new HashSet<Kerkesat>();
        }

        public int MenaxhimiId { get; set; }
        public string LlojiIkerkeses { get; set; }
        public string PershkrimiKerkeses { get; set; }
        public string InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public string Lub { get; set; }
        public DateTime? Lud { get; set; }
        public string Lun { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Kerkesat> Kerkesat { get; set; }
    }
}
