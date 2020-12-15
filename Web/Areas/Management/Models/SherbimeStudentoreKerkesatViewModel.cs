using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Management.Models
{
    public class SherbimeStudentoreKerkesatViewModel
    {
        public int KerkesaAnkesaId { get; set; }
        public string UserId { get; set; }
        public string LlojiKerkeses { get; set; }
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
        public List<SherbimeStudentoreKerkesatViewModel> sherbimeStudentoreKerkesaList {get;set;}
        public List<SherbimeStudentoreKerkesatViewModel> sherbimeStudentoreAnkesaList {get;set;}
        public List<SherbimeStudentoreKerkesatViewModel> sherbimeStudentoreAnkesatAnonimeList {get;set;}
        public string Departamenti { get; set; }
        //public virtual TblLlojetDepartamenteve Departamenti { get; set; }
        //public virtual TblMenaxhimiKerkesave LlojiKerkesesNavigation { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Veprimet> Veprimet { get; set; }
    }
}
