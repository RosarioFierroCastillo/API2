using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;

namespace API_Archivo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class NotificacionesController : ControllerBase
    {

        [HttpPost]
        [Route("Agregar_Notificacion")]
        public string Agregar_notificacion(int id_fraccionamiento, string tipo, int id_destinatario, string asunto, string mensaje)
        {

            Notificaciones notificacion = new Notificaciones();

            if(notificacion.Agregar_Notificacion(id_fraccionamiento,tipo,id_destinatario, asunto, mensaje))
            {
                return "Notificacion agregada correctamente";
            }
            else
            {
                return "Error al agregar notificacion";
            }

        }

        [HttpDelete]
        [Route("Eliminar_Notificacion")]

        public string Eliminar_notificacion(int id_notificacion, int id_fraccionamiento)
        {
            Notificaciones notificacion = new Notificaciones();

            if(notificacion.Eliminar_Notificacion(id_notificacion,id_fraccionamiento))
            {
                return "Notificacion eliminada";
            }
            else
            {
                return "Error al eliminar notificacion";
            }

        }

        [HttpPatch]
        [Route("Actualizar_Notificacion")]
        public string Actualizar_notificacion(int id_notificacion, int id_fraccionamiento, string tipo, string id_destinatario, string asunto, string mensaje)
        {
            Notificaciones notificacion = new Notificaciones();

            if (notificacion.Actualizar_Notificacion(id_notificacion,id_fraccionamiento,tipo, id_destinatario, asunto, mensaje))
            {            

                return "Notificacion actualizada";
            }
            else
            {
                return "Error al actualizar la notificacion";
            }

        }

        [HttpGet]
        [Route("Consultar_Notificacion")]

        public List<Notificaciones> Consultar_Notificacion(int id_fraccionamiento, int id_destinatario)
        {
            Notificaciones notificacion = new Notificaciones();
            List<Notificaciones> Lista_notificaciones = notificacion.Consultar_Notificacion(id_fraccionamiento, id_destinatario);

            return Lista_notificaciones;

        }

        [HttpGet]
        [Route("Consultar_Notificacion_Por_ID")]

        public List<Notificaciones> Consultar_Notificacion_Por_Id(int id_fraccionamiento, int id_destinatario)
        {
            Notificaciones notificacion = new Notificaciones();
            List<Notificaciones> Lista_notificaciones = notificacion.Consultar_Notificacion(id_fraccionamiento, id_destinatario);

            return Lista_notificaciones;

        }

    }
}
