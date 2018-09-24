namespace HammerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStoredProcedures : DbMigration
    {
        public override void Up()
        {
            // Create procedure for increasing salary in percent
            CreateStoredProcedure(
                "spIncreaseSalary",
                p => new
                {
                    id = p.Int(),
                    percent = p.Int()
                },
                body:
                    @"UPDATE Employees SET Salary = Salary + (Salary*(@percent/100.00)) WHERE EmployeeId = @id"
            );

            // Create procedure for decreasing salary in percent
            CreateStoredProcedure(
                "spDecreaseSalary",
                p => new
                {
                    id = p.Int(),
                    percent = p.Int()
                },
                body:
                    @"UPDATE Employees SET Salary = Salary - (Salary*(@percent/100.00)) WHERE EmployeeId = @id"
            );
        }
        
        public override void Down()
        {
            DropStoredProcedure("spIncreaseSalary");
            DropStoredProcedure("spDecreaseSalary");
        }
    }
}
