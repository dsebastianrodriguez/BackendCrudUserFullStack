using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCrudUser.Models
{
    public class Usuarios
    {
        [Key]
        public int Identificador { get; set; }
        [Required(ErrorMessage = "El usuario no puede estar vacio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "El contraseña no puede estar vacia")]
        public string Pass { get; set; }
        [Compare("Pass", ErrorMessage = "Las contraseñas no coinciden")]
        [NotMapped]
        public string confirmarPass { get; set; }
        public DateTime Fecha_Creacion { get; set; }

    }
}
