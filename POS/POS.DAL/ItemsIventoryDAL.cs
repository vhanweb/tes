using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    public class ItemsIventoryDAL
    {
        public static List<ItemsIventoryViewModel> GetData()
        {
            List<ItemsIventoryViewModel> result = new List<ItemsIventoryViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from ii in context.TItemsIventory
                          join iv in context.TItemsVariant on ii.VariantID equals iv.ID                          
                          select new ItemsIventoryViewModel()
                          {
                              ID = ii.ID,
                              Adjusment = ii.Adjusment,                              
                              AlertAt = ii.AlertAt,
                              Beginning = ii.Beginning,
                              PurchaseOrder = ii.PurchaseOrder,
                              VariantID = ii.VariantID,
                              VariantName = iv.VariantName,
                              Transfer = ii.Transfer,
                              Ending = ii.Ending,
                              Sales = ii.Sales,
                              ModifiedBy = ii.ModifiedBy,
                              ModifiedOn = ii.ModifiedOn,
                              CreatedBy = ii.CreatedBy,
                              CreatedOn = ii.CreatedOn
                          }).ToList();
            }
            return result;
        }

        public static List<ItemsIventoryViewModel> GetDataBySearch(string searchKey)
        {
            List<ItemsIventoryViewModel> result = new List<ItemsIventoryViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from ii in context.TItemsIventory
                          join iv in context.TItemsVariant on ii.VariantID equals iv.ID
                          where  iv.VariantName.Contains(searchKey)
                          select new ItemsIventoryViewModel()
                          {
                              ID = ii.ID,
                              Adjusment = ii.Adjusment,
                              AlertAt = ii.AlertAt,
                              Beginning = ii.Beginning,
                              PurchaseOrder = ii.PurchaseOrder,
                              VariantID = ii.VariantID,
                              VariantName = iv.VariantName,
                              Transfer = ii.Transfer,
                              Ending = ii.Ending,
                              Sales = ii.Sales,
                              ModifiedBy = ii.ModifiedBy,
                              ModifiedOn = ii.ModifiedOn,
                              CreatedBy = ii.CreatedBy,
                              CreatedOn = ii.CreatedOn
                          }).ToList();
            }
            return result;
        }
    }
}
