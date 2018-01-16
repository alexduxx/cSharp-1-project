namespace ReExamAppV2._3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedLogoToCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyInfoes", "Logo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyInfoes", "Logo");
        }
    }
}
