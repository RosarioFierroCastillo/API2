using MySql.Data.MySqlClient;

namespace API_Archivo.Clases
{
    public class Personas
    {

        public int id_persona { get; set; }
        public string nombre {  get; set; }
        public string apellido_pat {  get; set; }
        public string apellido_mat { get; set;}
        public string telefono {  get; set; }
        public string tipo_usuario {  get; set; }
        public int id_fraccionamiento {  get; set; }
        public int lote {  get; set; }
        public string intercomunicador {  get; set; }
        public string codigo_acceso {get; set;}

        public string correo { get; set; }
        


        public bool Agregar_Persona(string nombre, string apellido_pat, string apellido_mat, string telefono, string fecha_nacimiento, string tipo_usuario, int id_fraccionamiento, int id_lote, string intercomunicador, string codigo_acceso,string correo,string contrasenia)
        {
            bool Persona_agregada=false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into personas (Nombre, Apellido_pat, Apellido_mat, Telefono, Fecha_nacimiento, Tipo_usuario, id_fraccionamiento, id_lote, Intercomunicador, Codigo_acceso,Correo, Contrasenia) VALUES ( @Nombre, @Apellido_pat, @Apellido_mat, @Telefono, @Fecha_nacimiento, @Tipo_usuario, @id_fraccionamiento, @id_lote, @Intercomunicador, @Codigo_acceso,@Correo, @Contrasenia)", conexion);

                //@Nombre, @Apellido_pat, @Apellido_mat, @Telefono, @Fecha_nacimiento, @Tipo_usuario, @id_fraccionamiento, @id_lote, @Intercomunicador, @Codigo_acceso

                comando.Parameters.Add("@Nombre", MySqlDbType.VarChar).Value = nombre;
                comando.Parameters.Add("@Apellido_pat", MySqlDbType.VarChar).Value = apellido_pat;
                comando.Parameters.Add("@Apellido_mat", MySqlDbType.VarChar).Value = apellido_mat;
                comando.Parameters.Add("@Telefono", MySqlDbType.VarChar).Value = telefono;
                comando.Parameters.Add("@Fecha_nacimiento", MySqlDbType.Date).Value = fecha_nacimiento;
                comando.Parameters.Add("@Tipo_usuario", MySqlDbType.VarChar).Value = tipo_usuario;
                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                comando.Parameters.Add("@id_lote", MySqlDbType.Int32).Value = id_lote;
                comando.Parameters.Add("@Intercomunicador", MySqlDbType.VarChar).Value = intercomunicador;
                comando.Parameters.Add("@Codigo_acceso", MySqlDbType.VarChar).Value = codigo_acceso;
                comando.Parameters.Add("@Correo", MySqlDbType.VarChar).Value = correo;
                comando.Parameters.Add("@Contrasenia", MySqlDbType.VarChar).Value = contrasenia;




                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Persona_agregada = true;
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
                return Persona_agregada;

            }
        }


