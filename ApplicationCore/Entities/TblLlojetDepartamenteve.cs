using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class TblLlojetDepartamenteve
    {
        public TblLlojetDepartamenteve()
        {
            Kerkesat = new HashSet<Kerkesat>();
        }

        public int DepartamentiId { get; set; }
        public string EmriDepartamentit { get; set; }

        public virtual TblDepartamentet Departamenti { get; set; }
        public virtual ICollection<Kerkesat> Kerkesat { get; set; }
    }
}
