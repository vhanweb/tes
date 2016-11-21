using POS.Model;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL
{
    //public class DistrictDAL
    //{
    //    public static List<DistrictViewModel> GetData()
    //    {
    //        List<DistrictViewModel> result = new List<DistrictViewModel>();
    //        using (POSContext context = new POSContext())
    //        {
    //            result = (from d in context.TDistrict
    //                      join r in context.TRegion on d.RegionID equals r.ID
    //                      join p in context.TProvince on r.ProvinceID equals p.ID
    //                      select new DistrictViewModel
    //                      {
    //                          ID = r.ID,
    //                          DistrictName=d.DistrictName,
    //                          RegionID=d.RegionID,
    //                          RegionName = r.RegionName,
    //                          ProvinceID = r.ProvinceID, // karena ini nanti mau di drop down list jadi harus di sesuaikan dengan data provinsi yang dipilih di kota
    //                          ProvinceName = p.ProvinceName,
    //                      }).ToList();
    //        }
    //        return result;
    //    }
    //    public static List<DistrictViewModel> GetDataByRegionId(int RId)
    //    {
    //        List<DistrictViewModel> result = new List<DistrictViewModel>();
    //        using (POSContext context = new POSContext())
    //        {
    //            result = (from d in context.TDistrict
    //                      join r in context.TRegion on d.RegionID equals r.ID
    //                      join p in context.TProvince on r.ProvinceID equals p.ID
    //                      where d.RegionID==RId
    //                      select new DistrictViewModel
    //                      {
    //                          ID = r.ID,
    //                          DistrictName = d.DistrictName,
    //                          RegionID = d.RegionID,
    //                          RegionName = r.RegionName,
    //                          ProvinceID = r.ProvinceID, // karena ini nanti mau di drop down list jadi harus di sesuaikan dengan data provinsi yang dipilih di kota
    //                          ProvinceName = p.ProvinceName,
    //                      }).ToList();
    //        }
    //        return result;
    //    }
    //}
}
