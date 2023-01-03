using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCrudUser.Models.Repository
{
    public interface IPersonasRepository
    {
        Task<List<Personas>> GetListPersonas();
        Task<Personas> GetPersona(int id);
        Task DeletePersona(Personas persona);
        Task<Personas> AddPersona(Personas persona);
        Task UpdatePersona(Personas persona);
    }
}
