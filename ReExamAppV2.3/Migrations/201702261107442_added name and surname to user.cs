namespace ReExamAppV2._3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednameandsurnametouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}