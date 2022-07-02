namespace HotelBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingFileToRoom1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "RoomImage", c => c.String());
            DropColumn("dbo.Rooms", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "File", c => c.String());
            DropColumn("dbo.Rooms", "RoomImage");
        }
    }
}
