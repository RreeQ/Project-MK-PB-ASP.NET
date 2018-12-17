using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models4Mapper;

namespace WebApplication1.Mapper
{
    public class MapperCfg
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HotDog, HotDogDTO>()
                .ForMember(x => x.FullOrder, conf => conf.MapFrom(z => z.Name + " " + z.Phone));
            }).CreateMapper();
    }
}
