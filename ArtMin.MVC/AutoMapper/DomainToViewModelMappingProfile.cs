using ArtMin.Application.ViewModels;
using ArtMin.Domain.Entities;
using AutoMapper;

namespace ArtMin.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<JogadorViewModel, Jogador>();
            Mapper.CreateMap<MarcacaoViewModel, Marcacao>();
        }
    }
}