namespace BusBooking.Repository
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmailId = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Age = c.Byte(nullable: false),
                        Gender = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        BusId = c.Int(nullable: false, identity: true),
                        TravelsName = c.String(),
                        SourceCity = c.String(),
                        DestinationCity = c.String(),
                        Price = c.Double(nullable: false),
                        BusType = c.String(),
                        SeatsAvailable = c.Byte(nullable: false),
                        StartPoint = c.String(),
                        EndPoint = c.String(),
                    })
                .PrimaryKey(t => t.BusId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Buses");
            DropTable("dbo.Accounts");
        }
    }
}
