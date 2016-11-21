using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    class PurchaseOrderDetailsDAL
    {
        public static List<PurchaseOrderDetailsViewModel> GetData()
        {
            List<PurchaseOrderDetailsViewModel> result = new List<PurchaseOrderDetailsViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from pod in context.TPurchaseOrderDetail
                          join ii in context.TItemsIventory on pod.VariantID equals ii.VariantID
                          join iv in context.TItemsVariant on pod.VariantID equals iv.ID
                          select new PurchaseOrderDetailsViewModel
                          {
                              ID = pod.ID,
                              VariantID = pod.VariantID,
                              VarianName = iv.VariantName,
                              InStok = ii.Ending,
                              Quantity = pod.Quantity,
                              HeaderID = pod.HeaderID,
                              UnitCost = pod.UnitCost,
                              SubTotal = pod.SubTotal,
                              CreatedBy =pod.CreatedBy,
                              CreatedOn = pod.CreatedOn,
                              ModifiedBy = pod.ModifiedBy,
                              ModifiedOn = pod.ModifiedOn
                          }).ToList();
            }
            return result;
        }
    }
}
