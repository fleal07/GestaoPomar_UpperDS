using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/grupoarvores")]
    [ApiController]
    public class GrupoArvoresController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        //Exemplo de Injeção de Dependência
        public GrupoArvoresController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region GrupoArvores

        //GET api/grupoarvores
        [HttpGet]
        public ActionResult<IEnumerable<GrupoArvoresReadDto>> GetAllGrupoArvores()
        {
            var grupoArvoresItens = _repository.GetAllGrupoArvores();

            return Ok(_mapper.Map<IEnumerable<GrupoArvoresReadDto>>(grupoArvoresItens));
        }

        //GET api/grupoarvores/{id}
        [HttpGet("{id}", Name = "GetGrupoArvoreById")]
        public ActionResult<GrupoArvoresReadDto> GetGrupoArvoresById(int id)
        {
            var grupoArvoreItem = _repository.GetGrupoArvoresById(id);
            if (grupoArvoreItem != null)
            {
                return Ok(_mapper.Map<GrupoArvoresReadDto>(grupoArvoreItem));
            }
            return NotFound();
        }

        //POST/api/grupoarvores
        [HttpPost]
        public ActionResult<GrupoArvoresReadDto> CreateGrupoArvores(GrupoArvoresCreateUpdateDto grupoarvoresCreateDto)
        {
            var grupoarvoresModel = _mapper.Map<GrupoArvores>(grupoarvoresCreateDto);
            _repository.CreateGrupoArvores(grupoarvoresModel);
            _repository.SaveChanges();

            var grupoarvoresReadDto = _mapper.Map<GrupoArvoresReadDto>(grupoarvoresModel);

            return CreatedAtRoute(nameof(GetGrupoArvoresById), new { Id = grupoarvoresReadDto.IdGrupoArvore }, grupoarvoresReadDto);
        }

        //PUT api/grupoarvores/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateGrupoArvores(int id, GrupoArvoresCreateUpdateDto grupoarvoresUpdateDto)
        {
            var grupoarvoresModelFromRepo = _repository.GetGrupoArvoresById(id);
            if (grupoarvoresModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(grupoarvoresUpdateDto, grupoarvoresModelFromRepo);

            _repository.UpdateGrupoArvores(grupoarvoresModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/grupoarvores/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialGrupoArvoresUpdate(int id, JsonPatchDocument<GrupoArvoresCreateUpdateDto> patchDoc)
        {
            var grupoarvoresModelFromRepo = _repository.GetGrupoArvoresById(id);
            if (grupoarvoresModelFromRepo == null)
            {
                return NotFound();
            }

            var grupoarvoresToPatch = _mapper.Map<GrupoArvoresCreateUpdateDto>(grupoarvoresModelFromRepo);
            patchDoc.ApplyTo(grupoarvoresToPatch, ModelState);
            if (!TryValidateModel(grupoarvoresToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(grupoarvoresToPatch, grupoarvoresModelFromRepo);
            _repository.UpdateGrupoArvores(grupoarvoresModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/grupoarvores/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteGrupoArvores(int id)
        {
            var grupoarvoresModelFromRepo = _repository.GetGrupoArvoresById(id);
            if (grupoarvoresModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteGrupoArvores(grupoarvoresModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        #endregion
    }
}