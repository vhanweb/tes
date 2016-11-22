using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("MST_USER")]
    public class User
    {
        [Key]
        [Display(Name="ID")]
        public int Id { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Email Confirmed")]
        public Nullable<bool> EmailConfirmed { get; set; }

        [Display(Name = "PasswordHash")]
        public string PasswordHash { get; set; }

        [Display(Name = "Security Stamp")]
        public string SecurityStamp { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Phone Number Confirmed")]
        public Nullable<bool> PhoneNumberConfirmed { get; set; }

        [Display(Name = "Two Factor Enabled")]
        public Nullable<bool> TwoFactorEnabled { get; set; }
        
        public Nullable<DateTime> LockoutEndDateUtc { get; set; }
        
        public Nullable<bool> LockoutEnabled { get; set; }
        
        public int AccessFailedCount { get; set; }
        
        [Display(Name = "Username")]
        public string UserName { get; set; }

    }
}
