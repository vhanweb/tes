using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.ViewModel;
using POS.Model;
using System.Threading.Tasks;

namespace POS.DAL
{
    public class TransferDetailDAL
    {
        public static List<TransferDetailViewModel> GetData()
        {
            List<TransferDetailViewModel> result = new List<TransferDetailViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from tsd in context.TTransferStockDetail
                          join ts in context.TTransferStock on tsd.HeaderID equals ts.ID
                          join iv in context.TItemsVariant on tsd.VariantID equals iv.ID
                          select new TransferDetailViewModel
                          {
                              ID = tsd.ID,
                              HeaderID = ts.ID,
                              VariantID = iv.ID,
                              CreatedBy = tsd.CreatedBy,
                              CreatedOn = tsd.CreatedOn,
                              InStock = tsd.InStock,
                              ModifiedBy = tsd.ModifiedBy,
                              ModifiedOn = tsd.ModifiedOn,
                              Quantity = tsd.Quantity,
                          }).ToList();
            }
            return result;
        }
    }
}
