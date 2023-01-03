using BackendCrudUser.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BackendCrudUser.Models.DTO;
using BackendCrudUser.Models.Repository;
using Microsoft.AspNetCore.Authorization;

namespace BackendCrudUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IPersonasRepository _personaRepository;

        public PersonaController(IMapper mapper, IPersonasRepository personasRepository) 
        {
            _mapper = mapper;
            _personaRepository = personasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listPersonas = await _personaRepository.GetListPersonas();
                var listPersonasDto = _mapper.Map<IEnumerable<PersonasDTO>>(listPersonas);
                return Ok(listPersonasDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var persona = await _personaRepository.GetPersona(id);
                if (persona == null)
                {
                    return NotFound();
                }
                var PersonaDto = _mapper.Map<PersonasDTO>(persona);
                return Ok(PersonaDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var persona = await _personaRepository.GetPersona(id);
                if (persona == null)
                {
                    return NotFound();
                }
                await _personaRepository.DeletePersona(persona);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonasDTO personaDto)
        {
            try
            {
                var persona = _mapper.Map<Personas>(personaDto);

                persona.Fecha_Creacion = DateTime.Now;
                persona = await _personaRepository.AddPersona(persona);
                var PersonasItemDto = _mapper.Map<PersonasDTO>(persona);
                return CreatedAtAction("Get", new { id = PersonasItemDto.Identificador }, personaDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PersonasDTO personaDto)
        {
            try
            {
                var persona = _mapper.Map<Personas>(personaDto);
                if (id != persona.Identificador)
                {
                    return BadRequest();
                }

                var personaItem = await _personaRepository.GetPersona(id);
                if (personaItem == null)
                {
                    return NotFound();
                }

                await _personaRepository.UpdatePersona(persona);
                return NoContent();


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
