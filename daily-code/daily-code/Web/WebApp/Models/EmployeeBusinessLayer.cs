using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesErpdal salesDal = new SalesErpdal();
            return salesDal.Employees.ToList();
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesErpdal salesDal = new SalesErpdal();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
    }
}