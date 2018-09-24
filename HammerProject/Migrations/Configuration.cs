namespace HammerProject.Migrations
{
    using HammerProject.Database.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HammerProject.Database.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HammerProject.Database.DataContext";
        }

        protected override void Seed(HammerProject.Database.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Seed departments
            context.Departments.AddOrUpdate(item => item.DepartmentId,
                new Department { DepartmentId = 1, Name = "Development", Location = "London" },
                new Department { DepartmentId = 2, Name = "Development", Location = "Zurich" },
                new Department { DepartmentId = 3, Name = "Development", Location = "Osijek" },
                new Department { DepartmentId = 4, Name = "Sales", Location = "London" },
                new Department { DepartmentId = 5, Name = "Sales", Location = "Zurich" },
                new Department { DepartmentId = 6, Name = "Sales", Location = "Osijek" },
                new Department { DepartmentId = 7, Name = "Sales", Location = "Basel" },
                new Department { DepartmentId = 8, Name = "Sales", Location = "Lugano" }
            );

            // Seed employees
            context.Employees.AddOrUpdate(item => item.EmployeeId,
                new Employee { EmployeeId = 1, DepartmentId = 4, Name = "Fred Davies", Salary = 50000 },
                new Employee { EmployeeId = 2, DepartmentId = 3, Name = "Bernard Katic", Salary = 50000 },
                new Employee { EmployeeId = 3, DepartmentId = 5, Name = "Rich Davie", Salary = 30000 },
                new Employee { EmployeeId = 4, DepartmentId = 6, Name = "Eva Dobos", Salary = 30000 },
                new Employee { EmployeeId = 5, DepartmentId = 8, Name = "Mario Hunjadi", Salary = 25000 },
                new Employee { EmployeeId = 6, DepartmentId = 7, Name = "Jean Michele", Salary = 25000 },
                new Employee { EmployeeId = 7, DepartmentId = 1, Name = "Bill Gates", Salary = 25000 },
                new Employee { EmployeeId = 8, DepartmentId = 3, Name = "Maja Janic", Salary = 30000 },
                new Employee { EmployeeId = 9, DepartmentId = 3, Name = "Igor Horvat", Salary = 35000 }
            );
        }
    }
}
