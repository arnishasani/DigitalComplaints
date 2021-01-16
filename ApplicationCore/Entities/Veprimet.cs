using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class Veprimet
    {
        public Veprimet()
        {
            VendimiPerfundimtar = new HashSet<VendimiPerfundimtar>();
        }

        public int VeprimiId { get; set; }
        public int? KerkesaId { get; set; }
        public string StafId { get; set; }
        public bool? Pranimi { get; set; }
        public bool? Verifikimi { get; set; }
        public bool? Miratimi { get; set; }
        public bool? Vendimi { get; set; }
        public string Grupi { get; set; }
        public string Orari { get; set; }
        public string LendetEmbetura { get; set; }
        public string LendetEpranuara { get; set; }
        public string VitiAkademik { get; set; }
        public string RefuzimiTotalPerLende { get; set; }
        public string ObligimetEmbetura { get; set; }
        public string LendetErefuzuara { get; set; }
        public string PagesatEperfunduara { get; set; }
        public string InsertBy { get; set; }
        public string InsertDate { get; set; }
        public string Lub { get; set; }
        public DateTime? Lud { get; set; }
        public string Lun { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? Perfunduar { get; set; }
        public bool? ZyraCilesis { get; set; }
        public bool? ZyraIt { get; set; }
        public bool? SherbimeStudentore { get; set; }
        public bool? DepShkenca { get; set; }
        public bool? DepEkonomik { get; set; }
        public bool? ZyraFinancave { get; set; }
        public bool? Rektorati { get; set; }
        public bool? Sekretari { get; set; }

        public virtual Kerkesat Kerkesa { get; set; }
        public virtual ICollection<VendimiPerfundimtar> VendimiPerfundimtar { get; set; }
    }
}
