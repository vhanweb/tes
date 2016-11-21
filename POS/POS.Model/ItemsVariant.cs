using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("MST_ITEMS_VARIANT")]
    public class ItemsVariant
    {
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Item ID")]
        public Nullable<int> ItemID { get; set; }

        [Display(Name = "Outlet ID")]
        public Nullable<int> OutletID { get; set; }

        [Display(Name = "VariantName")]
        public string VariantName { get; set; }

        [Display(Name = "SKU")]
        public string SKU { get; set; }

        [Display(Name = "Price")]
        public Nullable<decimal> Price { get; set; }

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
