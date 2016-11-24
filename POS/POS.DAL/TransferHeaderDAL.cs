using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.Model;

namespace POS.DAL
{
    public class TransferHeaderDAL
    {
        public static List<TransferViewModel> GetData()
        {
            List<TransferViewModel> result = new List<TransferViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from ts in context.TTransferStock
                          join tsd in context.TTransferStockDetail on ts.ID equals tsd.HeaderID
                          select new TransferViewModel
                          {
                              ID = ts.ID,
                              HeaderID = ts.ID,
                              Note = ts.Note,
                              CreatedBy = tsd.CreatedBy,
                              CreatedOn = tsd.CreatedOn,
                              FromOutlet = ts.FromOutlet,
                              ToOutlet = ts.ToOutlet,
                              ModifiedBy = tsd.ModifiedBy,
                              ModifiedOn = tsd.ModifiedOn,
                             
                          }).ToList();
            }
            return result;
        }
    }
}
