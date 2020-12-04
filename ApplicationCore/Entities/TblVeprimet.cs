using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class TblVeprimet
    {
        public int? KerkesaId { get; set; }
        public int? MenaxhimiId { get; set; }
        public int VeprimiId { get; set; }
        public bool? Pranimi { get; set; }
        public bool? Verifikimi { get; set; }
        public bool? Miratimi { get; set; }
        public bool? Vendimi { get; set; }
        public string LlojiIkerkeses { get; set; }
        public string Grupi { get; set; }
        public string Orari { get; set; }
        public string LendetEmbetura { get; set; }
        public string LendetEpranuara { get; set; }
        public string VitiAkademik { get; set; }
        public string RefuzimiTotalPerLende { get; set; }
        public string ObligimetEmbetura { get; set; }
        public string LendetErefuzuara { get; set; }
        public string PagesatEperfunduara { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? Lub { get; set; }
        public DateTime? Lud { get; set; }
        public int? Lun { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
