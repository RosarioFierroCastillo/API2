using API_Archivo.Clases;
using Microsoft.AspNetCore.Mvc;

namespace API_Archivo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProveedoresController :ControllerBase
    {

        [HttpPost]
        [Route("Agregar_Proveedor")]

        public string Agregar_Proveedor(int id_fraccionamiento, string nombre, string apellido_paterno, string apellido_materno, string telefono, string tipo, string direccion, string funcion)
        {
            Proveedores proveedor = new Proveedores();

            if(proveedor.Agregar_Proveedor(id_fraccionamiento, nombre, apellido_paterno,apellido_materno, telefono, tipo, direccion, funcion))
            {
                return "Proveedor agregado";
            }
            else
            {
                return "Error al agregar al proveedor";
            }

        }

        [HttpDelete]
        [Route("Eliminar_Proveedor")]

        public string Eliminar_Proveedor(int id_fraccionamiento, int id_proveedor)
        {
            Proveedores proveedor = new Proveedores();

            if(proveedor.Eliminar_Proveedor(id_proveedor,id_fraccionamiento))
            {
                return "Proveedor Eliminado";
            }
            else
            {
                return "Error al eliminar al proveedor";
            }

        }

        [HttpPatch]
        [Route("Actualizar_Proveedor")]

        public string Actualizar_Proveedor(int id_proveedor, int id_fraccionamiento, string nombre, string apellido_paterno, string apellido_materno, string telefono, string tipo, string direccion, string funcion)
        {

            Proveedores proveedor = new Proveedores();

            if(proveedor.Actualizar_Proveedor(id_proveedor,id_fraccionamiento,nombre,apellido_paterno,apellido_materno, telefono, tipo, direccion, funcion))
            {
                return "Proveedor Actualizado";
            }
            else
            {
                return "Error al actualizar al proveedor";
            }

        }

        [HttpGet]
        [Route("Consultar_Proveedor")]

        public List<Proveedores> Consultar_Proveedores(int id_fraccionamiento)
        {
            Proveedores proveedor = new Proveedores();
            List<Proveedores> Lista_proveedores = proveedor.Consultar_Proveedores(id_fraccionamiento); 
            
            return Lista_proveedores;
        }



    }
}
