using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class TransferViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "HeaderID")] //untuk ke Transfer Stock, menampilkan from outlet, to outlet, note 
        public Nullable<int> HeaderID { get; set; }

        [Display(Name = "From Outlet")]
        public Nullable<int> FromOutlet { get; set; }

        [Display(Name = "To Outlet")]
        public Nullable<int> ToOutlet { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy { get; set; }

        [Display(Name = "CreatedOn")]
        public Nullable<DateTime> CreatedOn { get; set; }

        [Display(Name = "ModifiedBy")]
        public Nullable<int> ModifiedBy { get; set; }

        [Display(Name = "ModifiedOn")]
        public Nullable<DateTime> ModifiedOn { get; set; }

        public List<TransferDetailViewModel> TransferDetail { get; set; }
        public List<int> VariantID { get; set; }

        [Display(Name = "SKU")]
        public string SKU { get; set; }
        [Display(Name = "Quantity")]
        public Nullable<int> Quantity { get; set; }
        [Display(Name = "VariantName")]
        public string VariantName { get; set; }
        [Display(Name = "InStock")]
        public Nullable<int> InStock { get; set; }
        [Display(Name = "Transfer")]
        public Nullable<int> Transfer { get; set; }
    }
}
