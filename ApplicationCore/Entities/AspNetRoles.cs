﻿using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaims>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            MenaxhimiKerkesaveRolet = new HashSet<MenaxhimiKerkesaveRolet>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<MenaxhimiKerkesaveRolet> MenaxhimiKerkesaveRolet { get; set; }
    }
}
