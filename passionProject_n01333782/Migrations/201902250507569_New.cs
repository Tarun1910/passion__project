namespace passionProject_n01333782.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarMakes",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        ModelName = c.String(nullable: false, maxLength: 99),
                        ModelYear = c.String(nullable: false, maxLength: 99),
                        Description = c.String(nullable: false, maxLength: 255),
                        CarManufactures_Name_id = c.Int(),
                    })
                .PrimaryKey(t => t.ModelID)
                .ForeignKey("dbo.CarManufactures", t => t.CarManufactures_Name_id)
                .Index(t => t.CarManufactures_Name_id);
            
            CreateTable(
                "dbo.CarManufactures",
                c => new
                    {
                        Name_id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 99),
                        Year = c.String(nullable: false, maxLength: 99),
                    })
                .PrimaryKey(t => t.Name_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarMakes", "CarManufactures_Name_id", "dbo.CarManufactures");
            DropIndex("dbo.CarMakes", new[] { "CarManufactures_Name_id" });
            DropTable("dbo.CarManufactures");
            DropTable("dbo.CarMakes");
        }
    }
}
