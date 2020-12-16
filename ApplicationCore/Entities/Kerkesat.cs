using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class Kerkesat
    {
        public Kerkesat()
        {
            Veprimet = new HashSet<Veprimet>();
        }

        public int KerkesaAnkesaId { get; set; }
        public string UserId { get; set; }
        public int? LlojiKerkeses { get; set; }
        public int? DepartamentiId { get; set; }
        public string Nenshkrimi { get; set; }
        public string PershkrimiIkerkeses { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsAnonim { get; set; }
        public int? AnonimId { get; set; }
        public string InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public string Lub { get; set; }
        public DateTime? Lud { get; set; }
        public string Lun { get; set; }
        public bool? Ankes { get; set; }
        public bool? Pranuar { get; set; }

        public virtual TblLlojetDepartamenteve Departamenti { get; set; }
        public virtual TblMenaxhimiKerkesave LlojiKerkesesNavigation { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Veprimet> Veprimet { get; set; }
    }
}
