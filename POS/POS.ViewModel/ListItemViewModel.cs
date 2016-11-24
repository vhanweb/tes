using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class ListItemViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        [Display(Name = "Item ID")]
        public Nullable<int> ItemID { get; set; }
        [Display(Name = "Items Variant ID")]
        public int ItemsVariantID { get; set; }
        public List<ItemsVariantViewModel> ListVariant { get; set; }
        public List<ItemsIventoryViewModel> ListInventory { get; set; }
        public List<int> VariantId { get; set; }
        public List<string> VariantName { get; set; }
        public List<string> VariantSKU { get; set; }
        public List<decimal> VariantPrice { get; set; }

        public List<int> InventoryId { get; set; }

        [Display(Name = "In Stock")]
        public List<int> Beginning { get; set; }
        public List<int> AlertAt { get; set; }

    }
}
