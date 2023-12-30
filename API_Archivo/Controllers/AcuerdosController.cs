using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;

namespace API_Archivo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcuerdosController : ControllerBase
    {

        [HttpPost]
        [Route("Agregar_Acuerdo")]

        public string Agregar_Acuerdo(int id_fraccionamiento, string asunto, string detalles, string fecha)
        {
            Acuerdos acuerdo = new Acuerdos();

            if (acuerdo.Agregar_Acuerdo(id_fraccionamiento, asunto, detalles, fecha))
            {
                return "Acuerdo agregado";
            }
            else
            {
                return "Error al agregar acuerdo";
            }

        }

        [HttpDelete]
        [Route("Eliminar_Acuerdo")]
        public string Elimiar_Acuerdo(int id_acuerdo, int id_fraccionamiento)
        {
            Acuerdos acuerdo = new Acuerdos();

            if (acuerdo.Eliminar_Acuerdo(id_acuerdo, id_fraccionamiento))
            {
                return "Acuerdo Eliminado correctamente";
            }
            else
            {
                return "Error al eliminar el acuerdo";
            }

        }

        [HttpPatch]
        [Route("Actualizar_Acuerdo")]

        public string Actualizar_Acuerdo(int id_acuerdo, int id_fraccionamiento, string asunto, string detalles, string fecha)
        {
            Acuerdos acuerdo = new Acuerdos();

            if (acuerdo.Actualizar_Acuerdo(id_acuerdo, id_fraccionamiento, asunto, detalles, fecha))
            {
                return "Acuerdo Actualizado";
            }
            else
            {
                return "Error al actualizar el acuerdo";
            }
        }

        [HttpGet]
        [Route("Consultar_Acuerdo")]

        public List<Acuerdos> Consultar_Acuerdos(int id_fraccionamiento)
        {
            Acuerdos acuerdo = new Acuerdos();
            List<Acuerdos> Lista_acuerdos = acuerdo.Consultar_Acuerdos(id_fraccionamiento);

            return Lista_acuerdos;
        }

        [HttpPost]
        [Route("Cargar_Comprobante")]

        public string Guardar_archivo(IFormFile file)
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
                    Pagos obj_pagos = new Pagos();
                    if (obj_pagos.Cargar_Comprobante_pago(archivoEnBytes))
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

        [HttpGet]
        [Route("Consultar_Comprobante")]

        public IActionResult Consultar_Comprobante(int id_Pago)
        {
            Pagos obj_pagos = new Pagos();

            byte[] imagenBytes = obj_pagos.ConsultarComprobantePago(id_Pago); // Lógica para obtener los bytes de la imagen desde tu base de datos

            // Devolver los bytes como contenido binario
            return File(imagenBytes, "image/jpeg"); // Cambia el tipo de contenido según el formato de tu imagen
        }
    }



        /*
         * 
         * 
         * public string Cargar_Comprobante(byte[] imagen)
        {
            Pagos obj_pagos = new Pagos();
            if(obj_pagos.Cargar_Comprobante_pago(imagen))
            {
                return "simon";
            }
            else
            {
                return "nomon";
            }

        }
         * */













    }

