using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class EmployeeOutletViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Employee ID")]
        public Nullable<int> EmployeeID { get; set; }

        [Display(Name = "Outlet ID")]
        public Nullable<int> OutletID { get; set; }

        [Display(Name = "Role ID")]
        public Nullable<int> RoleID { get; set; }

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
