using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class CategoriesViewModel
    // untuk yang kita pakai di view model itu hanya yang kita perlukan saja
    {
        [Display(Name = "Category ID")]
        public int ID { get; set; }

        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Category Name2")]
        public string Name2 { get; set; }

        [Display(Name = "Item Stock")]
        public int ItemStock { get; set; }
        [Display(Name = "Created By")]
        public Nullable<int> CreatedBy { get; set; }

        [Display(Name = "Created On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> CreatedOn { get; set; }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy { get; set; }

        [Display(Name = "Modified On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> ModifiedOn { get; set; }

        [Display(Name = "ID Item")]
        public List<int> ItemID { get; set; }

        [Display(Name = "Outlet ID")]
        public Nullable<int> OutletID { get; set; }

        [Display(Name = "ID Outlet")]
        public List<int> ListOutletID { get; set; }

        public Nullable<int> a { get; set; }
    }
}

