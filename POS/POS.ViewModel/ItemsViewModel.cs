using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class ItemsViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "HeaderID")]
        public Nullable<int> HeaderID { get; set; }

        
        [Display(Name = "CustomerID")]
        public Nullable<int> CustomerID { get; set; }

        [Display(Name = "EmployeeID")]
        public Nullable<int> EmployeeID { get; set; }

        [Display(Name = "VariantID")]
        public Nullable<int> VariantID { get; set; }

        [Display(Name = "VariantName")]
        public string VariantName { get; set; }

        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Items Variant ID")]
        public int ItemsVariantID { get; set; }

        [Display(Name = "Price")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "UnitPrice")]
        public Nullable<decimal> UnitPrice { get; set; }

        [Display(Name = "Quantity")]
        public Nullable<int> Quantity { get; set; }

        [Display(Name = "SubTotal")]
        public Nullable<decimal> SubTotal { get; set; }

        [Display(Name = "SKU")]
        public string SKU { get; set; }

        [Display(Name = "GrandTotal")]
        public Nullable<decimal> GrandTotal { get; set; }

        [Display(Name = "Created By")]
        public Nullable<int> CreatedBy { get; set; }

        [Display(Name = "Created On")]
        public Nullable<DateTime> CreatedOn { get; set; }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy { get; set; }

        [Display(Name = "Modified On")]
        public Nullable<DateTime> ModifiedOn { get; set; }

        [Display(Name = "ItemsIventory ID")]
        public int ItemsIventoryID { get; set; }

        [Display(Name = "Item ID")]
        public Nullable<int> ItemID { get; set; }
        public List<ItemsVariantViewModel> ItemsVariant { get; set; }
        public List<ItemsIventoryViewModel> ItemsInventory { get; set; }

        [Display(Name = "Variant Name List")]
        public List<string> VariantNameList { get; set; }

        public List<string> VariantSKU { get; set; }

        public List<decimal> VariantPrice { get; set; }

        [Display(Name = "In Stock")]
        public List<int> Beginning { get; set; }

        public List<int> AlertAt { get; set; }
  
    }
}
