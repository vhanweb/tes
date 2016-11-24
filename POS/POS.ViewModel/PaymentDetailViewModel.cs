using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class PaymentDetailViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "CustomerID")]
        public Nullable<int> CustomerID { get; set; }

        [Display(Name = "HeaderID")]
        public Nullable<int> HeaderID { get; set; }

        [Display(Name = "VariantID")]
        public List<int> VariantID { get; set; }

        [Display(Name = "Quantity")]
        public List<int> Quantity { get; set; }

        [Display(Name = "UnitPrice")]
        public List<decimal> UnitPrice { get; set; }

        [Display(Name = "SubTotal")]
        public List<decimal> SubTotal { get; set; }

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
