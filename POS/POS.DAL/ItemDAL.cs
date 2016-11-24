using POS.Model;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL
{
    public class ItemDAL
    {
        public static List<ListItemViewModel> GetData()
        {
            List<ListItemViewModel> result = new List<ListItemViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from i in context.TItems
                          join c in context.TCategories on i.CategoryID equals c.ID
                          select new ListItemViewModel()
                          {
                              ID = i.ID,
                              Name = i.Name,
                              CategoryId = i.CategoryID,
                              CategoryName = c.Name,

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

    }
}
