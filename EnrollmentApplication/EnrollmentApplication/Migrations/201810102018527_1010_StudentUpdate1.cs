namespace EnrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1010_StudentUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Age", c => c.Int(nullable: false));
            //AddColumn("dbo.Students", "InvalidChars", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Students", "InvalidChars");
            DropColumn("dbo.Students", "Age");
        }
    }
}
