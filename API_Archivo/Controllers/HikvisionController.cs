using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;

namespace API_Archivo.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class HikvisionController
    {

        
        

            [HttpPost]
            [Route("Agregar_Hikvision")]

            public string InsertHikvision(int id_controlador, int id_fraccionamiento, string user, string password, string port, string ip)
            {
                Hikvision fraccionamiento = new Hikvision();

                if (fraccionamiento.InsertHikvision(id_controlador, id_fraccionamiento, user, password, port, ip))
                {
                    return "Controlador Agregado correctamente";
                }
                else
                {
                    return "Error al agregar el controlador o controlador ya agregado";
                }

            }


        }
    }

