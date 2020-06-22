using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class EspeciesProfile : Profile
    {
        public EspeciesProfile()
        {
            //Fonte -> Destino
            //Get
            CreateMap<Especies, EspeciesReadDto>();
            //Put
            CreateMap<EspeciesCreateUpdateDto, Especies>();
            //Patch e Delete
            CreateMap<Especies,EspeciesCreateUpdateDto>();

        }
    }
}