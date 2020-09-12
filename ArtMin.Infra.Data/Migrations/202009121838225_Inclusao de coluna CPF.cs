namespace ArtMin.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InclusaodecolunaCPF : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jogador", "Cpf", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jogador", "Cpf");
        }
    }
}
