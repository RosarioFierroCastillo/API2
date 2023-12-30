using MySql.Data.MySqlClient;
using System.Threading;

namespace API_Archivo.Clases
{
    public class Sesion
    {

        public string Correo { get; set; }
        public int id_usuario { get; set; }
        public string tipo_usuario { get; set; }

        public List<Sesion> Iniciar_Sesion(string correo, string contrasenia)
        {
            List<Sesion> list_sesion = new List<Sesion>();

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("SELECT * from usuarios WHERE Correo = @Correo && Contrasenia = @Contrasenia", conexion);

                //@id_fraccionamiento, @Nombre_deuda, @Descripción, @Monto, @Fecha_corte, @Periodicidad_dias

                comando.Parameters.Add("@Correo", MySqlDbType.VarChar).Value = correo;
                comando.Parameters.Add("@Contrasenia", MySqlDbType.VarChar).Value = contrasenia;


                try
                {
                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        list_sesion.Add(new Sesion() { Correo = reader.GetString(1), id_usuario=reader.GetInt32(3), tipo_usuario=reader.GetString(4)});
                    }

                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conexion.Close();
                }
                return list_sesion;
            }

        }



    }
}
