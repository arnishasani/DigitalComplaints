using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class VendimiPerfundimtar
    {
        public int Id { get; set; }
        public int? VeprimiId { get; set; }
        public string StaffId { get; set; }
        public bool? Vendimi { get; set; }
        public string PershkrimiVendimit { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public string InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? Lud { get; set; }
        public string Lub { get; set; }

        public virtual Veprimet Veprimi { get; set; }
    }
}
