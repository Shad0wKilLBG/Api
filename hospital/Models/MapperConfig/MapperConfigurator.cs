using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospital.Models.MapperConfig
{
    public class MapperConfiguratior
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>(); ;
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<UserModel, User>().ForMember(d => d.Id, opt => opt.MapFrom(x => x.Id));
            //CreateMap<User, UserModel>().ForMember(d => d.Id, opt => opt.MapFrom(x => x.Id));

            //CreateMap<RegisterModel, User>();
        }
    }
}