using ArtMin.Domain.Entities;
using ArtMin.Domain.Interfaces.Repositories;
using ArtMin.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ArtMin.Domain.Services
{
    public class MarcacaoService : ServiceBase<Marcacao>, IMarcacaoService
    {
        private readonly IMarcacaoRepository _marcacaoRepository;

        public MarcacaoService(IMarcacaoRepository marcacaoRepository)
            : base(marcacaoRepository)
        {
            _marcacaoRepository = marcacaoRepository;
        }
        public IEnumerable<Marcacao> BuscarPorId(int id)
        {
            return _marcacaoRepository.BuscarPorId(id);
        }
    }
}
