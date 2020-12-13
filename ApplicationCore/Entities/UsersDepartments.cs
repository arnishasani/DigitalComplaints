using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class UsersDepartments
    {
        public string UserId { get; set; }
        public int DepartamentiId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
