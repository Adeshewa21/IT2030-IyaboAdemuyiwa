namespace EnrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentUpdate_Illustration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "InvalidChars");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "InvalidChars", c => c.Int(nullable: false));
        }
    }
}
