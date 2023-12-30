using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;

namespace API_Archivo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeudasOrdinariasController
    {

        [HttpPost]
        [Route("Agregar_Deuda")]

        public string Agregar_Deuda_Ordinaria(int id_fraccionamiento, string nombre_deuda, string descripcion, double monto, string fecha_corte, int periodicidad_dias)
        {
            DeudasOrdinarias deuda = new DeudasOrdinarias();

            if(deuda.Agregar_Deuda_Ordinaria(id_fraccionamiento, nombre_deuda, descripcion, monto, fecha_corte, periodicidad_dias))
            {
                return "Deuda ordinaria agregada";
            }
            else
            {
                return "error al agregar la deuda ordinaria";
            }

        }

        [HttpDelete]
        [Route("Eliminar_Deuda")]

        public string Eliminar_Deuda_Ordinaria(int id_deuda, int id_fraccionamiento)
        {
            DeudasOrdinarias deuda = new DeudasOrdinarias();

            if(deuda.Eliminar_Deuda_Ordinaria(id_deuda,id_fraccionamiento))
            {
                return "Deuda Ordinaria Eliminada correctamente";
            }
            else
            {
                return "Error al eliminar la deuda ordinaria";
            }

        }


        [HttpPatch]
        [Route("Actualizar_Deuda")]

        public string Actualizar_Deuda_Ordinaria(int id_deuda, int id_fraccionamiento, string nombre_deuda, string descripcion, double monto, string fecha_corte, int periodicidad_dias)
        {
            DeudasOrdinarias deuda = new DeudasOrdinarias();

            if(deuda.Actualizar_Deuda_Ordinaria(id_deuda,id_fraccionamiento,nombre_deuda,descripcion,monto,fecha_corte,periodicidad_dias))
            {
                return "Deuda Ordinaria correctamente";
            }
            else
            {
                return "Error al eliminar la deuda Ordinaria";
            }

        }

        [HttpGet]
        [Route("Consultar_Deuda")]

        public List<DeudasOrdinarias> Consultar_Deudas_Ordinarias(int id_fraccionamiento)
        {
            DeudasOrdinarias deuda = new DeudasOrdinarias();
            List<DeudasOrdinarias> Lista_deudas_ordinarias = deuda.Consultar_deudas(id_fraccionamiento);

            return Lista_deudas_ordinarias;

        }







    }
}
