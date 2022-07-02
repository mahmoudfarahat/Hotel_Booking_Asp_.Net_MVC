namespace HotelBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reservations", "NightNumbers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "NightNumbers", c => c.Int(nullable: false));
        }
    }
}
