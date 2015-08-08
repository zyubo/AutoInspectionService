namespace InspectionService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalCostAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InspectionDataBaseModels",
                c => new
                    {
                        InspectionId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        VehicleId = c.String(),
                        Title = c.String(),
                        Level = c.String(),
                        Type = c.String(),
                        RecommendedAction = c.String(),
                        TechnicianAdvice = c.String(),
                        PhotoList = c.String(),
                        PartsList = c.String(),
                        PriceList = c.String(),
                        CustomFields = c.String(),
                        IsAccepted = c.String(),
                        TotalCost = c.String(),
                    })
                .PrimaryKey(t => t.InspectionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InspectionDataBaseModels");
        }
    }
}
