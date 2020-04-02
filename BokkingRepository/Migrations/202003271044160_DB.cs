namespace BusBookingRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmailId = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 24),
                        Name = c.String(nullable: false, maxLength: 50),
                        Age = c.Byte(nullable: false),
                        Gender = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        BusId = c.Int(nullable: false),
                        SeatNumbers = c.String(),
                        BookingDate = c.DateTime(nullable: false),
                        TravelsName = c.String(),
                        SourceCity = c.String(),
                        DestinationCity = c.String(),
                        Price = c.Double(nullable: false),
                        BusType = c.String(),
                        Date = c.String(),
                        StartPoint = c.String(),
                        EndPoint = c.String(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Buses", t => t.BusId, cascadeDelete: true)
                .Index(t => t.BusId);
            
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        BusId = c.Int(nullable: false, identity: true),
                        TravelsName = c.String(nullable: false, maxLength: 30),
                        SourceCity = c.String(nullable: false, maxLength: 50),
                        DestinationCity = c.String(nullable: false, maxLength: 50),
                        Price = c.Double(nullable: false),
                        BusType = c.String(nullable: false),
                        Date = c.String(),
                        SeatsAvailable = c.Byte(nullable: false),
                        StartPoint = c.String(nullable: false),
                        EndPoint = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "BusId", "dbo.Buses");
            DropIndex("dbo.Bookings", new[] { "BusId" });
            DropTable("dbo.Buses");
            DropTable("dbo.Bookings");
            DropTable("dbo.Accounts");
        }
    }
}
