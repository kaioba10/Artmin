using ArtMin.Domain.Entities;
using ArtMin.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArtMin.Infra.Data.Repositories
{
    public class MarcacaoRepository : RepositoryBase<Marcacao>, IMarcacaoRepository
    {
        public IEnumerable<Marcacao> BuscarPorId(int id)
        {
            return Db.Marcacoes.Where(x => x.JogadorId == id).Include(x => x.Jogador);
        }

        public Marcacao VerificaMarcacaoExistente(int id)
        {
            return Db.Marcacoes.Where(x => x.JogadorId == id).Include(x => x.Jogador).FirstOrDefault();
        }

        public Marcacao ObterMarcacaoPorJogadorId(int idJogador)
        {
            return Db.Marcacoes.Where(x => x.JogadorId == idJogador).Include(x => x.Jogador).FirstOrDefault();
        }
    }
}
