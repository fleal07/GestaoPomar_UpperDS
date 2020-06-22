using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class GrupoArvoresProfile : Profile
    {
        public GrupoArvoresProfile()
        {
            //Fonte -> Destino
            //Get
            CreateMap<GrupoArvores,GrupoArvoresReadDto>();
            //Put
            CreateMap<GrupoArvoresCreateUpdateDto,GrupoArvores>();
            //Patch e Delete
            CreateMap<GrupoArvores,GrupoArvoresCreateUpdateDto>();
        }
    }
}