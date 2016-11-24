using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("MST_PAYMENT_OPTION")]
    public class PaymentOption
    {
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

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
