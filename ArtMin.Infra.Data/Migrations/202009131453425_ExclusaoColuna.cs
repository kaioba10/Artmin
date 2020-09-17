namespace ArtMin.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExclusaoColuna : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jogador", "ComparaCpf");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jogador", "ComparaCpf", c => c.Boolean(nullable: false));
        }
    }
}
