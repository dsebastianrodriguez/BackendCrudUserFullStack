using AutoMapper;
using BackendCrudUser.Models;
using BackendCrudUser.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCrudUser.Models.Repository;
using Microsoft.EntityFrameworkCore;
using BackendCrudUser.Helper;

namespace BackendCrudUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly AplicationDbContext _context;

        public UsuariosController(IMapper mapper, AplicationDbContext context, IUsuariosRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuariosRepository = usuarioRepository;
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuario = await _usuariosRepository.GetUsuario(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                var UsuarioDto = _mapper.Map<LoginUsuario>(usuario);
                return Ok(UsuarioDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuarios usuariosDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (await _context.Usuarios.Where(x => x.Usuario == usuariosDto.Usuario).AnyAsync())
                {
                    return BadRequest("El usuario ya existe");

                }

                //HashedPassword Pass = HashHelper.Hash(usuariosDto.Pass);
                //usuariosDto.Pass = Pass.Password;


                var usuario = _mapper.Map<Usuarios>(usuariosDto);             
                usuario.Fecha_Creacion = DateTime.Now;
                
                usuario = await _usuariosRepository.AddUsuarios(usuario);
                var usuarioItemDto = _mapper.Map<LoginUsuario>(usuario);
                return CreatedAtAction("Get", new { id = usuarioItemDto.Identificador }, usuarioItemDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
