using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/colheita")]
    [ApiController]
    public class ColheitaController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        //Exemplo de Injeção de Dependência
        public ColheitaController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Colheita
        //GET api/colheita
        [HttpGet]
        public ActionResult<IEnumerable<ColheitaReadDto>> GetAllColheitas()
        {
            var colheitasItens = _repository.GetAllColheita();

            return Ok(_mapper.Map<IEnumerable<ColheitaReadDto>>(colheitasItens));
        }

        //GET api/colheita/{id}
        [HttpGet("{id}", Name = "GetColheitasById")]
        public ActionResult<ColheitaReadDto> GetColheitasById(int id)
        {
            var colheitaItem = _repository.GetColheitaById(id);
            if (colheitaItem != null)
            {
                return Ok(_mapper.Map<ColheitaReadDto>(colheitaItem));
            }
            return NotFound();
        }

        //POST/api/colheita
        [HttpPost]
        public ActionResult<ColheitaReadDto> CreateColheita(ColheitaCreateUpdateDto colheitaCreateDto)
        {
            var colheitaModel = _mapper.Map<Colheita>(colheitaCreateDto);
            _repository.CreateColheita(colheitaModel);
            _repository.SaveChanges();

            var colheitaReadDto = _mapper.Map<ColheitaReadDto>(colheitaModel);

            return CreatedAtRoute(nameof(GetColheitasById), new { Id = colheitaReadDto.IdColheita }, colheitaReadDto);
        }

        //PUT api/colheita/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateColheita(int id, ColheitaCreateUpdateDto colheitaUpdateDto)
        {
            var colheitaModelFromRepo = _repository.GetColheitaById(id);
            if (colheitaModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(colheitaUpdateDto, colheitaModelFromRepo);

            _repository.UpdateColheita(colheitaModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/colheita/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialColheitaUpdate(int id, JsonPatchDocument<ColheitaCreateUpdateDto> patchDoc)
        {
            var colheitaModelFromRepo = _repository.GetColheitaById(id);
            if (colheitaModelFromRepo == null)
            {
                return NotFound();
            }

            var colheitaToPatch = _mapper.Map<ColheitaCreateUpdateDto>(colheitaModelFromRepo);
            patchDoc.ApplyTo(colheitaToPatch, ModelState);
            if (!TryValidateModel(colheitaToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(colheitaToPatch, colheitaModelFromRepo);
            _repository.UpdateColheita(colheitaModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/colheita/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteColheita(int id)
        {
            var colheitaModelFromRepo = _repository.GetColheitaById(id);
            if (colheitaModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteColheita(colheitaModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        #endregion
    }
}