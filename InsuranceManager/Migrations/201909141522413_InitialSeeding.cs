namespace InsuranceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSeeding : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[TypeOfRisks] (Name) VALUES ('High')
INSERT INTO [dbo].[TypeOfRisks] (Name) VALUES ('Mid-High')
INSERT INTO [dbo].[TypeOfRisks] (Name) VALUES ('Medium')
INSERT INTO [dbo].[TypeOfRisks] (Name) VALUES ('Low')

INSERT INTO [dbo].[Coverages] (Name) VALUES ('Earthquake')
INSERT INTO [dbo].[Coverages] (Name) VALUES ('Fire')
INSERT INTO [dbo].[Coverages] (Name) VALUES ('Theft')
INSERT INTO [dbo].[Coverages] (Name) VALUES ('Loss')

INSERT INTO [dbo].[Customers] (Name, Email, Phone) VALUES ('Barbara Johnes', 'bjohnes@abc.com', '152206477')
INSERT INTO [dbo].[Customers] (Name, Email, Phone) VALUES ('Albert Keneally', 'akeneally@abc.com', '674686457')
INSERT INTO [dbo].[Customers] (Name, Email, Phone) VALUES ('Freddie White', 'fwhite@abc.com', '879754532')
INSERT INTO [dbo].[Customers] (Name, Email, Phone) VALUES ('Ruth Buckley', 'rbuckley@abc.com', '598798533')
");
        }
        
        public override void Down()
        {
        }
    }
}
