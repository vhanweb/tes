using POS.Model;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL
{
    public class ItemsVariantDAL
    {
        public static List<ItemsVariantViewModel> GetData()
        {
            List<ItemsVariantViewModel> result = new List<ItemsVariantViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from iv in context.TItemsVariant
                          join ii in context.TItemsIventory on iv.ID equals ii.VariantID into iiTmp
                          from ii in iiTmp.DefaultIfEmpty()
                          join i in context.TItems on iv.ItemID equals i.ID into iTmp
                          from i in iTmp.DefaultIfEmpty()
                          join asd in context.TAdjusmentStockDetail on iv.ID equals asd.VariantID into asdTmp
                          from asd in asdTmp.DefaultIfEmpty()
                          join a in context.TAdjusmentStock on asd.HeaderID equals a.ID into aTmp
                          from a in aTmp.DefaultIfEmpty()
                          select new ItemsVariantViewModel()
                          {
                              ID = iv.ID,
                              ItemID = iv.ItemID,
                              VariantName = iv.VariantName,
                              Price = iv.Price,
                              SKU = iv.SKU,
                              CreatedOn = iv.CreatedOn,
                              Note = a.Note
                              //ditambah serta ditukar dari data ana
                          }).ToList();
            }
            return result;
        }

        
    }
}