        public bool Eliminar_Persona(int id_persona)
        {
            bool Persona_eliminada = false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM personas WHERE id_Persona==@id_persona", conexion);

                //@Nombre, @Apellido_pat, @Apellido_mat, @Telefono, @Fecha_nacimiento, @Tipo_usuario, @id_fraccionamiento, @id_lote, @Intercomunicador, @Codigo_acceso

                comando.Parameters.Add("@id_persona", MySqlDbType.VarChar).Value = id_persona;




                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Persona_eliminada = true;
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
                return Persona_eliminada;

            }
        }


        public bool Actualizar_Persona(int id_persona,string nombre, string apellido_pat, string apellido_mat, string telefono, string fecha_nacimiento, string tipo_usuario, int id_fraccionamiento, int id_lote, string intercomunicador, string codigo_acceso, string correo, string contrasenia)
        {

            bool Persona_actualizada = false;

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE personas " +
                    "SET Nombre=@Nombre, Apellido_pat=@Apellido_pat,Apellido_mat=@Apellido_mat, Telefono=@Telefono, Fecha_nacimiento=@Fecha_nacimiento, Tipo_usuario=@Tipo_usuario, id_lote=@id_lote, Intercomunicador=@Intercomunicador, Codigo_acceso=@Codigo_acceso, Correo=@Correo, Contrasenia=@Contrasenia " +
                    "WHERE id_Persona=@id_persona && id_fraccionamiento=@id_fraccionamiento", conexion);

                comando.Parameters.Add("@id_persona", MySqlDbType.Int32).Value = id_persona;

                comando.Parameters.Add("@Nombre", MySqlDbType.VarChar).Value = nombre;
                comando.Parameters.Add("@Apellido_pat", MySqlDbType.VarChar).Value = apellido_pat;
                comando.Parameters.Add("@Apellido_mat", MySqlDbType.VarChar).Value = apellido_mat;
                comando.Parameters.Add("@Telefono", MySqlDbType.VarChar).Value = telefono;
                comando.Parameters.Add("@Fecha_nacimiento", MySqlDbType.Date).Value = fecha_nacimiento;
                comando.Parameters.Add("@Tipo_usuario", MySqlDbType.VarChar).Value = tipo_usuario;
                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                comando.Parameters.Add("@id_lote", MySqlDbType.Int32).Value = id_lote;
                comando.Parameters.Add("@Intercomunicador", MySqlDbType.VarChar).Value = intercomunicador;
                comando.Parameters.Add("@Codigo_acceso", MySqlDbType.VarChar).Value = codigo_acceso;
                comando.Parameters.Add("@Correo", MySqlDbType.VarChar).Value = correo;
                comando.Parameters.Add("@Contrasenia", MySqlDbType.VarChar).Value = contrasenia;


                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        Persona_actualizada = true;
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
                return Persona_actualizada;

            }

        }




        public List<Personas> Iniciar_Sesion(string correo, string contrasenia)
        {
            List<Personas> Persona = new List<Personas>();

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM personas WHERE Correo=@Correo && Contrasenia=@Contrasenia", conexion);

                comando.Parameters.Add("@Correo", MySqlDbType.Int32).Value = correo;
                comando.Parameters.Add("@Contrasenia", MySqlDbType.Int32).Value = contrasenia;


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Persona.Add(new Personas() { id_persona = reader.GetInt32(0), nombre=reader.GetString(1), apellido_pat=reader.GetString(2), apellido_mat=reader.GetString(3), telefono = reader.GetString(4), tipo_usuario=reader.GetString(6), id_fraccionamiento=reader.GetInt32(7), lote=reader.GetInt32(8), intercomunicador=reader.GetString(9), codigo_acceso=reader.GetString(10), correo=reader.GetString(11) });
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

                return Persona;
            }
        }

        public List<Personas> Consultar_Persona(string nombre, string apellido_pat, string apellido_mat)
        {
            List<Personas> Persona = new List<Personas>();

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM personas WHERE Nombre=@Nombre && Apellido_pat=@Apellido_pat && Apellido_mat=@Apellido_mat", conexion);

                comando.Parameters.Add("@Nombre", MySqlDbType.Int32).Value = nombre;
                comando.Parameters.Add("@Apellido_pat", MySqlDbType.Int32).Value = apellido_pat;
                comando.Parameters.Add("@Apellido_mat", MySqlDbType.Int32).Value = apellido_mat;


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Persona.Add(new Personas() { id_persona = reader.GetInt32(0), nombre = reader.GetString(1), apellido_pat = reader.GetString(2), apellido_mat = reader.GetString(3), telefono = reader.GetString(4), tipo_usuario = reader.GetString(6), id_fraccionamiento = reader.GetInt32(7), lote = reader.GetInt32(8), intercomunicador = reader.GetString(9), codigo_acceso = reader.GetString(10), correo = reader.GetString(11) });
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

                return Persona;
            }
        }

        public List<Personas> Consultar_Personas_Por_Fraccionamiento(int id_fraccionamiento)
        {
            List<Personas> Lista_Personas = new List<Personas>();

            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM personas WHERE id_fraccionamiento=@id_fraccionamiento", conexion);

                comando.Parameters.Add("@id_fraccionamiento", MySqlDbType.Int32).Value = id_fraccionamiento;
                


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Lista_Personas.Add(new Personas() { id_persona = reader.GetInt32(0), nombre = reader.GetString(1), apellido_pat = reader.GetString(2), apellido_mat = reader.GetString(3), telefono = reader.GetString(4), tipo_usuario = reader.GetString(6), id_fraccionamiento = reader.GetInt32(7), lote = reader.GetInt32(8), intercomunicador = reader.GetString(9), codigo_acceso = reader.GetString(10), correo = reader.GetString(11) });
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

                return Lista_Personas;
            }
        }

        public string Obtener_Correo_Persona(int id_persona)
        {
            string correo = "";
            using (MySqlConnection conexion = new MySqlConnection(Global.cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT Correo FROM personas WHERE id_Persona=@id_Persona", conexion);

                comando.Parameters.Add("@id_Persona", MySqlDbType.Int32).Value = id_persona;


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    if(reader.Read())
                    {
                        correo= reader.GetString(0);
                    }
                    else { 
                        correo= "";
                    }


                }
                catch (MySqlException ex)
                {

                }
                finally
                {
                    conexion.Close();
                }

                return correo;
            }
        }
    }

}
