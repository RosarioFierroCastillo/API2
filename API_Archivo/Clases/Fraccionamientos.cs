using MySql.Data.MySqlClient;

namespace API_Archivo.Clases
{
    public class Fraccionamientos
    {

        public int id_fraccionamiento { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string coordenadas { get; set; }
        public int id_administrador { get; set; }
        public int id_tesorero { get; set; }


        public bool Agregar_Fraccionamiento(string nombre, string direccion, string coordenadas, int id_administrador, int id_tesorero)
        {

            bool fraccionamiento_agregado = false;
            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into fraccionamientos (Nombre_fraccionamiento, Direccion, Coordenadas, id_administrador, id_tesorero) VALUES (@Nombre_fraccionamiento, @Direccion, @Coordenadas, @id_administrador, @id_tesorero)", conexion);

                //Nombre_fraccionamiento=@Nombre_fraccionamiento, Direccion=@Direccion, Coordenadas=@Coordenadas, id_administrador=@id_administrador, id_tesorero=@id_tesorero)

                comando.Parameters.Add("@Nombre_fraccionamiento", MySqlDbType.VarChar).Value = nombre;
                comando.Parameters.Add("@Direccion", MySqlDbType.VarChar).Value = direccion;
                comando.Parameters.Add("@Coordenadas", MySqlDbType.VarChar).Value = coordenadas;
                comando.Parameters.Add("@id_administrador", MySqlDbType.Int32).Value = id_administrador;
                comando.Parameters.Add("@id_tesorero", MySqlDbType.Int32).Value = id_tesorero;

                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        fraccionamiento_agregado = true;
                    }

                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
                finally
                {

                }

                return fraccionamiento_agregado;
            }
        }

        public bool Eliminar_Fraccionamiento(int id_fraccionamiento)
        {
            bool Fraccionamiento_eliminado = false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM fraccionamientos WHERE id_Fraccionamiento=@id_fraccionamiento", conexion);

                //Nombre_fraccionamiento=@Nombre_fraccionamiento, Direccion=@Direccion, Coordenadas=@Coordenadas, id_administrador=@id_administrador, id_tesorero=@id_tesorero)

                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;

                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Fraccionamiento_eliminado = true;
                    }

                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
                finally
                {

                }

                return Fraccionamiento_eliminado;
            }

        }


        public bool Actualizar_Fraccionamiento(int id_fraccionamiento, string nombre, string direccion, string coordenadas, int id_administrador, int id_tesorero)
        {
            bool Fraccionamiento_actualizado=false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE fraccionamientos " +
                    "SET Nombre_fraccionamiento=@Nombre_fraccionamiento, Direccion=@Direccion, Coordenadas=@Coordenadas, id_administrador=@id_administrador, id_tesorero=@id_tesorero " +
                    "WHERE id_fraccionamiento=@id_fraccionamiento", conexion);


                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                comando.Parameters.Add("@Nombre_fraccionamiento", MySqlDbType.VarChar).Value = nombre;
                comando.Parameters.Add("@Direccion", MySqlDbType.VarChar).Value = direccion;
                comando.Parameters.Add("@Coordenadas", MySqlDbType.VarChar).Value = coordenadas;
                comando.Parameters.Add("@id_administrador", MySqlDbType.Int32).Value = id_administrador;
                comando.Parameters.Add("@id_tesorero", MySqlDbType.Int32).Value = id_tesorero;


                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Fraccionamiento_actualizado = true;
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
                return Fraccionamiento_actualizado;

            }
        }


        public List<Fraccionamientos> Consultar_Fraccionamiento(int id_fraccionamiento)
        {
            List<Fraccionamientos> fraccionamiento = new List<Fraccionamientos>();

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM fraccionamientos WHERE id_Fraccionamiento=@id_fraccionamiento", conexion);

                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        fraccionamiento.Add(new Fraccionamientos() {id_fraccionamiento=reader.GetInt32(0), nombre=reader.GetString(1), direccion=reader.GetString(2), coordenadas=reader.GetString(3), id_administrador=reader.GetInt32(4), id_tesorero=reader.GetInt32(5) });
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

                return fraccionamiento;
            }



        }



    }
}
