using ArtMin.Domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace ArtMin.Infra.Data.EntityConfig
{
    public class JogadorConfiguration : EntityTypeConfiguration<Jogador>
    {
        public JogadorConfiguration()
        {
            ToTable("Jogadores");

            HasKey(j => j.JogadorId);

            Property(j => j.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(j => j.Email)
                .IsRequired()
                .HasMaxLength(120);

            Property(j => j.Cpf)
                .IsRequired()
                .HasMaxLength(11);
        }
    }
}
