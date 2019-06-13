namespace RobotBuilderService.ServiceInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            // Create BotCart Table.
            CreateTable("dbo.CartBots",
                x => new
                {
                    CartBotId = x.Int(nullable: false, identity: true),
                    HeadId = x.Int(nullable: false),
                    LeftArmId = x.Int(nullable: false),
                    RightArmId = x.Int(nullable: false),
                    TorsoId = x.Int(nullable: false),
                    BaseId = x.Int(nullable: false),
                    IsActive = x.Boolean(nullable: false, defaultValue: true),
                    Cost = x.Decimal(nullable: false)
                })
                .PrimaryKey(b => b.CartBotId, "BotCartPrimaryKeyConstraint", true);
        }

        public override void Down()
        {
            DropTable("dbo.BotCart");
        }
    }
}
