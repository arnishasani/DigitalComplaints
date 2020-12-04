using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class TblKerkesatAnkesat
    {
        public int KerkesaAnkesaId { get; set; }
        public int? RoliId { get; set; }
        public string Departamenti { get; set; }
        public string Nenshkrimi { get; set; }
        public string PershkrimiIkerkeses { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsAnonim { get; set; }
        public int? AnonimId { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public DateTime? Lud { get; set; }
        public int? Lun { get; set; }
    }
}
