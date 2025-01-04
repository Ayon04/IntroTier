namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Cgpa", c => c.Double(nullable: false));
            AddColumn("dbo.Students", "Dept", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Dept");
            DropColumn("dbo.Students", "Cgpa");
        }
    }
}
