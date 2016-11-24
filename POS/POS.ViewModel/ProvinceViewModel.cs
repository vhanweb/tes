using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class ProvinceViewModel
    {
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Province Name")]
        public string ProvinceName { get; set; }
    }
}
