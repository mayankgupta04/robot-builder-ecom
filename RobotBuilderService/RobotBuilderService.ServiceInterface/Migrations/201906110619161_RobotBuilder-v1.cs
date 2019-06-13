namespace RobotBuilderService.ServiceInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RobotBuilderv1 : DbMigration
    {
        // To Add or Update Database
        // Run the "update-database -verbose" command in package manager console.
        public override void Up()
        {
            //// Add column "IsActive" in Robot Parts table.
            //AddColumn("RobotParts", "IsActie", 
            //    x => x.Boolean(
            //            nullable: false, defaultValue: true
            //        ));

            //// Alter column "Id" as Identity & Nullable:'false' in Robot Parts table.
            //AlterColumn("RobotParts", "Id",
            //    x => x.Int(
            //            nullable: false, identity: true
            //        ));

            //CreateTable(
            //    "dbo.RobotParts",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        Title = c.String(),
            //        Description = c.String(),
            //        Type = c.String(),
            //        Cost = c.Double(nullable: false),
            //    })
            //    .PrimaryKey(t => t.Id);
            //// AddPrimaryKey("RobotParts", column: "Id", clustered: true);

        }

        // To delete from database.
        public override void Down()
        {
            //DropTable("dbo.RobotParts");
        }
    }
}
