using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class MenaxhimiKerkesaveRolet
    {
        public int LlojiKerkesesId { get; set; }
        public string RoliId { get; set; }
        public int MenaxhimiId { get; set; }

        public virtual TblMenaxhimiKerkesave LlojiKerkeses { get; set; }
        public virtual AspNetRoles Roli { get; set; }
    }
}
