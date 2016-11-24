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
        public static List<ItemsViewModel> GetData()
        {
            List<ItemsViewModel> result = new List<ItemsViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from x in context.TItems
                          join y in context.TItemsVariant on x.ID equals y.ItemID
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

        public static ItemsViewModel GetDataById(int iId)
        {
            ItemsViewModel result = new ItemsViewModel();
            using (POSContext context = new POSContext())
            {
                result = (from x in context.TItems
                          join y in context.TItemsVariant on x.ID equals y.ItemID
                          where x.ID == iId
                          select new ItemsViewModel()
                          {
                              ID = x.ID,
                              Name = x.Name,
                              Price = y.Price,
                              CreatedBy = x.CreatedBy,
                              CreatedOn = x.CreatedOn,
                              ModifiedBy = x.ModifiedBy,
                              ModifiedOn = x.ModifiedOn,
                          }).FirstOrDefault();
            }
            return result;
        }

        public static List<ItemsViewModel> GetDataSearch(string searchKey)
        {
            List<ItemsViewModel> result = new List<ItemsViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from x in context.TItems
                          join y in context.TItemsVariant on x.ID equals y.ItemID
                          where x.Name.Contains(searchKey)
                          select new ItemsViewModel()
                          {
                              ID = x.ID,
                              Name = x.Name,
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
