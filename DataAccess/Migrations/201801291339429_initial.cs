namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "bookedtable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.String(nullable: false, maxLength: 64, unicode: false),
                        TableNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("booking", t => t.BookingId)
                .ForeignKey("tableinfo", t => t.TableNumber)
                .Index(t => t.BookingId)
                .Index(t => t.TableNumber);
            
            CreateTable(
                "booking",
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
                "tableinfo",
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
                .ForeignKey("tableshape", t => t.ShapeId)
                .Index(t => t.ShapeId);
            
            CreateTable(
                "tableshape",
                c => new
                    {
                        ShapeId = c.Int(nullable: false, identity: true),
                        ShapeName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ShapeId);
            
            CreateTable(
                "userrole",
                c => new
                    {
                        UserRoleID = c.Int(nullable: false, identity: true),
                        UserRoleName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.UserRoleID);
            
            CreateTable(
                "users",
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
                .ForeignKey("userrole", t => t.UserRoleID)
                .Index(t => t.UserRoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("users", "UserRoleID", "userrole");
            DropForeignKey("tableinfo", "ShapeId", "tableshape");
            DropForeignKey("bookedtable", "TableNumber", "tableinfo");
            DropForeignKey("bookedtable", "BookingId", "booking");
            DropIndex("users", new[] { "UserRoleID" });
            DropIndex("tableinfo", new[] { "ShapeId" });
            DropIndex("bookedtable", new[] { "TableNumber" });
            DropIndex("bookedtable", new[] { "BookingId" });
            DropTable("users");
            DropTable("userrole");
            DropTable("tableshape");
            DropTable("tableinfo");
            DropTable("booking");
            DropTable("bookedtable");
        }
    }
}
