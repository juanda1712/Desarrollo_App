using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Unidad_2.Controllers
{
    [Route("test")]
    [ApiController]
    public class PruebasController : ControllerBase
    {
        public static List<Pruebas> items = new List<Pruebas>()
        {
            new Pruebas()
            {
                Id = 1,
                Name = "Prueba 1"
            },
            new Pruebas()
            {
                Id=2,
                Name = "Pruebas 2"
            }

        };


        [HttpGet("Listar")]
        public List<Pruebas> Consultar()
        {
            return items;
        }


        [HttpGet]
        public Pruebas item(int id)
        {
            return items[0];
        }

        [HttpGet("Detalle")]
        public dynamic Consultar_id(int id)
        {
            var det = items.Where(x => x.Id == id).ToList();
            if (det.Count > 0 )
            {
                return det;
            }
            else
            {
                return new
                {
                    code= "Api001" ,
                    message = "No existe registos"

                };
            }


           
        }



    }
}
