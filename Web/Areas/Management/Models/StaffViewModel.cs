using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Management.Models
{
    public class StaffViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string StaffID { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
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
        public string Roli { get; set; }
        public DateTime? CreateOnDate { get; set; }
        public bool? Gender { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public bool SherbimeStudentore { get; set; }
        public bool DepShkenca { get; set; }
        public bool DepEkonomik { get; set; }
        public bool ZyraFinancave { get; set; }
        public bool Rektorati { get; set; }
        public bool Sekretari { get; set; }
        public bool ZyraCilesise { get; set; }
        public bool ZyraIT { get; set; }
        public string LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<StaffViewModel> Staff { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
}
