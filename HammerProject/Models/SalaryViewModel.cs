using HammerProject.Database;
using HammerProject.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HammerProject.Models
{
    public class SalaryViewModel
    {

        public decimal AverageDevelopmentSalary { get; set; }
        public List<IGrouping<string, Employee>> EmployeesInLocations { get; set; }

        public SalaryViewModel()
        {
            using (var dtx = new DataContext())
            {
                AverageDevelopmentSalary = getAverageSalary("Development");
                EmployeesInLocations = getNumberOfEmployees();
                foreach (var item in EmployeesInLocations)
                {
                    Console.WriteLine(item.Key);
                    foreach (Employee ep in item)
                    {
                        Console.WriteLine(ep.Name);
                    }
                }
            }
        }

        public decimal getAverageSalary(string departmentName)
        {
            using (var dtx = new DataContext())
            {
                return dtx.Employees.Where(item => item.Department.Name.Equals(departmentName))
                    .Where(item => !item.Department.Location.Equals("London"))
                    .Average(item => item.Salary);
            }
        }

        public List<IGrouping<string, Employee>> getNumberOfEmployees()
        {
            using (var dtx = new DataContext())
            {
                return dtx.Employees.GroupBy(item => item.Department.Location)
                    .Where(item => item.Count() > 1).Select(item => item).ToList();
            }
        }
    }
}