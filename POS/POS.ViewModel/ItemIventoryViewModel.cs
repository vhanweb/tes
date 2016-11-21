using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class ItemIventoryViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Variant ID")]
        public Nullable<int> VariantID { get; set; }

        [Display(Name = "VariantName")]
        public string VariantName { get; set; }

        [Display(Name = "Beginning")]
        public Nullable<int> Beginning { get; set; }

        [Display(Name = "Purchase Order")]
        public Nullable<int> PurchaseOrder { get; set; }

        [Display(Name = "Sales")]
        public Nullable<int> Sales { get; set; }

        [Display(Name = "Transfer")]
        public Nullable<int> Transfer { get; set; }

        [Display(Name = "Adjusment")]
        public Nullable<int> Adjusment { get; set; }

        [Display(Name = "Ending")]
        public Nullable<int> Ending { get; set; }

        [Display(Name = "AlertAt")]
        public Nullable<int> AlertAt { get; set; }

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
