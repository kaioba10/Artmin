using ArtMin.Application.ViewModels;
using System.Collections.Generic;

namespace ArtMin.Application.Interfaces
{
    public interface IMarcacaoAppService
    {
        IEnumerable<MarcacaoViewModel> GetAll();
        void Create(MarcacaoViewModel jogadorViewModel);
        MarcacaoViewModel GetById(int id);
        void Edit(MarcacaoViewModel jogadorViewModel);
        void Delete(int id);
        IEnumerable<JogadorViewModel> GetAllJogador();
    }
}
