using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using System.ComponentModel.DataAnnotations;

namespace POS.ViewModel
{
    public class PurchaseOrderViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "SupplierID")]
        public Nullable<int> SupplierID { get; set; }

        [Display(Name = "Supplier")]
        public string Supplier { get; set; }

        [Display(Name = "Sub Total")]
        public Nullable<decimal> SubTotal { get; set; }

        [Display(Name = "OrderNo")]
        public string OrderNo { get; set; }

        [Display(Name = "StatusID")]
        public Nullable<int> StatusID { get; set; }

        [Display(Name = "Status Name")]
        public string StatusName { get; set; }

        [Display(Name = "OutletID")]
        public Nullable<int> OutletID { get; set; }

        [Display(Name = "Outlet Name")]
        public string OutletName { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "HeaderID")]
        public Nullable<int> HeaderID { get; set; }

        [Display(Name = "VariantID")]
        public List<int> VariantID { get; set; }

        [Display(Name = "Varian Name")]
        public string VarianName { get; set; }

        [Display(Name = "In Stok")]
        public Nullable<int> InStok { get; set; }

        [Display(Name = "Quantity")]
        public Nullable<int> Quantity { get; set; }

        [Display(Name = "Unit Cost")]
        public Nullable<decimal> UnitCost { get; set; }

        [Display(Name = "Total")]
        public Nullable<decimal> Total { get; set; }

        public string fullname { get; set; }

        public string email { get; set; }

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
