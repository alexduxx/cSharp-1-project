namespace ReExamAppV2._3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesandrelationsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeHasFocus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        RoleId = c.Int(nullable: false),
                        YearlyFocus = c.DateTime(nullable: false),
                        CompanyRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyRoles", t => t.CompanyRole_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CompanyRole_Id);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.String(),
                        Level = c.String(),
                        YearsOfExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeHasFocus", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EmployeeHasFocus", "CompanyRole_Id", "dbo.CompanyRoles");
            DropIndex("dbo.EmployeeHasFocus", new[] { "CompanyRole_Id" });
            DropIndex("dbo.EmployeeHasFocus", new[] { "UserId" });
            DropTable("dbo.Experiences");
            DropTable("dbo.EmployeeHasFocus");
            DropTable("dbo.CompanyRoles");
        }
    }
}
