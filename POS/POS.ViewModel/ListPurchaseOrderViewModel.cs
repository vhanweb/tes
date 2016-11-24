using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using System.ComponentModel.DataAnnotations;

namespace POS.ViewModel
{
    public class ListPurchaseOrderViewModel
    {
        [Display]
        public int ID { get; set; }
        
        [Display]
        public Nullable<int> SupplierID { get; set; }

        [Display(Name = "OrderNo")]
        public string OrderNo { get; set; }

        [Display(Name = "OutletID")]
        public Nullable<int> OutletID { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy { get; set; }

        [Display(Name = "CreatedOn")]
        public Nullable<DateTime> CreatedOn { get; set; }

        [Display(Name="Created Name")]
        public string CreatedName { get; set; }

        [Display]
        public SuppliersViewModel Supplier { get; set; }

        [Display]
        public List<PurchaseOrderDetailsViewModel> PurchaseOrderDetail { get; set; }

        public PurchaseOrderViewModel PurchaseOrder { get; set; }

        [Display]
        public OutletViewModel Outlet { get; set; }

        public EmployeViewModel Staff { get; set; }
    }
}
