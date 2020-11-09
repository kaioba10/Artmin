using ArtMin.Domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace ArtMin.Infra.Data.EntityConfig
{
    public class MarcacaoConfiguration : EntityTypeConfiguration<Marcacao>
    {
        public MarcacaoConfiguration()
        {
            HasKey(m => m.MarcacaoId);

            Property(m => m.Gol)
                .IsOptional();

            Property(m => m.Assistencia)
                .IsOptional();

            Property(m => m.Vitoria)
                .IsOptional();

            Property(m => m.PenaltiDefendido)
                .IsOptional();

            Property(m => m.PenaltiPerdido)
                .IsOptional();

            Property(m => m.GolContra)
                .IsOptional();

            Property(m => m.Pontos)
                .IsOptional();

            Property(m => m.ArtilheiroDia)
                .IsOptional();

            Property(m => m.AssistenteDia)
                .IsOptional();

            Property(m => m.VitoriosoDia)
                .IsOptional();

            HasRequired(j => j.Jogador)
                .WithMany()
                .HasForeignKey(j => j.JogadorId);
        }
    }
}
