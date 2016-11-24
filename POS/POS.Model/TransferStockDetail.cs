using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("TRX_TRANSFER_STOCK_DETAIL")]
    public class TransferStockDetail
    {
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "HeaderID")]
        public Nullable<int> HeaderID { get; set; }

        [Display(Name = "InStock")]
        public Nullable<int> InStock { get; set; }

        [Display(Name = "VariantID")]
        public Nullable<int> VariantID { get; set; }

        [Display(Name = "Quantity")]
        public Nullable<int> Quantity { get; set; }

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
