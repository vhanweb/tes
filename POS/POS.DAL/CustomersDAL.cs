using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    public class CustomersDAL
    {
        public static List<CustomersViewModel> GetData()
        {
            List<CustomersViewModel> result = new List<CustomersViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from x in context.TCustomers
                          join p in context.TProvince on x.ProvinceID equals p.ID
                          join r in context.TRegion on x.RegionID equals r.ID
                          join d in context.TDistrict on x.DistrictID equals d.ID
                          select new CustomersViewModel()
                          {
                              ID = x.ID,
                              CustomerName = x.CustomerName,
                              Phone = x.Phone,
                              Email = x.Email,
                              ProvinceID = x.ProvinceID,
                              ProvinceName = p.ProvinceName,
                              RegionID = x.RegionID,
                              RegionName = r.RegionName,
                              DistrictID = x.DistrictID,
                              DistrictName = d.DistrictName,
                              Address = x.Address,
                              FullAddress = x.Address + d.DistrictName + r.RegionName + p.ProvinceName,
                              CreatedBy = x.CreatedBy,
                              CreatedOn = x.CreatedOn,
                              ModifiedBy = x.ModifiedBy,
                              ModifiedOn = x.ModifiedOn,
                              BirthDate = x.BirthDate,

                          }).ToList();
            }
            return result;
        }

        public static CustomersViewModel GetDataById(int iId)
        {
            CustomersViewModel result = new CustomersViewModel();
            using (POSContext context = new POSContext())
            {
                result = (from x in context.TCustomers
                          where x.ID == iId
                          select new CustomersViewModel()
                          {
                              ID = x.ID,
                              CustomerName = x.CustomerName,
                              Phone = x.Phone,
                              Email = x.Email,
                              ProvinceID = x.ProvinceID,
                              RegionID = x.RegionID,
                              DistrictID = x.DistrictID,
                              Address = x.Address,
                              CreatedBy = x.CreatedBy,
                              CreatedOn = x.CreatedOn,
                              ModifiedBy = x.ModifiedBy,
                              ModifiedOn = x.ModifiedOn,
                              BirthDate = x.BirthDate,
                          }).FirstOrDefault();
            }
            return result;
        }

        public static List<CustomersViewModel> GetDataSearch(string searchKey)
        {
            List<CustomersViewModel> result = new List<CustomersViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from x in context.TCustomers
                          where x.CustomerName.Contains(searchKey) || x.Email.Contains(searchKey) || x.Phone.Contains(searchKey)
                          select new CustomersViewModel()
                          {
                              ID = x.ID,
                              CustomerName = x.CustomerName,
                              Phone = x.Phone,
                              Email = x.Email,
                              ProvinceID = x.ProvinceID,
                              RegionID = x.RegionID,
                              DistrictID = x.DistrictID,
                              Address = x.Address,
                              CreatedBy = x.CreatedBy,
                              CreatedOn = x.CreatedOn,
                              ModifiedBy = x.ModifiedBy,
                              ModifiedOn = x.ModifiedOn,
                              BirthDate = x.BirthDate,
                          }).OrderBy(x => x.CustomerName).Take(10).ToList();
            }
            return result;
        }

    }
}
