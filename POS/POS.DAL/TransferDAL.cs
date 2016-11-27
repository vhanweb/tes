using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.Model;

namespace POS.DAL
{
    public class TransferDAL
    {
        public static List<TransferViewModel> GetData()  //getdata dari transferstock model
        {
            List<TransferViewModel> result = new List<TransferViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from ts in context.TTransferStock
                          join tsd in context.TTransferStockDetail on ts.ID equals tsd.HeaderID
                          join iv in context.TItemsVariant on tsd.VariantID equals iv.ID
                          join ii in context.TItemsIventory on tsd.ID equals ii.VariantID
                          select new TransferViewModel()
                            {
                                ID = ts.ID,
                                ToOutlet = ts.ToOutlet,
                                Note = ts.Note,
                                HeaderID = ts.ID,
                                //InStock = ii.Beginning,
                                //Quantity = ii.Transfer,
                                VariantName = iv.VariantName,
                                //SKU = iv.SKU,
                            }).ToList();
            }

            return result;
        }

        //untuk search items
        public static List<TransferViewModel> GetDataSearch(string SearchKey)
        {
            List<TransferViewModel> result = new List<TransferViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from ts in context.TTransferStock
                          join tsd in context.TTransferStockDetail on ts.ID equals tsd.HeaderID
                          join iv in context.TItemsVariant on tsd.VariantID equals iv.ID
                          join ii in context.TItemsIventory on iv.ID equals ii.VariantID
                          where iv.VariantName.Contains(SearchKey) || iv.SKU.Contains(SearchKey)
                          select new TransferViewModel()
                          {
                              ID = iv.ID,
                              FromOutlet = ts.FromOutlet,
                              ToOutlet = ts.ToOutlet,
                              Note = ts.Note,
                              HeaderID = ts.ID,
                              //InStock = ii.Beginning,
                              //Quantity = ii.Transfer,
                              VariantName = iv.VariantName,
                              //SKU = iv.SKU,

                          }).OrderBy(iv => iv.VariantName).Take(10).ToList(); //.OrderBy(iv => iv.VariantName) ==>>> ditempakan sebelum take
            }
            return result;
        }
    }
}
