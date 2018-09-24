namespace HammerProject.Migrations
{
    using HammerProject.Database;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSqlViews : DbMigration
    {
        public override void Up()
        {
            string sql = @"CREATE VIEW vwDepartment AS
                           SELECT DepartmentId AS departmentNo, Name + ' ' + Location AS departmentDescription FROM Departments";
            using (var dtx = new DataContext())
            {
                dtx.Database.ExecuteSqlCommand(sql);
            }
        }
        
        public override void Down()
        {
            using (var dtx = new DataContext())
            {
                dtx.Database.ExecuteSqlCommand("DROP VIEW vwDepartment");
            }
        }
    }
}
