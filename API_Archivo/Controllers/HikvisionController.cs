using API_Archivo.Clases;
using CardManagement;
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

        [HttpPut]
        [Route("Agregar_Usuario2")]
        public string Agregar_usuario2(string id_usuario, string nombre, string fechaActual, string fechaProximoPago, string telefono)
        {
            AddDevice obj_hik = new AddDevice();

            string user = "admin";
            string password = "Repara123";
            string port = "5551";
            string ip = "187.216.118.73"; 
            if (AddDevice.Login(user, password, port, ip))
            {
                if (obj_hik.InsertUser2(id_usuario, nombre, fechaActual, fechaProximoPago, telefono))
                {
                    return "Simon con telefono";
                }
                else
                {
                    return "Nomon sin telefono";
                }
            }
            else
            {
                return "ni siquiera estoy haciendo login";
            }

           
        }


    }
    }

