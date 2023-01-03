using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCrudUser.Models
{
    public class Personas
    {
        [Key]
        public int Identificador { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Id_Tipo_Identificacion { get; set; }
        public int Numero_Identificacion { get; set; }
        public string Email { get; set; }
        public DateTime Fecha_Creacion { get; set; }

    }
}
