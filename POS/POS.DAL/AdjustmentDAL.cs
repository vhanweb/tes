using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.Model;

namespace POS.DAL
{
    public class AdjustmentDAL
    {
        public static List<AdjustmentViewModel> GetData()
        {
            List<AdjustmentViewModel> result = new List<AdjustmentViewModel>();
            using (POSContext context = new POSContext())
            {

                result = (from a in context.TAdjusmentStock
                          join asd in context.TAdjusmentStockDetail on a.ID equals asd.HeaderID
                          join iv in context.TItemsVariant on asd.VariantID equals iv.ID
                          join ii in context.TItemsIventory on iv.ID equals ii.VariantID
                          select new AdjustmentViewModel()
                          {
                              ID = a.ID,
                              Note = a.Note,
                              HeaderID = asd.HeaderID,
                              OutletID = a.OutletID,
                          }).ToList();
            }
            return result;
        }
    }
}
