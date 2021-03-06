﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Management.Models
{
    public class StudentViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime? Birthday { get; set; }
        public string CreateByUserId { get; set; }
        public DateTime? CreateOnDate { get; set; }
        public bool? Gender { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IndexId { get; set; }

        public List<StudentViewModel> student { get; set; }
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<Kerkesat> Kerkesat { get; set; }
    }
}
