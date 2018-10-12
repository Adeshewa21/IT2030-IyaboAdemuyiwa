namespace EnrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20181010_Update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollments", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollments", "Notes");
        }
    }
}
