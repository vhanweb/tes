using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.Model;

namespace POS.DAL
{
    public class AdjusmentDetailDAL
    {
        public static List<AdjustmentDetailViewModel> GetData()
        {
            List<AdjustmentDetailViewModel> result = new List<AdjustmentDetailViewModel>();
            using (POSContext context = new POSContext())
            {

                result = (from asd in context.TAdjusmentStockDetail
                          join a in context.TAdjusmentStock on asd.HeaderID equals a.ID
                          join iv in context.TItemsVariant on asd.VariantID equals iv.ID
                          select new AdjustmentDetailViewModel()
                           {
                               ID = asd.ID,
                               InStock = asd.InStock,
                               ActualStock=asd.ActualStock,
                               CreatedBy=asd.CreatedBy,
                               CreatedOn=asd.CreatedOn,
                               HeaderID=a.ID,
                               ModifiedBy=asd.ModifiedBy,
                               ModifiedOn=asd.ModifiedOn,
                               VariantID=iv.ID,
                           }).ToList();
            }
            return result;
        }
    }
}
