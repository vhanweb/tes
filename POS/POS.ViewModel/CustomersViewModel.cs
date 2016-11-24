using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POS.ViewModel
{
    public class CustomersViewModel
    {

        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Birth Date")]
        public Nullable<DateTime> BirthDate { get; set; }

        [Display(Name = "Birth Day")]
        public string BirthDay { get; set; }

        [Display(Name = "Birth Month")]
        public string BirthMonth { get; set; }

        [Display(Name = "Birth Year")]
        public string BirthYear { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "FullAddress")]
        public string FullAddress { get; set; }

        [Display(Name = "Province ID")]
        public Nullable<int> ProvinceID { get; set; }

        [Display(Name = "Province Name")]
        public string ProvinceName { get; set; }

        [Display(Name = "Region ID")]
        public Nullable<int> RegionID { get; set; }

        [Display(Name = "Region Name")]
        public string RegionName { get; set; }

        [Display(Name = "District ID")]
        public Nullable<int> DistrictID { get; set; }

        [Display(Name = "District Name")]
        public string DistrictName { get; set; }

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
