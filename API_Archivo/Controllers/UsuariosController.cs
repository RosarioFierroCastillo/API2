using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net;


namespace API_Archivo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {

        [HttpPost]
        [Route("Agregar_Usuario")]

        public string Agregar_usuario(string nombre, string apellido_pat, string apellido_mat, string telefono, string fecha_nacimiento, string tipo_usuario, int id_fraccionamiento, int id_lote, string intercomunicador, string codigo_acceso, string correo, string contrasenia)
        {
            Personas personas = new Personas();

            if(personas.Agregar_Persona(nombre, apellido_pat,apellido_mat,telefono,fecha_nacimiento,tipo_usuario,id_fraccionamiento,id_lote,intercomunicador,codigo_acceso,correo,contrasenia))
            {
                return "simon";
            }else
            { 
                return "no";
            }


        }

        [HttpDelete]
        [Route("Eliminar_Usuario")]

        public string Eliminar_usuario(int id_persona)
        {
            Personas persona = new Personas();

            if (persona.Eliminar_Persona(id_persona))
            {
                return "simon eliminado";
            }
            else
            {
                return "nomon, no eliminado";
            }

        }

        [HttpPatch]
        [Route("Actualizar_Usuario")]

        public string Actualizar_Usuario(int id_persona, string nombre, string apellido_pat, string apellido_mat, string telefono, string fecha_nacimiento, string tipo_usuario, int id_fraccionamiento, int id_lote, string intercomunicador, string codigo_acceso, string correo, string contrasenia)
        {
            Personas persona = new Personas();

            if(persona.Actualizar_Persona(id_persona,nombre, apellido_pat, apellido_mat, telefono, fecha_nacimiento, tipo_usuario, id_fraccionamiento, id_lote, intercomunicador, codigo_acceso, correo, contrasenia))
            {
                return "Simon, acutalizado";
            }
            else
            {
                return "nomon, no actualizados";
            }
        }

        [HttpGet]
        [Route("Consultar_Personas_Por_Fraccionamiento")]
        public List<Personas> Consultar_Personas_Por_Fraccionamiento(int id_fraccionamiento)
        {
            Personas obj_persona = new Personas();
            List<Personas> list_Personas = obj_persona.Consultar_Personas_Por_Fraccionamiento(id_fraccionamiento);
            return list_Personas;
        }

        [HttpGet]
        [Route("Consultar_Usuario")]
        public List<Personas> Consultar_Usuario(string nombre, string apellido_pat, string apellido_mat)
        {
            

            Personas obj_persona = new Personas();
            List<Personas> list_Persona = obj_persona.Consultar_Persona(nombre, apellido_pat, apellido_mat);

            return list_Persona;

        }

        [HttpGet]
        [Route("Consultar_Correo")]
        public ContentResult Consultar_Correo(string id_persona)
        {
            Personas obj_persona = new Personas();
            string correo = obj_persona.Obtener_Correo_Persona(Convert.ToInt32(id_persona));

            return new ContentResult
            {
                Content = correo,
                ContentType = "text/plain",
                StatusCode = 200 // Código de estado OK (200)
            };
        }

        [HttpGet]
        [Route("Generar_Token")]
        public IActionResult GenerarToken()
        {
            var token = Guid.NewGuid().ToString(); // Generar un token aleatorio utilizando Guid
            return new ContentResult
            {
                Content = token,
                ContentType = "text/plain",
                StatusCode = 200 // Código de estado OK (200)
            };
        }//

        [HttpPost]
        [Route("Generar_Invitacion")]
        public string Generar_invitacion(string token,string correo_electronico, int id_fraccionamiento)
        {
            Invitaciones obj_invitacion = new Invitaciones();
            if(obj_invitacion.Generar_invitacion(token,correo_electronico,id_fraccionamiento))
            {
                return "Invitacion generada correctamente";
            }
            else
            {
                return "Error al generar la invitacion";
            }

        }//

        [HttpGet]
        [Route("Consultar_Invitacion")]
        public List<Invitaciones> Consultar_Invitacion(string token)
        {
            Invitaciones obj_invitacion = new Invitaciones();
            List<Invitaciones> lista_invitacion = obj_invitacion.Cosultar_invitacion(token);

            return lista_invitacion;
        }

        [HttpGet]
        [Route("Consultar_Imagen")]
        public IActionResult Consultar_Imagen(int id_Persona)
        {
            Usuarios obj_usuario = new Usuarios();

            byte[] imagenBytes = obj_usuario.Consultar_Imagen(id_Persona);

            // Devolver los bytes como contenido binario
            return File(imagenBytes, "image/jpeg"); // Cambia el tipo de contenido según el formato de tu imagen
        }

        [HttpPost]
        [Route("Actualizar_Imagen")]

        public string Actualizar_Imagen(IFormFile file,int id_persona)
        {
            int id_usuario = 1;
            string tipo_deuda = "Ordinaria", nombre_deuda = "Mantenimiento", ruta_comprobante = "";
            double monto = 540.215;

            bool archivo_guardado = false;

            if (file.Length > 0)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    byte[] archivoEnBytes = memoryStream.ToArray(); // Convertir a byte[]

                    // Aquí puedes usar 'archivoEnBytes' como necesites
                    Usuarios obj_usuario= new Usuarios();
                    if (obj_usuario.Cargar_Imagen(archivoEnBytes,id_persona))
                    {
                        return "si jala";
                    }
                    else
                    {
                        return "no jala";
                    }

                }
            }
            return "hola";
        }

    }
}
