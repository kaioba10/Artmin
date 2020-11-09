namespace ArtMin.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajuste_Tipo_Colunas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Marcacao", "ArtilheiroDia", c => c.Boolean());
            AlterColumn("dbo.Marcacao", "AssistenteDia", c => c.Boolean());
            AlterColumn("dbo.Marcacao", "VitoriosoDia", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Marcacao", "VitoriosoDia", c => c.Double());
            AlterColumn("dbo.Marcacao", "AssistenteDia", c => c.Double());
            AlterColumn("dbo.Marcacao", "ArtilheiroDia", c => c.Double());
        }
    }
}
