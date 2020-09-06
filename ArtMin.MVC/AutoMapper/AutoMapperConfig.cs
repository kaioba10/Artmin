using AutoMapper;

namespace ArtMin.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DomainToViewModelMappingProfile, ViewModelToDomainMappingProfile>();
            });


            Mapper.Initialize(x =>
            {

                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();

            });
        }
    }
}