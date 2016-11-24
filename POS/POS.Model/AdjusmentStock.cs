using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("TRX_ADJUSMENT_STOCK")]
    public class AdjusmentStock
    {
        [Key]
        [Display(Name="ID")]
        public int ID { get; set; }

        [Display(Name = "OutletID")]
        public Nullable<int> OutletID { get; set; }

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
    }
}
