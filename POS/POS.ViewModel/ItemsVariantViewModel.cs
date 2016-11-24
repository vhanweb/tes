using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class ItemsVariantViewModel
    {
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

        [Display(Name = "Adjusment")]
        public Nullable<int> Adjusment { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "VariantID")]
        public List<int> VariantID { get; set; }

    }
}
