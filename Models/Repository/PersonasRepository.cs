using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCrudUser.Models.Repository
{
    public class PersonasRepository : IPersonasRepository
    {
        private readonly AplicationDbContext _context;

        public PersonasRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Personas> AddPersona(Personas persona)
        {
            _context.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task DeletePersona(Personas persona)
        {
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Personas>> GetListPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Personas> GetPersona(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task UpdatePersona(Personas persona)
        {
            var personaItem = await _context.Personas.FirstOrDefaultAsync(x => x.Identificador == persona.Identificador);

            if(personaItem != null)
            {
                personaItem.Nombres = persona.Nombres;
                personaItem.Apellidos = persona.Apellidos;
                personaItem.Id_Tipo_Identificacion = persona.Id_Tipo_Identificacion;
                personaItem.Numero_Identificacion = persona.Numero_Identificacion;
                personaItem.Email = persona.Email;

                await _context.SaveChangesAsync();
            }
            
        }
    }
}
