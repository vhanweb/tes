using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    public class EmployeeDAL
    {
        public static List<Employee> GetData()
        {
            List<Employee> result = new List<Employee>();
            using (POSContext context = new POSContext())
            {
                result = context.TEmployee.ToList();
            }
            return result;
        }

        public static Employee GetDataByEmail(string Email)
        {
            Employee result = new Employee();
            using (POSContext context = new POSContext())
            {
                result = context.TEmployee.Where(m => m.Email == Email)
                    .FirstOrDefault();
            }
            return result;
        }

        public static List<EmployeViewModel> GetDataTable()
        {
            List<EmployeViewModel> result = new List<EmployeViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from a in context.TEmployee
                          join b in context.TEmployeeOutlet on a.ID equals b.EmployeeID
                          join c in context.TRole on b.RoleID equals c.id
                          select new EmployeViewModel
                          {
                              FullName = a.FirstName + " " + a.LastName,
                              Email = a.Email,
                              Title = a.Title,
                              Permission = c.Desciption,
                              RoleID = b.RoleID,
                              RoleName = c.Name
                          }
                              ).ToList();
            }
            return result;
        }
    }
}
