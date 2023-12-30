using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Threading;

namespace API_Archivo.Clases
{
    public class Usuarios
    {

        public bool Agregar_Usuario(string nombre,string apellido_paterno, string apellido_materno, string tipo_usuario, string telefono, string fecha_nacimiento, string correo, string contrasenia, int lote,int id_persona)
        {
            bool usuario_agregado = false;


            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into usuarios (Correo, Contrasenia, id_persona, Tipo_usuario)(@Correo, @Contrasenia, @id_persona, @Tipo_usuario)", conexion);

                //@id_fraccionamiento, @Nombre_deuda, @Descripción, @Monto, @Fecha_corte, @Periodicidad_dias

                comando.Parameters.Add("@Correo", MySqlDbType.VarChar).Value = correo;
                comando.Parameters.Add("@Contrasenia", MySqlDbType.VarChar).Value = contrasenia;
                comando.Parameters.Add("@id_persona", MySqlDbType.VarChar).Value = id_persona;
                comando.Parameters.Add("@Tipo_usuario", MySqlDbType.VarChar).Value = tipo_usuario;




                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        usuario_agregado = true;
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
                return usuario_agregado;
            }
        }//


        public bool Eliminar_Usuario(int id_usuario)
        {
            bool usuario_eliminado = false;


            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM usuarios WHERE id_Usuario=@id_usuario", conexion);



                comando.Parameters.Add("@id_usuario", MySqlDbType.Int32).Value = id_usuario;
               



                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        usuario_eliminado = true;
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
                return usuario_eliminado;

            }
        }


        public bool Actualizar_Contrasenia(int id_persona, string contrasenia)
        {
            bool contrasenia_actualizada = false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE usuarios " +
                    "SET Contrasenia=@Contrasenia " +
                    "WHERE id_Usuario=@id_usuario", conexion);
                //id_fraccionamiento=@id_fraccionamiento, Tipo=@Tipo, Destinatario=@Destinatario, Asunto=@Asunto, Mensaje=@Mensaje

                comando.Parameters.Add("@id_usuario", MySqlDbType.Int32).Value = id_persona;
                comando.Parameters.Add("@Contrasenia", MySqlDbType.Int32).Value = contrasenia;




                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        contrasenia_actualizada = true;
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
                return contrasenia_actualizada;
            }

        }

        public bool Cargar_Imagen(byte[] imagen_recibida,int id_persona)
        {
            bool resultado = false;
            string connectionString = Global.cadena_conexion;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE personas " +
                    "SET Imagen=@imagen " +
                    "WHERE id_Persona=@id_Persona";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@imagen", imagen_recibida);
                        command.Parameters.AddWithValue("@id_Persona", id_persona);
                        int rowsaffected = command.ExecuteNonQuery();
                        if (rowsaffected > 0)
                        {
                            resultado = true;
                        }
                        else
                        {
                            resultado = false;
                        }
                    }
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la imagen en la base de datos: " + ex.Message);
            }
            finally
            {

            }
            return resultado;

        }

        public byte[] Consultar_Imagen(int id_Persona)
        {
            byte[] imagen = null;
            string connectionString = Global.cadena_conexion;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Imagen FROM personas WHERE id_Persona = @id_Persona";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_Persona", id_Persona);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal("Imagen")))
                                {
                                    long size = reader.GetBytes(reader.GetOrdinal("Imagen"), 0, null, 0, 0);
                                    imagen = new byte[size];
                                    reader.GetBytes(reader.GetOrdinal("Imagen"), 0, imagen, 0, (int)size);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar la imagen en la base de datos: " + ex.Message);
            }

            return imagen;
        }



    }
}
