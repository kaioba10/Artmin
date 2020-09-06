using ArtMin.Application.ViewModels;
using System.Collections.Generic;

namespace ArtMin.Application.Interfaces
{
    public interface IJogadorAppService
    {
        IEnumerable<JogadorViewModel> GetAll();
        void Create(JogadorViewModel jogadorViewModel);
        JogadorViewModel GetById(int id);
        void Edit(JogadorViewModel jogadorViewModel);
        void Delete(int id);
    }
}
