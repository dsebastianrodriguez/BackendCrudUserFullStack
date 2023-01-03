using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCrudUser.Models.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AplicationDbContext _context;

        public UsuariosRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Usuarios> AddUsuarios(Usuarios usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }


        public async Task<Usuarios> GetUsuario(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
    }
}
