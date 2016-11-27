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
        public static List<SuppliersViewModel> GetData()
        {
            // proses instansiasi untuk mendefinisikan list baru 
            List<SuppliersViewModel> result = new List<SuppliersViewModel>();
            // selanjutnya adalah proses untuk membuat linq
            using (POSContext context = new POSContext())
            {
                result = (from s in context.TSuppliers
                          join d in context.TDistrict on s.DistrictID equals d.ID into dTmp
                          from d in dTmp.DefaultIfEmpty()
                          join r in context.TRegion on s.RegionID equals r.ID into rTmp
                          from r in rTmp.DefaultIfEmpty()
                          join p in context.TProvince on s.ProvinceID equals p.ID into pTmp
                          from p in pTmp.DefaultIfEmpty()
                          select new SuppliersViewModel()
                          {
                              ID = s.ID,
                              Name = s.Name,
                              Address = s.Address,
                              DistrictID = s.DistrictID,
                              DistrictName = d.DistrictName,
                              RegionID = s.RegionID,
                              RegionName = r.RegionName,
                              ProvinceID = s.ProvinceID,
                              ProvinceName = p.ProvinceName,
                              AddressFull = s.Address + "," + d.DistrictName + "," + r.RegionName + "," + p.ProvinceName + "," + s.PostalCode,
                              Email = s.Email,
                              Phone = s.Phone,
                          }
                          ).OrderByDescending(x => x.Name).ToList();
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

        public static List<SuppliersViewModel> GetSearch(string searchkey)
        {
            List<SuppliersViewModel> result = new List<SuppliersViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from s in context.TSuppliers
                          join d in context.TDistrict on s.DistrictID equals d.ID into dTmp
                          from d in dTmp.DefaultIfEmpty()
                          join r in context.TRegion on s.RegionID equals r.ID into rTmp
                          from r in rTmp.DefaultIfEmpty()
                          join p in context.TProvince on s.ProvinceID equals p.ID into pTmp
                          from p in pTmp.DefaultIfEmpty()
                          where s.Name.Contains(searchkey) || d.DistrictName.Contains(searchkey) || p.ProvinceName.Contains(searchkey) || s.Phone.Contains(searchkey)
                          select new SuppliersViewModel()
                          {
                              ID = s.ID,
                              Name = s.Name,
                              Address = s.Address,
                              DistrictID = s.DistrictID,
                              DistrictName = d.DistrictName,
                              RegionID = s.RegionID,
                              RegionName = r.RegionName,
                              ProvinceID = s.ProvinceID,
                              ProvinceName = p.ProvinceName,
                              AddressFull = s.Address + "," + d.DistrictName + "," + r.RegionName + "," + p.ProvinceName + "," + s.PostalCode,
                              Email = s.Email,
                              Phone = s.Phone,
                          }
                          ).OrderByDescending(x => x.Name).ToList();
            }
            return result;
        }

    }
}
