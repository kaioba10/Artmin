namespace ArtMin.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustcolunaCPF : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jogador", "Cpf", c => c.String(nullable: false, maxLength: 11, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jogador", "Cpf", c => c.Int(nullable: false));
        }
    }
}
