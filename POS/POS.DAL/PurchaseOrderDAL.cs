using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    public class PurchaseOrderDAL
    {
        public static List<PurchaseOrderViewModel> GetData()
        {
            List<PurchaseOrderViewModel> result = new List<PurchaseOrderViewModel>();
            using (POSContext context = new POSContext())
            {
                //result = context.TPurchaseOrder.ToList();
                result = (from op in context.TPurchaseOrder
                          join sp in context.TSuppliers on op.SupplierID equals sp.ID
                          join oph in context.TPurchaseOrderHistory on op.ID equals oph.HeaderID
                          join ops in context.TPurchaseOrderStatus on oph.StatusID equals ops.ID
                          join opd in context.TPurchaseOrderDetail on op.ID equals opd.HeaderID
                          select new PurchaseOrderViewModel()
                          {
                              ID = oph.ID,
                              StatusID = oph.StatusID,
                              SupplierID = op.SupplierID,
                              StatusName = ops.StatusName,
                              OrderNo = op.OrderNo,
                              Supplier = sp.Name,
                              SubTotal = opd.SubTotal,
                              CreatedBy = op.CreatedBy,
                              CreatedOn = op.CreatedOn,
                              ModifiedBy = op.ModifiedBy,
                              ModifiedOn = op.ModifiedOn
                          }).ToList();
            }
            return result;
        }

        public static List<PurchaseOrderViewModel> GetDataByOutlet(int outletid)
        {
            List<PurchaseOrderViewModel> result = new List<PurchaseOrderViewModel>();
            using (POSContext context = new POSContext())
            {
                //result = context.TPurchaseOrder.ToList();
                result = (from op in context.TPurchaseOrder
                          join sp in context.TSuppliers on op.SupplierID equals sp.ID
                          join oph in context.TPurchaseOrderHistory on op.ID equals oph.HeaderID
                          join ops in context.TPurchaseOrderStatus on oph.StatusID equals ops.ID
                          join opd in context.TPurchaseOrderDetail on op.ID equals opd.HeaderID
                          join ot in context.TOutlet on op.OutletID equals ot.ID
                          where op.OutletID == outletid
                          select new PurchaseOrderViewModel()
                          {
                              ID = oph.ID,
                              OutletID = op.OutletID,
                              OutletName = ot.OutletName,
                              StatusID = oph.StatusID,
                              SupplierID = op.SupplierID,
                              StatusName = ops.StatusName,
                              OrderNo = op.OrderNo,
                              Notes = op.Notes,
                              Supplier = sp.Name,
                              SubTotal = opd.SubTotal,
                              CreatedBy = op.CreatedBy,
                              CreatedOn = op.CreatedOn,
                              ModifiedBy = op.ModifiedBy,
                              ModifiedOn = op.ModifiedOn
                          }).ToList();
            }
            return result;
        }

    }
}
