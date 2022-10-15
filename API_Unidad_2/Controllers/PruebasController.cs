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


            var h1 = Request.Headers.Where(x => x.Key.Equals("Auth")).FirstOrDefault();
            //string Hd_value = Request.Headers["Auth"];
            
            if(h1.Value.Count == 0)
            {
                return new
                {
                    code = "Api400",
                    message = "No autorizado"

                };
            }

            if(h1.Value != "1234" )
            {
                return new
                {
                    code = "Api400",
                    message = "No autorizado"

                };

            }

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


        [HttpPost("Save")]
        public dynamic Guardar (Pruebas pruebas)

        {
            if (pruebas == null)
                return new
                {
                    code = "Api002",
                    message = "Falta Body Request"

                };


            items.Add(pruebas);
            return new
            {
                Data = pruebas,
                code = "OK",
                message = "Registros Almacenados Exitosamente."

            };

        }



        [HttpPut ("Update")]
        public dynamic update (Pruebas pruebas)
        {


            foreach (var det  in items.Where(x=>x.Id == pruebas.Id).ToList())
            {
                det.Name = pruebas.Name;
                det.Id = pruebas.Id;             
            }

            return new
            {
                Data = pruebas,
                code = "OK",
                message = "Registros Modificados Exitosamente."

            };
        }


        [HttpDelete ("Delete")]
        public dynamic delete (int id)
        {

            if (id.Equals(0))
                return new
                {
                    code = "API500",
                    message = "FAltan Parametros de consulta."
                };


            Pruebas pruebas = items.Where(x=> x.Id == id).FirstOrDefault();

            if (pruebas == null)
                return new
                {
                    code = "API003",
                    message = "No existen datos de consulta"
                };


            items.Remove(pruebas);
            return new
            {               
                code = "OK",
                message = "Registros Eliminados Exitosamente."

            };


        }



    }
}
