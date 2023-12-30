using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;

namespace API_Archivo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FraccionamientosController : ControllerBase
    {

        [HttpPost]
        [Route("Agregar_Fraccionamiento")]

        public string Agregar_Fraccionamiento(string nombre, string direccion, string coordenadas, int id_administrador, int id_tesorero)
        {
            //[FromBody] string nombre
            Fraccionamientos fraccionamiento = new Fraccionamientos();

            //int id_admin = int.Parse(id_administrador);
            //int id_teso = int.Parse(id_tesorero);

            if(fraccionamiento.Agregar_Fraccionamiento(nombre,direccion,coordenadas, id_administrador, id_tesorero))
            {
                return "Fraccionamiento Agregado correctamente";
            }
            else
            {
                return "Error al agregar el fraccionamiento";
            }
        }


        [HttpDelete]
        [Route("Eliminar_Fraccionamiento")]

        public string Eliminar_Fraccionamiento(int id_fraccionamiento)
        {
            Fraccionamientos fraccionamiento = new Fraccionamientos();

            if(fraccionamiento.Eliminar_Fraccionamiento(id_fraccionamiento))
            {
                return "Fraccionamiento Eliminado correctamente";
            }
            else
            {
                return "Error al eliminar el fraccionamiento";
            }
        }

        [HttpPatch]
        [Route("Actualizar_Fraccionamiento")]

        public string Actualizar_Fraccionamiento(int id_fraccionamiento, string nombre, string direccion, string coordenadas, int id_administrador, int id_tesorero)
        {
            Fraccionamientos fraccionamiento = new Fraccionamientos();

            if(fraccionamiento.Actualizar_Fraccionamiento(id_fraccionamiento,nombre,direccion,coordenadas,id_administrador,id_tesorero))
            {
                return "Fraccionamiento Actualizado correctamente";
            }
            else
            {
                return "Error al Actualizar el fraccionamiento";
            }
        }


        [HttpGet]
        [Route("Consultar_Fraccionamiento")]

        public List<Fraccionamientos> Consultar_Fraccionamiento(int id_fraccionamiento)
        {

            Fraccionamientos fraccionamiento = new Fraccionamientos();
            List<Fraccionamientos> lista_fraccionamiento = fraccionamiento.Consultar_Fraccionamiento(id_fraccionamiento);

            return lista_fraccionamiento;

        }


    }
}
