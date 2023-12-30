using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;

namespace API_Archivo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EgresosController
    {
        [HttpPost]
        [Route("Agregar_Egreso")]
        public string Agregar_Egreso(int id_fraccionamiento, string concepto, string descripcion, string proveedor, double monto, string fecha)
        {
            Egresos egreso = new Egresos();

            if(egreso.Agregar_Egreso(id_fraccionamiento,concepto,descripcion,proveedor,monto,fecha))
            {
                return "Simon";
            }
            else
            {
                return "Nel";
            }
        }

        [HttpDelete]
        [Route("Eliminar_Egreso")]


        public string Eliminar_Egreso(int id_egreso, int id_fraccionamiento)
        {
            Egresos egreso = new Egresos();
            
            if(egreso.Eliminar_Egreso(id_egreso,id_fraccionamiento))
            {
                return "Simon";
            }
            else
            {
                return "Nel";
            }
        }

        [HttpPatch]
        [Route("Actualizar_Egreso")]

        public string Actualizar_Egreso(int id_egreso, int id_fraccionamiento, string concepto, string descripcion, string proveedor, double monto, string fecha)
        {
            Egresos egreso = new Egresos();

            if(egreso.Actualizar_Egreso(id_egreso,id_fraccionamiento,concepto,descripcion,proveedor,monto,fecha))
            {
                return "Simon";
            }
            else
            {
                return "Nel";
            }

        }

        [HttpGet]
        [Route("Consultar_Egreso")]

        public List<Egresos> Consultar_Egresos(int id_fraccionamiento)
        {
            Egresos egreso = new Egresos();

            List<Egresos> List_egresos = egreso.Consultar_Egresos(id_fraccionamiento);

            return List_egresos;
        }

        [HttpGet]
        [Route("Consultar_Egreso_especifico")]

        public List<Egresos> Consultar_Egresos_Especificos(int id_egreso, int id_fraccionamiento)
        {
            Egresos egreso = new Egresos();

            List<Egresos> List_egresos = egreso.Consultar_Egreso_Especifico(id_egreso,id_fraccionamiento);

            return List_egresos;
        }

    }
}
