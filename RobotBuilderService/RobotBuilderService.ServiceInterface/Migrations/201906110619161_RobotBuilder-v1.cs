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
            // Add column "IsActive" in Robot Parts table.
            AddColumn("RobotParts", "IsActie", 
                x => x.Boolean(
                        nullable: false, defaultValue: true
                    ));

            // Alter column "Id" as Identity & Nullable:'false' in Robot Parts table.
            AlterColumn("RobotParts", "Id",
                x => x.Int(
                        nullable: false, identity: true
                    ));


            // Create BotCart Table.
            CreateTable("BotCart",
                x => new
                {
                    BotCartId = x.Int(nullable: false, identity: true),
                    HeadId = x.Int(nullable: false),
                    LeftArmId = x.Int(nullable: false),
                    RightArmId = x.Int(nullable: false),
                    TorsoId = x.Int(nullable: false),
                    BaseId = x.Int(nullable: false),
                    IsActive = x.Boolean(nullable: false, defaultValue: true),
                    Cost = x.Decimal(nullable: false)
                })
                .PrimaryKey(b => b.BotCartId);

            // AddPrimaryKey("RobotParts", column: "Id", clustered: true);

        }
        
        // To delete from database.
        public override void Down()
        {
        }
    }
}
