using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;

namespace API_Archivo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentaController : ControllerBase
    { 

        [HttpPost]
        [Route("Agregar_Arrendatario")]

        public string Agregar_Arrendatario(int id_renta, int id_usuario, int id_fraccionamiento, int id_lote, int proximo_pago, float monto)
        {
            Renta renta = new Renta();

            if(renta.Agregar_Arrendatario(id_renta, id_usuario, id_fraccionamiento, id_lote, proximo_pago, monto))
            {
                return "Simon";
            }
            else
            {
                return "no";
            }
        }



    }
}
