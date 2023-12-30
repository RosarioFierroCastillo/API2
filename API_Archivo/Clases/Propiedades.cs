using API_Archivo.Controllers;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Threading;

namespace API_Archivo.Clases
{
    public class Propiedades
    {

        public int id_propiedad { get; set; }
        public int lote { get; set; }

        public int id_propietario { get; set; }
        public string nombre_propietario { get; set; }

        public string tipo_propiedad { get; set; }

        public string coordenadas {  get; set; }


        public static string cadena_conexion = Global.cadena_conexion;

        public bool Agregar_Propiedad(int id_propietario,int id_fraccionamiento, string nombre_propietario, string tipo, int lote, string coordenadas)
        {
            bool Propiedad_agregada = false;


            if(Verificar_Disponibilidad_Lote(lote))
            {
                using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
                {
                    int rowsaffected = 0;
                    MySqlCommand comando = new MySqlCommand("insert into propiedades (id_propietario, id_fraccionamiento, Nombre_propietario, Tipo, Lote, Coordenadas) VALUES (@id_propietario,@id_fraccionamiento, @Nombre_propietario, @Tipo, @Lote, @Coordenadas)", conexion);

                    //@id_usuario, @Tipo_deuda,@Nombre_deuda, @Monto, @Ruta_comprobante, @Estado

                    comando.Parameters.Add("@id_propietario", MySqlDbType.Int32).Value = id_propietario;
                    comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                    comando.Parameters.Add("@Nombre_propietario", MySqlDbType.VarChar).Value = nombre_propietario;
                    comando.Parameters.Add("@Tipo", MySqlDbType.VarChar).Value = tipo;
                    comando.Parameters.Add("@Lote", MySqlDbType.Int32).Value = lote;
                    comando.Parameters.Add("@Coordenadas", MySqlDbType.VarChar).Value = coordenadas;




                    try
                    {
                        conexion.Open();
                        rowsaffected = comando.ExecuteNonQuery();

                        if (rowsaffected >= 1)
                        {
                            Propiedad_agregada = true;
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
                    return Propiedad_agregada;

                }
            }
            else
            {
                return Propiedad_agregada;
            }
             
        }

        public bool Eliminar_propiedad(int lote, int id_fraccionamiento)
        {
            bool Propiedad_eliminada = false;


            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM propiedades WHERE Lote=@Lote && id_fraccionamiento=@id_fraccionamiento", conexion);

                //@id_usuario, @Tipo_deuda,@Nombre_deuda, @Monto, @Ruta_comprobante, @Estado

                comando.Parameters.Add("@Lote", MySqlDbType.Int32).Value = lote;
                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;


                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Propiedad_eliminada = true;
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
                return Propiedad_eliminada;

            }


        }


        public bool Actualizar_propiedad(int id_propiedad,int id_propietario, int id_fraccionamiento, string nombre_propietario, string tipo, int lote, string coordenadas)
        {
            bool Propiedad_actualizada = false;

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE propiedades " +
                    "SET id_propietario=@id_propietario, Nombre_propietario=@Nombre_propietario, Tipo=@Tipo, Lote=@Lote, Coordenadas=@Coordenadas " +
                    "WHERE id_Propiedad=@id_propiedad", conexion);

                

                comando.Parameters.Add("@id_propietario", MySqlDbType.Int32).Value = id_propietario;
                comando.Parameters.Add("@Nombre_propietario", MySqlDbType.VarChar).Value = nombre_propietario;
                comando.Parameters.Add("@Tipo", MySqlDbType.VarChar).Value = tipo;
                comando.Parameters.Add("@Coordenadas", MySqlDbType.VarChar).Value = coordenadas;

                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                comando.Parameters.Add("@Lote", MySqlDbType.Int32).Value = lote;
                comando.Parameters.Add("@id_propiedad", MySqlDbType.Int32).Value = id_propiedad;


                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Propiedad_actualizada = true;
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
                return Propiedad_actualizada;

            }

        }

        public List<Propiedades> Consultar_propiedad(int id_fraccionamiento,int lote)
        {

            List<Propiedades> Propiedad = new List<Propiedades>();

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM propiedades WHERE Lote=@Lote && id_fraccionamiento=@id_fraccionamiento", conexion);

                comando.Parameters.Add("@Lote", MySqlDbType.Int32).Value = lote;
                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Propiedad.Add(new Propiedades() {id_propiedad = reader.GetInt32(0), id_propietario= reader.GetInt32(2), nombre_propietario = reader.GetString(3), tipo_propiedad= reader.GetString(4), lote=reader.GetInt32(5), coordenadas = reader.GetString(6) });
                        // MessageBox.Show();
                    }


                }
                catch (MySqlException ex)
                {

                }
                finally
                {
                    conexion.Close();
                }

                return Propiedad;
            }
        }


        public bool Verificar_Disponibilidad_Lote(int lote)
        {
            bool lote_disponible = false;

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM propiedades WHERE Lote=@Lote ", conexion);

                comando.Parameters.Add("@Lote", MySqlDbType.Int32).Value = lote;


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    if(reader.Read())
                    {
                        lote_disponible = false;
                    }
                    else
                    {
                        lote_disponible = true;
                    }


                }
                catch (MySqlException ex)
                {

                }
                finally
                {
                    conexion.Close();
                }

                return lote_disponible;
            }


        }
        
    }
}
