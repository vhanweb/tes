using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    public class ItemsDAL
    {
        public static List<ItemsViewModel> GetData(int outletid)
        {
            List<ItemsViewModel> result = new List<ItemsViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from x in context.TItems
                          join y in context.TItemsVariant on x.ID equals y.ItemID
                          where y.OutletID == outletid
                          select new ItemsViewModel()
                          {
                              ID = x.ID,
                              Name = x.Name,
                              VariantName = y.VariantName,
                              VariantID  = y.ID,
                              Price = y.Price,
                              CreatedBy = x.CreatedBy,
                              CreatedOn = x.CreatedOn,
                              ModifiedBy = x.ModifiedBy,
                              ModifiedOn = x.ModifiedOn,
                          }).ToList();
            }
            return result;
        }

        public static ListItemViewModel GetDataById(int Id)
        {
            ListItemViewModel result = new ListItemViewModel();
            using (POSContext context = new POSContext())
            {
                result = (from i in context.TItems
                          join c in context.TCategories on i.CategoryID equals c.ID
                          where i.ID == Id
                          select new ListItemViewModel()
                          {
                              ID = i.ID,
                              Name = i.Name,
                              CategoryId = i.CategoryID,
                              CategoryName = c.Name,

                          }).FirstOrDefault();

                List<ItemsVariantViewModel> variant = new List<ItemsVariantViewModel>();
                variant = (from iv in context.TItemsVariant
                           where iv.ItemID == Id
                           select new ItemsVariantViewModel()
                           {
                               ID = Id,
                               VariantName = iv.VariantName,
                               SKU = iv.SKU,
                               Price = iv.Price
                           }).ToList();
                result.ListVariant = variant;

                List<ItemsIventoryViewModel> inventory = new List<ItemsIventoryViewModel>();
                inventory = (from ii in context.TItemsIventory
                             join iv in context.TItemsVariant on ii.VariantID equals iv.ID
                             where iv.ItemID == Id
                             select new ItemsIventoryViewModel()
                             {
                                 ID = ii.ID,
                                 VariantID = ii.VariantID,
                                 Beginning = ii.Beginning,
                                 VariantName = iv.VariantName,
                                 AlertAt = ii.AlertAt
                             }).ToList();
                result.ListInventory = inventory;
            }
            return result;
        }
        public static List<ItemsViewModel> GetDataByCategoryID(int catID)
        {
            List<ItemsViewModel> result = new List<ItemsViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from i in context.TItems
                          join c in context.TCategories on i.CategoryID equals c.ID
                          where i.CategoryID == catID
                          select new ItemsViewModel
                          {
                              ItemID = i.ID,
                              Name = i.Name,
                              CategoryID = c.ID,
                              CategoryName = c.Name
                          }).ToList();
            }
            return result;
        }
        public static List<ItemsViewModel> GetDataByInventoryID(int invID)
        {
            List<ItemsViewModel> result = new List<ItemsViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from i in context.TItems
                          join c in context.TCategories on i.CategoryID equals c.ID
                          where i.CategoryID == invID
                          select new ItemsViewModel
                          {
                              ItemID = i.ID,
                              Name = i.Name,
                              CategoryID = c.ID,
                              CategoryName = c.Name
                          }).ToList();
            }
            return result;
        }

        public static List<ItemsViewModel> GetDataSearch(string searchKey, int outletid)
        {
            List<ItemsViewModel> result = new List<ItemsViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from x in context.TItems
                          join y in context.TItemsVariant on x.ID equals y.ItemID
                          where x.Name.Contains(searchKey) && y.OutletID == outletid || y.VariantName.Contains(searchKey) && y.OutletID == outletid
                          select new ItemsViewModel()
                          {
                              ID = x.ID,
                              Name = x.Name,
                              VariantName = y.VariantName,
                              VariantID = y.ID,
                              Price = y.Price,
                              CreatedBy = x.CreatedBy,
                              CreatedOn = x.CreatedOn,
                              ModifiedBy = x.ModifiedBy,
                              ModifiedOn = x.ModifiedOn,
                          }).OrderBy(x => x.Name).Take(10).ToList();
            }
            return result;
        }
    }
}
