namespace ReExamAppV2._3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.EmployeeHasFocus", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.EmployeeHasFocus", name: "IX_UserId", newName: "IX_User_Id");
            DropColumn("dbo.EmployeeHasFocus", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeHasFocus", "RoleId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.EmployeeHasFocus", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.EmployeeHasFocus", name: "User_Id", newName: "UserId");
        }
    }
}
