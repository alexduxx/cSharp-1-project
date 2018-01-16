namespace ReExamAppV2._3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationsForExperience : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Experiences", "CompanyRoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Experiences", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Experiences", "CompanyRoleId");
            CreateIndex("dbo.Experiences", "UserId");
            AddForeignKey("dbo.Experiences", "CompanyRoleId", "dbo.CompanyRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Experiences", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Experiences", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Experiences", "RoleId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Experiences", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Experiences", "CompanyRoleId", "dbo.CompanyRoles");
            DropIndex("dbo.Experiences", new[] { "UserId" });
            DropIndex("dbo.Experiences", new[] { "CompanyRoleId" });
            AlterColumn("dbo.Experiences", "UserId", c => c.String());
            DropColumn("dbo.Experiences", "CompanyRoleId");
        }
    }
}
