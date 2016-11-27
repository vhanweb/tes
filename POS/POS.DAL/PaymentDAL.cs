using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    public class PaymentDAL
    {
        public static PaymentDetailViewModel GetDataById(int iId)
        {
            PaymentDetailViewModel result = new PaymentDetailViewModel();
            using (POSContext context = new POSContext())
            {
                result = (from x in context.TUser
                          join y in context.TEmployee on x.Email equals y.Email
                          where x.Id == iId
                          select new PaymentDetailViewModel()
                          {
                              EmployeeID = y.ID,
                          }).FirstOrDefault();
            }
            return result;
        }
    }
}
