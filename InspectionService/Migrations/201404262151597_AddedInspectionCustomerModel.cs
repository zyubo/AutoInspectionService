namespace InspectionService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInspectionCustomerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InspectionCustomerModels",
                c => new
                    {
                        InspectionCustomerId = c.String(nullable: false, maxLength: 128),
                        InspectionId = c.String(),
                        UserId = c.String(),
                        IsAccepted = c.String(),
                    })
                .PrimaryKey(t => t.InspectionCustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InspectionCustomerModels");
        }
    }
}
