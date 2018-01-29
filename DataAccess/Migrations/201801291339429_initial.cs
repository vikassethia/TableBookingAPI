namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tablebooking.bookedtable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.String(nullable: false, maxLength: 64, unicode: false),
                        TableNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("tablebooking.booking", t => t.BookingId)
                .ForeignKey("tablebooking.tableinfo", t => t.TableNumber)
                .Index(t => t.BookingId)
                .Index(t => t.TableNumber);
            
            CreateTable(
                "tablebooking.booking",
                c => new
                    {
                        BookingId = c.String(nullable: false, maxLength: 64, unicode: false),
                        FirstName = c.String(maxLength: 50, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                        PhoneNumber = c.String(maxLength: 15, unicode: false),
                        NumberOfGuests = c.Int(nullable: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Notes = c.String(maxLength: 255, unicode: false),
                        BookingDate = c.DateTime(nullable: false, precision: 0),
                        StartTime = c.Time(nullable: false, precision: 0),
                        EndTime = c.Time(precision: 0),
                        BookedBy = c.String(maxLength: 64, unicode: false),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "tablebooking.tableinfo",
                c => new
                    {
                        TableNumber = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        ShapeId = c.Int(),
                        Xposition = c.Double(),
                        Yposition = c.Double(),
                        IsBookable = c.Boolean(nullable: false, storeType: "bit"),
                        IsDeleted = c.Boolean(nullable: false, storeType: "bit"),
                    })
                .PrimaryKey(t => t.TableNumber)
                .ForeignKey("tablebooking.tableshape", t => t.ShapeId)
                .Index(t => t.ShapeId);
            
            CreateTable(
                "tablebooking.tableshape",
                c => new
                    {
                        ShapeId = c.Int(nullable: false, identity: true),
                        ShapeName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ShapeId);
            
            CreateTable(
                "tablebooking.userrole",
                c => new
                    {
                        UserRoleID = c.Int(nullable: false, identity: true),
                        UserRoleName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.UserRoleID);
            
            CreateTable(
                "tablebooking.users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 64, unicode: false),
                        FirstName = c.String(maxLength: 50, storeType: "nvarchar"),
                        LastName = c.String(maxLength: 50, storeType: "nvarchar"),
                        PasswordHash = c.String(nullable: false, maxLength: 255, unicode: false),
                        Salt = c.String(nullable: false, maxLength: 255, unicode: false),
                        UserRoleID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false, storeType: "bit"),
                        AddeddOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("tablebooking.userrole", t => t.UserRoleID)
                .Index(t => t.UserRoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("tablebooking.users", "UserRoleID", "tablebooking.userrole");
            DropForeignKey("tablebooking.tableinfo", "ShapeId", "tablebooking.tableshape");
            DropForeignKey("tablebooking.bookedtable", "TableNumber", "tablebooking.tableinfo");
            DropForeignKey("tablebooking.bookedtable", "BookingId", "tablebooking.booking");
            DropIndex("tablebooking.users", new[] { "UserRoleID" });
            DropIndex("tablebooking.tableinfo", new[] { "ShapeId" });
            DropIndex("tablebooking.bookedtable", new[] { "TableNumber" });
            DropIndex("tablebooking.bookedtable", new[] { "BookingId" });
            DropTable("tablebooking.users");
            DropTable("tablebooking.userrole");
            DropTable("tablebooking.tableshape");
            DropTable("tablebooking.tableinfo");
            DropTable("tablebooking.booking");
            DropTable("tablebooking.bookedtable");
        }
    }
}
