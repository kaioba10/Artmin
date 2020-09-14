using ArtMin.Domain.Entities;
using ArtMin.Domain.Interfaces.Repositories;
using System.Linq;

namespace ArtMin.Infra.Data.Repositories
{
    public class JogadorRepository : RepositoryBase<Jogador>, IJogadorRepository
    {
        public bool CompararCpf(string cpf)
            => Db.jogadores.Any(x => x.Cpf == cpf);
    }
}
