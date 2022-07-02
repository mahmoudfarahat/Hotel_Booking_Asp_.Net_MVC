namespace HotelBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingFileToRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "File", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "File");
        }
    }
}
