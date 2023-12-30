using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;

namespace API_Archivo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropiedadesController : ControllerBase
    {
        [HttpPost]
        [Route("Agregar_Propiedad")]

        public string Agregar_Propiedad(int id_propietario, int id_fraccionamiento, string nombre_propietario, string tipo, int lote, string coordenadas)
        {
            Propiedades propiedad = new Propiedades();

            if(propiedad.Agregar_Propiedad(id_propietario, id_fraccionamiento, nombre_propietario, tipo, lote, coordenadas))
            {
                return "Propiedad Agregada correctamente";
            }
            else
            {
                return "Error al agregar la propiedad";
            }
        }

        [HttpDelete]
        [Route("Eliminar_Propiedad")]

        public string Eliminar_Propiedad(int lote, int id_fraccionamiento)
        {
            Propiedades propiedad = new Propiedades();

            if(propiedad.Eliminar_propiedad(lote,id_fraccionamiento))
            {
                return "Propiedad Eliminada correctamente";
            }
            else
            {
                return "Error al eliminar la propiedad";
            }
        }

        [HttpPatch]
        [Route("Actualizar_Propiedad")]


        public string Actualizar_Propiedad(int id_propiedad, int id_propietario, int id_fraccionamiento, string nombre_propietario, string tipo, int lote, string coordenadas)
        {
            Propiedades propiedad = new Propiedades();

            if (propiedad.Actualizar_propiedad(id_propiedad, id_propietario, id_fraccionamiento, nombre_propietario, tipo, lote, coordenadas))
            {
                return "Propiedad actualizada correctamente";
            }
            else
            {
                return "error al actualizar la propiedad";
            }

        }



        [HttpGet]
        [Route("Consultar_Propiedad")]

        public List<Propiedades> Consultar_Propiedad(int id_fraccionamiento, int lote)
        {

            Propiedades propiedad = new Propiedades();

            List<Propiedades> lista_propiedad = propiedad.Consultar_propiedad(id_fraccionamiento,lote);
            if (lista_propiedad.Count >0)
            {
                return lista_propiedad;
            }
            else
            {
                return lista_propiedad;

            }

        }


    }
}
