using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    public class EmployeeOutletDAL
    {
        public static List<EmployeeOutletViewModel> GetDataByID(int userId)
        {
            List<EmployeeOutletViewModel> result = new List<EmployeeOutletViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from a in context.TEmployeeOutlet
                          join b in context.TEmployee on a.EmployeeID equals b.ID
                          join c in context.TUser on b.Email equals c.Email
                          join d in context.TOutlet on a.OutletID equals d.ID
                          where c.Id == userId
                          select new EmployeeOutletViewModel()
                          {
                              ID = a.ID,
                              OutletID = a.OutletID,
                              EmployeeID = a.EmployeeID,
                              RoleID = a.RoleID,
                              OutletName = d.OutletName,
                              CreatedBy = a.CreatedBy,
                              CreatedOn = a.CreatedOn,
                              ModifiedBy = a.ModifiedBy,
                              ModifiedOn = a.ModifiedOn
                          }).ToList();
            }


            return result;
        }

        public static EmployeeOutletViewModel GetDataOutletByUserId(int userId)
        {
            EmployeeOutletViewModel result = new EmployeeOutletViewModel();
            using (POSContext context = new POSContext())
            {
                result = (from a in context.TEmployeeOutlet
                          join b in context.TEmployee on a.EmployeeID equals b.ID
                          join c in context.TUser on b.Email equals c.Email
                          join d in context.TOutlet on a.OutletID equals d.ID
                          where c.Id == userId
                          select new EmployeeOutletViewModel()
                          {
                              ID = a.ID,
                              OutletID = a.OutletID,
                              EmployeeID = a.EmployeeID,
                              RoleID = a.RoleID,
                              OutletName = d.OutletName,
                              CreatedBy = a.CreatedBy,
                              CreatedOn = a.CreatedOn,
                              ModifiedBy = a.ModifiedBy,
                              ModifiedOn = a.ModifiedOn
                          }
                              ).FirstOrDefault();
            }

            return result;
        }
    }
}
