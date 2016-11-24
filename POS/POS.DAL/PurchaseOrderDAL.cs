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

        public static PurchaseOrderViewModel GetDataedit(int Id)
        {
            PurchaseOrderViewModel result = new PurchaseOrderViewModel();
            using (POSContext context = new POSContext())
            {
                //result = context.TPurchaseOrder.ToList();
                result = (from op in context.TPurchaseOrder
                          join sp in context.TSuppliers on op.SupplierID equals sp.ID
                          join oph in context.TPurchaseOrderHistory on op.ID equals oph.HeaderID
                          join ops in context.TPurchaseOrderStatus on oph.StatusID equals ops.ID
                          join opd in context.TPurchaseOrderDetail on op.ID equals opd.HeaderID
                          where op.ID == Id
                          select new PurchaseOrderViewModel()
                          {
                              ID = op.ID,
                              StatusID = oph.StatusID,
                              SupplierID = op.SupplierID,
                              StatusName = ops.StatusName,
                              OrderNo = op.OrderNo,
                              Total = op.Total,
                              Supplier = sp.Name,
                              SubTotal = opd.SubTotal,
                              CreatedBy = op.CreatedBy,
                              CreatedOn = op.CreatedOn,
                              ModifiedBy = op.ModifiedBy,
                              ModifiedOn = op.ModifiedOn
                          }).FirstOrDefault();
            }
            return result;
        }


        public static ListPurchaseOrderViewModel GetDataByIdPO(int id)
        {
            ListPurchaseOrderViewModel result = new ListPurchaseOrderViewModel();
            using (POSContext context = new POSContext())
            {
                result = (from op in context.TPurchaseOrder
                          //join epo in context.TEmployeeOutlet on op.OutletID equals epo.ID
                          //join ep in context.TEmployee on epo.EmployeeID equals ep.ID
                          where op.ID == id
                          select new ListPurchaseOrderViewModel()
                          {
                              ID = op.ID,
                              SupplierID = op.SupplierID,
                              Notes = op.Notes,
                              OrderNo = op.OrderNo,
                              OutletID = op.OutletID,
                              CreatedBy = op.CreatedBy,
                              CreatedOn = op.CreatedOn,
                              //CreatedName = ep.FirstName + " " + ep.LastName
                          }).FirstOrDefault();

                PurchaseOrderViewModel employee = new PurchaseOrderViewModel();
                employee = (from op in context.TPurchaseOrder
                            join epo in context.TEmployeeOutlet on op.OutletID equals epo.ID
                            join ep in context.TEmployee on epo.EmployeeID equals ep.ID
                            where op.ID == id
                            select new PurchaseOrderViewModel()
                            {
                                fullname = ep.FirstName + ep.LastName,
                                email = ep.Email
                            }).FirstOrDefault();
                result.PurchaseOrder = employee;

                SuppliersViewModel supplier = new SuppliersViewModel();

                supplier = (from op in context.TPurchaseOrder
                            join sp in context.TSuppliers on op.SupplierID equals sp.ID
                            join p in context.TProvince on sp.ProvinceID equals p.ID
                            join r in context.TRegion on sp.RegionID equals r.ID
                            join d in context.TDistrict on sp.DistrictID equals d.ID
                            where op.ID == id
                            select new SuppliersViewModel()
                            {
                                ID = sp.ID,
                                Address = sp.Address,
                                RegionName = r.RegionName,
                                RegionID = sp.RegionID,
                                ProvinceName = p.ProvinceName,
                                ProvinceID = sp.ProvinceID,
                                Phone = sp.Phone,
                                PostalCode = sp.PostalCode,
                                DistrictName = d.DistrictName,
                                DistrictID = sp.DistrictID,
                                Email = sp.Email,
                                Name = sp.Name
                            }).FirstOrDefault();
                result.Supplier = supplier;

                OutletViewModel outlet = new OutletViewModel();

                outlet = (from op in context.TPurchaseOrder
                          join ot in context.TOutlet on op.OutletID equals ot.ID
                          join p in context.TProvince on ot.ProvinceID equals p.ID
                          join r in context.TRegion on ot.RegionID equals r.ID
                          where op.ID == id
                          select new OutletViewModel()
                          {
                              ID = ot.ID,
                              OutletName = ot.OutletName,
                              Phone = ot.Phone,
                              FullAddress = ot.Address + ", " + p.ProvinceName + ", " + r.RegionName + ", " + ot.PostalCode
                          }).FirstOrDefault();
                result.Outlet = outlet;

                List<PurchaseOrderDetailsViewModel> purchaseorderdetail = new List<PurchaseOrderDetailsViewModel>();

                purchaseorderdetail = (from pod in context.TPurchaseOrderDetail
                                       join ii in context.TItemsIventory on pod.VariantID equals ii.VariantID
                                       join iv in context.TItemsVariant on pod.VariantID equals iv.ID
                                       where pod.HeaderID == id
                                       select new PurchaseOrderDetailsViewModel
                                       {
                                           ID = pod.ID,
                                           VariantID = pod.VariantID,
                                           VarianName = iv.VariantName,
                                           InStok = ii.Ending,
                                           Quantity = pod.Quantity,
                                           HeaderID = pod.HeaderID,
                                           UnitCost = pod.UnitCost,
                                           SubTotal = pod.SubTotal,
                                           CreatedBy = pod.CreatedBy,
                                           CreatedOn = pod.CreatedOn,
                                           ModifiedBy = pod.ModifiedBy,
                                           ModifiedOn = pod.ModifiedOn
                                       }).ToList();
                result.PurchaseOrderDetail = purchaseorderdetail;

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

        public static string OrderNo()
        {
            string OrderNo;
            int index = 1;
            OrderNo = "#" + string.Format("{0:00}", DateTime.Now.Month) + string.Format("{0:00}", DateTime.Now.Day);
            using (POSContext context = new POSContext())
            {
                var result = context.TPurchaseOrder
                    .Where(m => m.OrderNo.Contains(OrderNo))
                    .OrderByDescending(x => x.OrderNo)
                    .FirstOrDefault();
                if (result == null)
                {
                    OrderNo = OrderNo + string.Format("{0:00000}", index);
                }
                else
                {
                    string[] OrNo = result.OrderNo.Split('#');
                    index = int.Parse(OrNo[1]) + 1;
                    OrderNo = "#" + index.ToString();
                }
            }
            return OrderNo;
        }

    }
}
