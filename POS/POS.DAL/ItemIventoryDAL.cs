using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    public class ItemIventoryDAL
    {
        public static List<ItemIventoryViewModel> GetData()
        {
            List<ItemIventoryViewModel> result = new List<ItemIventoryViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from ii in context.TItemsIventory
                          join iv in context.TItemsVariant on ii.VariantID equals iv.ID
                          select new ItemIventoryViewModel()
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

        public static List<ItemIventoryViewModel> GetDataBySearch(string searchKey)
        {
            List<ItemIventoryViewModel> result = new List<ItemIventoryViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from ii in context.TItemsIventory
                          join iv in context.TItemsVariant on ii.VariantID equals iv.ID
                          where  iv.VariantName.Contains(searchKey)
                          select new ItemIventoryViewModel()
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

        public static List<ItemIventoryViewModel> GetDataSum()
        {
            List<ItemIventoryViewModel> result = new List<ItemIventoryViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from ii in context.TItemsIventory
                          join iv in context.TItemsVariant on ii.VariantID equals iv.ID
                          join i in context.TItems on iv.ItemID equals i.ID
                          join c in context.TCategories on i.CategoryID equals c.ID
                          select new ItemIventoryViewModel()
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
                              CreatedOn = ii.CreatedOn,
                              ItemVarName = i.Name + " - " + iv.VariantName,
                              Name = c.Name
                          }).ToList();
            }
            return result;
        }
    }
}
