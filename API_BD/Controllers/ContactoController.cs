using API_BD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        public readonly WEB_APIContext _dbcontex;


        public ContactoController(WEB_APIContext _contex)
        {
            _dbcontex = _contex;
        }

        [HttpGet]
        [Route("Lista")]
        [Authorize]
        public IActionResult Lista()
        {
            List<Contacto> lista = new List<Contacto>();

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var Valid = Funciones_Varias.ValidarToken(identity);


            try
            {
                lista = _dbcontex.Contactos.Include(x => x.ObjTipo).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No se encontraron Datos"});

            }


        }


        [HttpGet]
        [Route("Detalle")]
       
        public IActionResult Detalle(int id)
        {
            Contacto ObjContacto = _dbcontex.Contactos.Find(id) ;

            if (ObjContacto == null)
            {
                return NotFound( new {mensaje = "No existe Datos" });
            }


            try
            {
                ObjContacto = _dbcontex.Contactos.Include(c => c.ObjTipo).Where(x=>x.IdContacto == id).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", response = ObjContacto });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No se encontraron Datos" });

            }


        }

        [HttpPost]
        [Route("Guardar")]
        
        public IActionResult Guardar([FromBody] Contacto objContacto)
        {

            try
            {
                _dbcontex.Contactos.Add(objContacto);               
                var result = _dbcontex.SaveChanges();
                if(result > 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", response = "Datos Almacenados Correctamente" });
                else
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No es posible Almacenar Datos" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No es posible Almacenar Datos" });

            }

        }


        [HttpPut]
        [Route("Modificar")]
       
        public IActionResult Modificar([FromBody] Contacto objContacto )
        {
            Contacto _Contacto = _dbcontex.Contactos.Find(objContacto.IdContacto);

            if (_Contacto == null)
            {
                return NotFound(new { mensaje = "Contacto no encontrado" });
            }


            try
            {

                _Contacto.Nombre = string.IsNullOrEmpty(objContacto.Nombre)?  _Contacto.Nombre: objContacto.Nombre;
                _Contacto.Descripcion = objContacto.Descripcion is null ? _Contacto.Descripcion : objContacto.Descripcion;
                _Contacto.Telefono = objContacto.Telefono is null ? _Contacto.Telefono : objContacto.Telefono;
                _Contacto.IdTipo = objContacto.IdTipo is null ? _Contacto.IdTipo : objContacto.IdTipo;

                _dbcontex.Contactos.Update(_Contacto);
                var result = _dbcontex.SaveChanges();
            
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", response = "Datos Almacenados Correctamente" });
           }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No es posible Almacenar Datos" });

            }

        }



        [HttpDelete]
        [Route("Eliminar")]
      
        public IActionResult Eliminar (int id)
        {
            Contacto ObjContacto = _dbcontex.Contactos.Find(id);

            if (ObjContacto == null)
            {
                return NotFound(new { mensaje = "Contacto no encontrado" });
            }

            try
            {              
                _dbcontex.Contactos.Remove(ObjContacto);
                _dbcontex.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", response = "Contacto Eliminado Exitosamente" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No es posible Eliminar la información" });

            }
        }


    }
}
