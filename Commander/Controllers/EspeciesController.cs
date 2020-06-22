using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/especies")]
    [ApiController]
    public class EspeciesController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        //Exemplo de Injeção de Dependência
        public EspeciesController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Especies
        //GET api/especies
        [HttpGet]
        public ActionResult<IEnumerable<EspeciesReadDto>> GetAllEspecies()
        {
            var especiesItens = _repository.GetAllEspecies();

            return Ok(_mapper.Map<IEnumerable<EspeciesReadDto>>(especiesItens));
        }

        //GET api/especies/{id}
        [HttpGet("{id}", Name = "GetEspeciesById")]
        public ActionResult<EspeciesReadDto> GetEspeciesById(int id)
        {
            var especiesItem = _repository.GetEspeciesById(id);
            if (especiesItem != null)
            {
                return Ok(_mapper.Map<EspeciesReadDto>(especiesItem));
            }
            return NotFound();
        }

        //POST/api/especies
        [HttpPost]
        public ActionResult<EspeciesReadDto> CreateEspecies(EspeciesCreateUpdateDto especiesCreateDto)
        {
            var especiesModel = _mapper.Map<Especies>(especiesCreateDto);
            _repository.CreateEspecies(especiesModel);
            _repository.SaveChanges();

            var especiesReadDto = _mapper.Map<EspeciesReadDto>(especiesModel);

            return CreatedAtRoute(nameof(GetEspeciesById), new { Id = especiesReadDto.IdEspecie }, especiesReadDto);
        }

        //PUT api/especies/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEspecies(int id, EspeciesCreateUpdateDto especiesUpdateDto)
        {
            var especiesModelFromRepo = _repository.GetEspeciesById(id);
            if (especiesModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(especiesUpdateDto, especiesModelFromRepo);

            _repository.UpdateEspecies(especiesModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/especies/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialEspeciesUpdate(int id, JsonPatchDocument<EspeciesCreateUpdateDto> patchDoc)
        {
            var especiesModelFromRepo = _repository.GetEspeciesById(id);
            if (especiesModelFromRepo == null)
            {
                return NotFound();
            }

            var especiesToPatch = _mapper.Map<EspeciesCreateUpdateDto>(especiesModelFromRepo);
            patchDoc.ApplyTo(especiesToPatch, ModelState);
            if (!TryValidateModel(especiesToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(especiesToPatch, especiesModelFromRepo);
            _repository.UpdateEspecies(especiesModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/especies/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEspecies(int id)
        {
            var especiesModelFromRepo = _repository.GetEspeciesById(id);
            if (especiesModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteEspecies(especiesModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        #endregion
    }
}