using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class ColheitaProfile : Profile
    {
        public ColheitaProfile()
        {
            //Fonte -> Destino
            //Get
            CreateMap<Colheita, ColheitaReadDto>();
            //Put
            CreateMap<ColheitaCreateUpdateDto, Colheita>();
            //Patch e Delete
            CreateMap<Colheita,ColheitaCreateUpdateDto>();
        }
    }
}