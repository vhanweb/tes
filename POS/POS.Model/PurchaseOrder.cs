using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("TRX_PURCHASE_ORDER")]
    public class PurchaseOrder
    {

        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "OutletID")]
        public Nullable<int> OutletID { get; set; }

        [Display(Name = "SupplierID")]
        public Nullable<int> SupplierID { get; set; }

        [Display(Name = "OrderNo")]
        public string OrderNo { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "StatusID")]
        public Nullable<int> StatusID { get; set; }

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
