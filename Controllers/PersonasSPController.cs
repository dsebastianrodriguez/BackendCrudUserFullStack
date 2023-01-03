using BackendCrudUser.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCrudUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasSPController : ControllerBase
    {
        private string connectionString;
        public PersonasSPController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DevConnection");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Personas>> Get([FromQuery] int[] ids)
        {
            var valores = new List<Personas>();
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand coman = new SqlCommand("Obtener_Personas", conn))
                {
                    coman.CommandType = System.Data.CommandType.StoredProcedure;

                    var dt = new DataTable();
                    dt.Columns.Add("Id", typeof(int));

                    foreach (var id in ids)
                    {
                        dt.Rows.Add(id);
                    }

                    var parametro = coman.Parameters.AddWithValue("ListadoIds", dt);
                    parametro.SqlDbType = SqlDbType.Structured;


                }
            }
            

            return valores;
        }
    }
}
