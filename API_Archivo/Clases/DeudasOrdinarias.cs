using MySql.Data.MySqlClient;
using System;

namespace API_Archivo.Clases
{
    public class DeudasOrdinarias
    {
        public int id_deuda { get; set; }
        public int id_fraccionamiento { get; set; }
        public string nombre_deuda { get; set; }
        public string descripcion { get; set; }
        public double monto { get; set; }
        public string fecha_corte { get; set; }
        public int periodicidad_dias { get; set; }


        public bool Agregar_Deuda_Ordinaria(int id_fraccionamiento, string nombre_deuda, string descripcion, double monto, string fecha_corte, int periodicidad_dias)
        {
           bool DeudaOrdinaria_agregada = false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into deudas_ordinarias (id_fraccionamiento, Nombre_deuda, Descripción, Monto, Fecha_corte, Periodicidad_dias) VALUES (@id_fraccionamiento, @Nombre_deuda, @Descripción, @Monto, @Fecha_corte, @Periodicidad_dias)", conexion);

                //@id_fraccionamiento, @Nombre_deuda, @Descripción, @Monto, @Fecha_corte, @Periodicidad_dias

                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                comando.Parameters.Add("@Nombre_deuda", MySqlDbType.VarChar).Value = nombre_deuda;
                comando.Parameters.Add("@Descripción", MySqlDbType.VarChar).Value = descripcion;
                comando.Parameters.Add("@Monto", MySqlDbType.Double).Value = monto;
                comando.Parameters.Add("@Fecha_corte", MySqlDbType.Date).Value = fecha_corte;
                comando.Parameters.Add("@Periodicidad_dias", MySqlDbType.Int32).Value = periodicidad_dias;




                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        DeudaOrdinaria_agregada = true;
                        Actualizar_deudores(id_fraccionamiento,monto, nombre_deuda, fecha_corte, descripcion, periodicidad_dias);
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
                return DeudaOrdinaria_agregada;
            }


        }

        public bool Eliminar_Deuda_Ordinaria(int id_deuda, int id_fraccionamiento)
        {
            bool Deuda_eliminada = false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM deudas_ordinarias WHERE id_Deudas_ordinarias=@id_deuda && id_fraccionamiento=@id_fraccionamiento", conexion);



                comando.Parameters.Add("@id_deuda", MySqlDbType.Int32).Value = id_deuda;
                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;



                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Deuda_eliminada = true;
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
                return Deuda_eliminada;

            }


        }

        public bool Actualizar_Deuda_Ordinaria(int id_deuda,int id_fraccionamiento, string nombre_deuda, string descripcion, double monto, string fecha_corte, int periodicidad_dias)
        {

            bool Deuda_actualizada=false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE deudas_ordinarias " +
                    "SET id_fraccionamiento=@id_fraccionamiento, Nombre_deuda=@nombre_deuda, Descripción=@descripcion, Monto=@monto, Fecha_corte=@fecha_corte, Periodicidad_dias=@Periodicidad_dias " +
                    "WHERE id_Deudas_ordinarias=@id_deuda", conexion);
                //id_fraccionamiento=@id_fraccionamiento, Tipo=@Tipo, Destinatario=@Destinatario, Asunto=@Asunto, Mensaje=@Mensaje

                comando.Parameters.Add("@id_deuda", MySqlDbType.Int32).Value = id_deuda;
                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                comando.Parameters.Add("@nombre_deuda", MySqlDbType.VarChar).Value = nombre_deuda;
                comando.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = descripcion;
                comando.Parameters.Add("@monto", MySqlDbType.Double).Value = monto;
                comando.Parameters.Add("@fecha_corte", MySqlDbType.VarChar).Value = fecha_corte;
                comando.Parameters.Add("@Periodicidad_dias", MySqlDbType.VarChar).Value = periodicidad_dias;



                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Deuda_actualizada = true;
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
                return Deuda_actualizada;
            }

        }

        public List<DeudasOrdinarias> Consultar_deudas(int id_fraccionamiento)
        {
            List<DeudasOrdinarias> Lista_deudas = new List<DeudasOrdinarias> ();

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM deudas_ordinarias WHERE id_fraccionamiento=@id_fraccionamiento", conexion);

                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Lista_deudas.Add(new DeudasOrdinarias() { id_deuda = reader.GetInt32(0), id_fraccionamiento=reader.GetInt32(1), nombre_deuda=reader.GetString(2), descripcion=reader.GetString(3), monto=reader.GetDouble(4), fecha_corte=reader.GetString(5), periodicidad_dias=reader.GetInt32(6)});
                    }


                }
                catch (MySqlException ex)
                {

                }
                finally
                {
                    conexion.Close();
                }

                return Lista_deudas;
            }

        }



        /*
         Metodo "Actualizar_deudores"

        este metodo es llamado por el metodo de "Agregar_Deuda_Ordinaria"

        toma una lista de todas las personas del fraccionamiento y las va agregando a la tabla de Pagos, con la informacion 
        de la nueva deuda que se acaba de agregar.


         * */
        public bool Actualizar_deudores(int id_fraccionamiento,double monto, string nombre_deuda, string fecha_corte, string descripcion, int periodicidad)
        {
            bool resultado = false;
            Personas obj_personas = new Personas();
            List<Personas> Lista_personas = obj_personas.Consultar_Personas_Por_Fraccionamiento(id_fraccionamiento);

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into pagos(id_usuario,Nombre_persona, id_fraccionamiento, Monto, Nombre_deuda, Fecha, Descripcion, Periodicidad) VALUES (@id_usuario,@Nombre_persona, @id_fraccionamiento, @Monto, @Nombre_deuda, @Fecha, @Descripcion, @Periodicidad)", conexion);

                try
                {
                    conexion.Open();


                    for (int i = 0; i < Lista_personas.Count; i++)
                    {
                        comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                        comando.Parameters.Add("@Monto", MySqlDbType.Double).Value = monto;
                        comando.Parameters.Add("@Nombre_deuda", MySqlDbType.VarChar).Value = nombre_deuda;
                        comando.Parameters.Add("@Fecha", MySqlDbType.VarChar).Value = fecha_corte;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar).Value = descripcion;
                        comando.Parameters.Add("@Periodicidad", MySqlDbType.Int32).Value = periodicidad;

                        comando.Parameters.Add("@id_usuario", MySqlDbType.Int32).Value = periodicidad;
                        comando.Parameters.Add("@Nombre_persona", MySqlDbType.VarChar).Value = Lista_personas[i].nombre + " " + Lista_personas[i].apellido_pat + " " + Lista_personas[i].apellido_mat;

                        rowsaffected = comando.ExecuteNonQuery();
                        resultado = true;

                        comando.Parameters.Clear();
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
                return resultado;
            }

        }
    }
}
