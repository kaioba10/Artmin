using ArtMin.Domain.Entities;
using System.Collections.Generic;

namespace ArtMin.Domain.Interfaces.Services
{
    public interface IMarcacaoService : IServiceBase<Marcacao>
    {
        IEnumerable<Marcacao> BuscarPorId(int id);
    }
}
