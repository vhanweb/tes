using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class PaymentViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "CustomerID")]
        public Nullable<int> CustomerID { get; set; }

        [Display(Name = "HeaderID")]
        public Nullable<int> HeaderID { get; set; }

        [Display(Name = "VariantID")]
        public Nullable<int> VariantID { get; set; }

        [Display(Name = "Quantity")]
        public Nullable<int> Quantity { get; set; }

        [Display(Name = "UnitPrice")]
        public Nullable<decimal> UnitPrice { get; set; }

        [Display(Name = "SubTotal")]
        public Nullable<decimal> SubTotal { get; set; }

        [Display(Name = "EmployeeID")]
        public Nullable<int> EmployeeID { get; set; }

        [Display(Name = "GrandTotal")]
        public Nullable<decimal> GrandTotal { get; set; }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy { get; set; }

        [Display(Name = "CreatedOn")]
        public Nullable<DateTime> CreatedOn { get; set; }

        [Display(Name = "ModifiedBy")]
        public Nullable<int> ModifiedBy { get; set; }

        [Display(Name = "ModifiedOn")]
        public Nullable<DateTime> ModifiedOn { get; set; }
    }
}
