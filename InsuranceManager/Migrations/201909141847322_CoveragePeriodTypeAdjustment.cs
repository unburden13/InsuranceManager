namespace InsuranceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoveragePeriodTypeAdjustment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Policies", "CoveragePeriod", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Policies", "CoveragePeriod", c => c.Byte(nullable: false));
        }
    }
}
