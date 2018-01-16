namespace ReExamAppV2._3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEmailToCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyInfoes", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyInfoes", "Email");
        }
    }
}
