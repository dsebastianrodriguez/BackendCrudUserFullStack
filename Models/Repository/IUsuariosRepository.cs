using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCrudUser.Models.Repository
{
    public interface IUsuariosRepository
    {
        Task<Usuarios> GetUsuario(int id);
        Task<Usuarios> AddUsuarios(Usuarios usuario);
    }
}
