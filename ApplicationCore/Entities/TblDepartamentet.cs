using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class TblDepartamentet
    {
        public int DepartamentiId { get; set; }
        public int? VeprimetId { get; set; }

        public virtual TblLlojetDepartamenteve Departamenti { get; set; }
        public virtual Veprimet Veprimet { get; set; }
    }
}
