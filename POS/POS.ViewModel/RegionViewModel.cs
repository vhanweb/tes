using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class RegionViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Province ID")]
        public Nullable<int> ProvinceID { get; set; }

        [Display(Name = "Province Name")]
        public string ProvinceName { get; set; }

        [Display(Name = "Region Name")]
        public string RegionName { get; set; }

    }
}
