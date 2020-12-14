using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Management.Models
{
    public class MenaxhimiKerkesaveViewModel
    {
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

        public List<MenaxhimiKerkesaveViewModel> menaxhimiList { get; set; }
        public virtual ICollection<Kerkesat> Kerkesat { get; set; }
    }
}
