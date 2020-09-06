using ArtMin.Domain.Entities;
using ArtMin.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ArtMin.Infra.Data.Context
{
    public class ArtMinContext : DbContext
    {
        public ArtMinContext()
            : base("ArtMin")
        {

        }

        public DbSet<Jogador> jogadores { get; set; }
        public DbSet<Marcacao> marcacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("VARCHAR"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new JogadorConfiguration());
            modelBuilder.Configurations.Add(new MarcacaoConfiguration());
        }
    }
}
