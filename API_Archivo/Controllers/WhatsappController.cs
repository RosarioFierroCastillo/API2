using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;

namespace API_Archivo.Controllers
{
    public class WhatsappController : ControllerBase
    {

        [HttpPost]
        [Route("Enviar_Mensaje")]

        public void Enviar_mensaje()
        {
            Whatsapp obj_whats = new Whatsapp();

            obj_whats.Enviar_MensajeAsync().Wait();
        }
    }
}
