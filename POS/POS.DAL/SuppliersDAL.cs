using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    public class SuppliersDAL
    {
        public static List<Suppliers> GetData()
        {
            List<Suppliers> result = new List<Suppliers>();
            using (POSContext context = new POSContext())
            {
                result = context.TSuppliers.ToList();
            }
            return result;
        }

        public static SuppliersViewModel GetDataByID(int id)
        {
            SuppliersViewModel result = new SuppliersViewModel();
            using (POSContext context = new POSContext())
            {
                result = (from po in context.TPurchaseOrder
                          join a in context.TSuppliers on po.SupplierID equals a.ID
                          join p in context.TProvince on a.ProvinceID equals p.ID
                          join r in context.TRegion on a.RegionID equals r.ID
                          join d in context.TDistrict on a.DistrictID equals d.ID
                          select new SuppliersViewModel()
                          {
                              ID = a.ID,
                              Address = a.Address,
                              DistrictID = a.DistrictID,
                              DistrictName = d.DistrictName,
                              RegionID = a.RegionID,
                              RegionName = r.RegionName,
                              Email = a.Email,
                              ProvinceID = a.ProvinceID,
                              ProvinceName = p.ProvinceName,
                              Name = a.Name,
                              Phone = a.Phone,
                              PostalCode = a.PostalCode,
                              CreatedBy = a.CreatedBy,
                              CreatedOn = a.CreatedOn,
                              ModifiedBy = a.ModifiedBy,
                              ModifiedOn = a.ModifiedOn
                          }).FirstOrDefault();
            }
            return result;
        }
    }
}
