using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;

namespace API_Archivo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SesionController
    {

        [HttpGet]
        [Route("Iniciar_Sesion")]

        public List<Sesion> Iniciar_Sesion(string correo, string contrasenia)
        {
            Sesion sesion= new Sesion();
            List<Sesion> list_datos= sesion.Iniciar_Sesion(correo, contrasenia);


            return list_datos;

        }
    }
}
