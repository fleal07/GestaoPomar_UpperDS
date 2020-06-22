using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class ArvoresProfile : Profile
    {
        public ArvoresProfile()
        {
            //Fonte -> Destino
            //Get
            CreateMap<Arvores, ArvoresReadDto>();
            //Put
            CreateMap<ArvoresCreateUpdateDto, Arvores>();
            //Patch e Delete
            CreateMap<Arvores,ArvoresCreateUpdateDto>();
        }
    }
}