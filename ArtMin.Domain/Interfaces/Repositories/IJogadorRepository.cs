using ArtMin.Domain.Entities;

namespace ArtMin.Domain.Interfaces.Repositories
{
    public interface IJogadorRepository : IRepositoryBase<Jogador>
    {
        bool CompararCpf(string cpf);
    }
}
