using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class EmployeViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Permission")]
        public string Permission { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Role ID")]
        public Nullable<int> RoleID { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

         [Display(Name = "Outlet ID")]
        public Nullable<int> OutletID { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Created By")]
        public Nullable<int> CreatedBy { get; set; }

        [Display(Name = "Created On")]
        public Nullable<DateTime> CreatedOn { get; set; }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy { get; set; }

        [Display(Name = "Modified On")]
        public Nullable<DateTime> ModifiedOn { get; set; }
    }
}
