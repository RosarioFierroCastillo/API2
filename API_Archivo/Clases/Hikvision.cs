using CardManagement;
using MySql.Data.MySqlClient;

namespace API_Archivo.Clases
{
    public class Hikvision
    {
        public int id_controlador { get; set; }
        public int id_administrador { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string port { get; set; }
        public string ip { get; set; }


        public bool InsertHikvision(int id_controlador, int id_fraccionamiento, string user, string password, string port, string ip)
        {

            bool res = AddDevice.Login(user, password, port, ip);

            if (res == true)
            {
                using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
                {
                    //  res = false;
                    int rowsaffected = 0;

                    MySqlCommand comando = new MySqlCommand("select id_fraccionamiento from controlador where id_fraccionamiento = @id_fraccionamiento;", conexion);
                    comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;


                    try
                    {

                        conexion.Open();

                        MySqlDataReader reader = comando.ExecuteReader();

                        if (reader.Read())
                        {
                            res = false;
                        }


                    }
                    catch (MySqlException ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }


                    conexion.Close();
                    if (res == true)
                    {

                        conexion.Open();
                        res = false;
                        comando = new MySqlCommand("insert into controlador (id_controlador, id_fraccionamiento, user, password, port, ip) values(@id_controlador, @id_fraccionamiento, @user, @password, @port, @ip);", conexion);

                        comando.Parameters.Add("@id_controlador", MySqlDbType.Int32).Value = id_controlador;
                        comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                        comando.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;
                        comando.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                        comando.Parameters.Add("@port", MySqlDbType.VarChar).Value = port;
                        comando.Parameters.Add("@ip", MySqlDbType.VarChar).Value = ip;


                        try
                        {
                            //  conexion.Open();
                            rowsaffected = comando.ExecuteNonQuery();

                            if (rowsaffected >= 1)
                            {
                                res = true;
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
                    }


                }

            }

            return res;
        }
    }
}
