using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("MST_CUSTOMERS")]
    public class Customers
    {
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Birth Date")]
        public string BirthDate { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Province ID")]
        public Nullable<int> ProvinceID { get; set; }

        [Display(Name = "Region ID")]
        public Nullable<int> RegionID { get; set; }

        [Display(Name = "District ID")]
        public Nullable<int> DistrictID { get; set; }

        [Display(Name = "Created By")]
        public Nullable<int> CreatedBy { get; set; }

        [Display(Name = "Created On")]
        public Nullable<DateTime> CreatedOn { get; set; }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy { get; set; }

        [Display(Name = "Modified On")]
        public Nullable<DateTime> ModifiedOn { get; set; }

        [Display(Name = "Outlet ID")]
        public Nullable<int> OutletID { get; set; }
    }
}
