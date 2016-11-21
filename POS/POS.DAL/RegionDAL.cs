using POS.Model;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL
{
    //public class RegionDAL
    //{
    //    public static List<RegionViewModel> GetData()
    //    {
    //        List<RegionViewModel> result = new List<RegionViewModel>();
    //        using (POSContext context = new POSContext())
    //        {
    //            result = (from r in context.TRegion
    //                      join p in context.TProvince on r.ProvinceID equals p.ID
    //                      select new RegionViewModel
    //                      {
    //                          ID = r.ID,
    //                          RegionName=r.RegionName,
    //                          ProvinceID=r.ProvinceID, // karena ini nanti mau di drop down list jadi harus di sesuaikan dengan data provinsi yang dipilih di kota
    //                          ProvinceName = p.ProvinceName,
    //                      }).ToList();
    //        }
    //        return result;
    //    }
    //    public static List<RegionViewModel> GetDataByProvinceId(int PId)
    //    {
    //        List<RegionViewModel> result = new List<RegionViewModel>();
    //        using (POSContext context = new POSContext())
    //        {
    //            result = (from r in context.TRegion
    //                      join p in context.TProvince on r.ProvinceID equals p.ID
    //                      where r.ProvinceID==PId
    //                      select new RegionViewModel
    //                      {
    //                          ID = r.ID,
    //                          RegionName = r.RegionName,
    //                          ProvinceID = r.ProvinceID, // karena ini nanti mau di drop down list jadi harus di sesuaikan dengan data provinsi yang dipilih di kota
    //                          ProvinceName = p.ProvinceName,
    //                      }).ToList();
    //        }
    //        return result;
    //    }
    //}
}
