namespace passionProject_n01333782.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedmodelidincarmakemodel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CarMakes");
            AddColumn("dbo.CarMakes", "ModelID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CarMakes", "ModelID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CarMakes");
            DropColumn("dbo.CarMakes", "ModelID");
            AddPrimaryKey("dbo.CarMakes", "ModelName");
        }
    }
}
