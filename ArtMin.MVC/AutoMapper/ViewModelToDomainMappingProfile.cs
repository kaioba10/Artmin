using ArtMin.Application.ViewModels;
using ArtMin.Domain.Entities;
using AutoMapper;

namespace ArtMin.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Jogador, JogadorViewModel>();
            Mapper.CreateMap<Marcacao, MarcacaoViewModel>();
        }
    }
}