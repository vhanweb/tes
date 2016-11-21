using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    //public class ProvinceDAL
    //{
    //    // membuat list province yang disesuaikan dengan view model dan model
    //    public static List<ProvinceViewModel> GetData()
    //    {
    //        List<ProvinceViewModel> result = new List<ProvinceViewModel>();
    //        using (POSContext context = new POSContext())
    //        {
    //            result = (from p in context.TProvince
    //                      select new ProvinceViewModel
    //                      {
    //                          ID = p.ID,
    //                          ProvinceName=p.ProvinceName,
    //                      }).ToList();
    //        }
    //        return result;
    //    }
    //}
}
