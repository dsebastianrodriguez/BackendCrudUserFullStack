using AutoMapper;
using BackendCrudUser.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCrudUser.Models.Profiles
{
    public class PersonasProfile: Profile
    {
        public PersonasProfile()
        {
            CreateMap<Personas, PersonasDTO>();
            CreateMap<PersonasDTO, Personas>();
        }
    }
}
