using MySql.Data.MySqlClient;

namespace API_Archivo.Clases
{
    public class Acuerdos
    {

        public int id_acuerdo {  get; set; }
        public int id_fraccionamiento {  get; set; }
        public string asunto { get; set; }
        public string detalles {  get; set; }

        public string fecha {  get; set; }

        public bool Agregar_Acuerdo(int id_fraccionamiento, string asunto, string detalles, string fecha)
        {
            bool Acuerdo_agregado = false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into acuerdos (id_fraccionamiento, Asunto, Detalles, Fecha) VALUES (@id_fraccionamiento, @Asunto, @Detalles, @Fecha)", conexion);

                //id_fraccionamiento=@id_fraccionamiento, Tipo=@Tipo, Destinatario=@Destinatario, Asunto=@Asunto, Mensaje=@Mensaje

                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                comando.Parameters.Add("@Asunto", MySqlDbType.VarChar).Value = asunto;
                comando.Parameters.Add("@Detalles", MySqlDbType.VarChar).Value = detalles;
                comando.Parameters.Add("@Fecha", MySqlDbType.VarChar).Value = fecha;




                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Acuerdo_agregado = true;
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
                return Acuerdo_agregado;
            }
        }

        public bool Eliminar_Acuerdo(int id_acuerdo,int id_fraccionamiento)
        {

            bool Acuerdo_eliminado=false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM acuerdos WHERE id_Acuerdo=@id_acuerdo && id_fraccionamiento=@id_fraccionamiento", conexion);

                //@id_usuario, @Tipo_deuda,@Nombre_deuda, @Monto, @Ruta_comprobante, @Estado

                comando.Parameters.Add("@id_acuerdo", MySqlDbType.Int32).Value = id_acuerdo;
                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;



                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Acuerdo_eliminado = true;
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
                return Acuerdo_eliminado;

            }
        }

        public bool Actualizar_Acuerdo(int id_acuerdo, int id_fraccionamiento, string asunto, string detalles, string fecha)
        {
            bool Acuerdo_actualizado = false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE acuerdos " +
                    "SET id_fraccionamiento=@id_fraccionamiento, Asunto=@Asunto, Detalles=@detalles, Fecha=@Fecha " +
                    "WHERE id_Acuerdo=@id_acuerdo", conexion);
                //id_fraccionamiento=@id_fraccionamiento, Tipo=@Tipo, Destinatario=@Destinatario, Asunto=@Asunto, Mensaje=@Mensaje

                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                comando.Parameters.Add("@Asunto", MySqlDbType.VarChar).Value = asunto;
                comando.Parameters.Add("@detalles", MySqlDbType.VarChar).Value = detalles;
                comando.Parameters.Add("@Fecha", MySqlDbType.VarChar).Value = fecha;
                comando.Parameters.Add("@id_acuerdo", MySqlDbType.Int32).Value = id_acuerdo;




                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Acuerdo_actualizado = true;
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
                return Acuerdo_actualizado;
            }
        }


        public List<Acuerdos> Consultar_Acuerdos(int id_fraccionamiento)
        {
            List<Acuerdos> Lista_acuerdos = new List<Acuerdos> ();

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM acuerdos WHERE id_fraccionamiento=@id_fraccionamiento", conexion);

                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Lista_acuerdos.Add(new Acuerdos() { id_acuerdo=reader.GetInt32(0), id_fraccionamiento=reader.GetInt32(1), asunto=reader.GetString(2), detalles=reader.GetString(3), fecha=reader.GetString(4)});
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

                return Lista_acuerdos;
            }
        }



        


    }
}
