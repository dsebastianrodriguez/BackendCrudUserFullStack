using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCrudUser.Models
{
    public class TipoIdentificacion
    {
        [Key]
        public int Id { get; set; }
        public string Tipo_Identificacion { get; set; }
    }
}
