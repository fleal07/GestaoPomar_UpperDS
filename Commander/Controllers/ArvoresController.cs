using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/arvores")]
    [ApiController]
    public class ArvoresController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        //Exemplo de Injeção de Dependência
        public ArvoresController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Arvores
        //GET api/arvores
        [HttpGet]
        public ActionResult<IEnumerable<ArvoresReadDto>> GetAllArvores()
        {
            var arvoresItens = _repository.GetAllArvores();

            return Ok(_mapper.Map<IEnumerable<ArvoresReadDto>>(arvoresItens));
        }

        //GET api/arvores/{id}
        [HttpGet("{id}", Name = "GetArvoresById")]
        public ActionResult<ArvoresReadDto> GetArvoresById(int id)
        {
            var arvoreItem = _repository.GetArvoresById(id);
            if (arvoreItem != null)
            {
                return Ok(_mapper.Map<ArvoresReadDto>(arvoreItem));
            }
            return NotFound();
        }

        //POST/api/arvores
        [HttpPost]
        public ActionResult<ArvoresReadDto> CreateArvores(ArvoresCreateUpdateDto arvoresCreateDto)
        {
            var arvoresModel = _mapper.Map<Arvores>(arvoresCreateDto);
            _repository.CreateArvores(arvoresModel);
            _repository.SaveChanges();

            var arvoresReadDto = _mapper.Map<ArvoresReadDto>(arvoresModel);

            return CreatedAtRoute(nameof(GetArvoresById), new { Id = arvoresReadDto.IdArvore }, arvoresReadDto);
        }

        //PUT api/arvores/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateArvores(int id, ArvoresCreateUpdateDto arvoresUpdateDto)
        {
            var arvoresModelFromRepo = _repository.GetArvoresById(id);
            if (arvoresModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(arvoresUpdateDto, arvoresModelFromRepo);

            _repository.UpdateArvores(arvoresModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/arvores/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialArvoresUpdate(int id, JsonPatchDocument<ArvoresCreateUpdateDto> patchDoc)
        {
            var arvoresModelFromRepo = _repository.GetArvoresById(id);
            if (arvoresModelFromRepo == null)
            {
                return NotFound();
            }

            var arvoresToPatch = _mapper.Map<ArvoresCreateUpdateDto>(arvoresModelFromRepo);
            patchDoc.ApplyTo(arvoresToPatch, ModelState);
            if (!TryValidateModel(arvoresToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(arvoresToPatch, arvoresModelFromRepo);
            _repository.UpdateArvores(arvoresModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/arvores/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteArvores(int id)
        {
            var arvoresModelFromRepo = _repository.GetArvoresById(id);
            if (arvoresModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteArvores(arvoresModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        #endregion
    }
}