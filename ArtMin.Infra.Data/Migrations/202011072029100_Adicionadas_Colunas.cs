namespace ArtMin.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionadas_Colunas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marcacao", "ArtilheiroDia", c => c.Double());
            AddColumn("dbo.Marcacao", "AssistenteDia", c => c.Double());
            AddColumn("dbo.Marcacao", "VitoriosoDia", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marcacao", "VitoriosoDia");
            DropColumn("dbo.Marcacao", "AssistenteDia");
            DropColumn("dbo.Marcacao", "ArtilheiroDia");
        }
    }
}
