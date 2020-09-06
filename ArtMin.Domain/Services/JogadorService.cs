using ArtMin.Domain.Entities;
using ArtMin.Domain.Interfaces.Repositories;
using ArtMin.Domain.Interfaces.Services;

namespace ArtMin.Domain.Services
{
    public class JogadorService : ServiceBase<Jogador>, IJogadorService
    {
        private readonly IJogadorRepository _jogadorRepository;

        public JogadorService(IJogadorRepository jogadorRepository)
            : base(jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }
    }
}
