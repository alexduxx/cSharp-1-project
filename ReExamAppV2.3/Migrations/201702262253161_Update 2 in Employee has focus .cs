namespace ReExamAppV2._3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2inEmployeehasfocus : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.EmployeeHasFocus", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.EmployeeHasFocus", name: "IX_User_Id", newName: "IX_UserId");
            AddColumn("dbo.EmployeeHasFocus", "RoleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeHasFocus", "RoleId");
            RenameIndex(table: "dbo.EmployeeHasFocus", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.EmployeeHasFocus", name: "UserId", newName: "User_Id");
        }
    }
}
