using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    public class OutletDAL
    {
        public static List<Outlet> GetData()
        {
            List<Outlet> result = new List<Outlet>();
            using (POSContext context = new POSContext())
            {
                result = context.TOutlet.ToList();
            }
            return result;
        }

        public static List<Outlet> GetDataBySearchKey(string searchKey)
        {
            List<Outlet> result = new List<Outlet>();
            using (POSContext context = new POSContext())
            {
                result = context.TOutlet.Where(m => m.OutletName.Contains(searchKey))
                    
                    .ToList();
            }
            return result;
        }

        public static List<Outlet> GetDataByUser(int userId)
        {
            List<Outlet> result = new List<Outlet>();
            using (POSContext context = new POSContext())
            {
                result = (from a in context.TOutlet
                          join b in context.TEmployeeOutlet on a.ID equals b.OutletID
                          join c in context.TEmployee on b.EmployeeID equals c.ID
                          join d in context.TUser on c.Email equals d.Email
                          where d.Id == userId
                          select new Outlet()
                          {
                              ID = a.ID,
                              Address = a.Address,
                              RegionID = a.RegionID,
                              ProvinceID = a.ProvinceID,
                              PostalCode = a.PostalCode,
                              Phone = a.Phone,
                              OutletName = a.OutletName,
                              Email = a.Email,
                              DistrictID = a.DistrictID,
                              CreatedBy = a.CreatedBy,
                              CreatedOn = a.CreatedOn,
                              ModifiedBy = a.ModifiedBy,
                              ModifiedOn = a.ModifiedOn
                          }).ToList();
            }
            return result;
        }
    }
}
