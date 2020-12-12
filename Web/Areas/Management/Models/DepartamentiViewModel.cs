using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Management.Models
{
    public class DepartamentiViewModel
    {

        public int DepartamentiId { get; set; }
        public string EmriDepartamentit { get; set; }
        public string InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public string Lub { get; set; }
        public DateTime? Lud { get; set; }
        public string Lun { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual ICollection<Kerkesat> Kerkesat { get; set; }
        public List<DepartamentiViewModel> DepartamentetList { get; set; }
    }
}
