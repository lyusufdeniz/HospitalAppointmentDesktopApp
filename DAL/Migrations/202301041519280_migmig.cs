namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "State", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "EMail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "EMail");
            DropColumn("dbo.Appointments", "State");
        }
    }
}
