using ArtMin.Domain.Entities;
using System.Collections.Generic;

namespace ArtMin.Domain.Interfaces.Repositories
{
    public interface IMarcacaoRepository : IRepositoryBase<Marcacao>
    {
        IEnumerable<Marcacao> BuscarPorId(int id);
        Marcacao VerificaMarcacaoExistente(int id);
        Marcacao ObterMarcacaoPorJogadorId(int idJogador);
    }
}
