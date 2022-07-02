namespace HotelBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editReservation1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "ApplicationUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Reservations", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reservations", "ApplicationUser_Id");
            AddForeignKey("dbo.Reservations", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Reservations", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Date", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Reservations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Reservations", "ApplicationUser_Id");
            DropColumn("dbo.Reservations", "ApplicationUserID");
            DropColumn("dbo.Reservations", "EndDate");
            DropColumn("dbo.Reservations", "StartDate");
        }
    }
}
