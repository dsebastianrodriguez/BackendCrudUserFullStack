using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCrudUser.Models.DTO
{
    public class LoginUsuario
    {
        [Key]
        public int Identificador { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
    }
}
