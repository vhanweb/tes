using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class PurchaseOrderDetailsViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "HeaderID")]
        public Nullable<int> HeaderID { get; set; }

        [Display(Name = "VariantID")]
        public Nullable<int> VariantID { get; set; }

        [Display(Name = "Outlet ID")]
        public Nullable<int> OutletID { get; set; }

        [Display(Name = "Varian Name")]
        public string VarianName { get; set; }

        [Display(Name = "In Stok")]
        public Nullable<int> InStok { get; set; }

        [Display(Name = "Quantity")]
        public Nullable<int> Quantity { get; set; }

        [Display(Name = "UnitCost")]
        public Nullable<decimal> UnitCost { get; set; }

        [Display(Name = "SubTotal")]
        public Nullable<decimal> SubTotal { get; set; }

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
