using AutoMapper;
using BackendCrudUser.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCrudUser.Models.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<Usuarios, LoginUsuario>();
            CreateMap<LoginUsuario, Usuarios>();
        }
        
    }
}
