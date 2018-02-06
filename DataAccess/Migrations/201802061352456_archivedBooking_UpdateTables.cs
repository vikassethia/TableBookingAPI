namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class archivedBooking_UpdateTables : DbMigration
    {
        public override void Up()
        {
            //MoveTable(name: "tablebooking.bookedtable", newSchema: "dbo");
            //MoveTable(name: "tablebooking.booking", newSchema: "dbo");
            //MoveTable(name: "tablebooking.tableinfo", newSchema: "dbo");
            //MoveTable(name: "tablebooking.tableshape", newSchema: "dbo");
            //MoveTable(name: "tablebooking.userrole", newSchema: "dbo");
            //MoveTable(name: "tablebooking.users", newSchema: "dbo");
            CreateTable(
                "archivedbooking",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.String(maxLength: 64, unicode: false),
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
                        bookedtables = c.String(maxLength: 50, unicode: false),
                        hasArrived = c.Boolean(nullable: false, storeType: "bit"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("booking", "hasArrived", c => c.Boolean(nullable: false, storeType: "bit"));
            AddColumn("tableinfo", "TableName", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tableinfo", "TableName");
            DropColumn("dbo.booking", "hasArrived");
            DropTable("dbo.archivedbooking");
            //MoveTable(name: "dbo.users", newSchema: "tablebooking");
            //MoveTable(name: "dbo.userrole", newSchema: "tablebooking");
            //MoveTable(name: "dbo.tableshape", newSchema: "tablebooking");
            //MoveTable(name: "dbo.tableinfo", newSchema: "tablebooking");
            //MoveTable(name: "dbo.booking", newSchema: "tablebooking");
            //MoveTable(name: "dbo.bookedtable", newSchema: "tablebooking");
        }
    }
}
