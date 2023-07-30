using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using System.Data.SqlClient;
using System.Data;

namespace PJ_RESTAURANTE_5TO_CICLO.Repository
{
    public class UsuarioRepository : IUsuario
    {

        string? cadena_connection = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("connection1");

        public string agregar(Usuario entity)
        {

            string cadena_sql = "insert into tb_usuario values (@id_tipo_usuario,@cod_usuario,@nom_usuario,@ape_usuario,@tel_usuario,@cel_usuario,@id_distrito,@dir_usuario," +
                "@dni_usuario,@email_usuario,@password_usuario,@imagen_usuario,@fechareg_usuario,@fechaact_usuario,@estado_usuario)";
            string mensaje = "";

            try 
            {
                using (SqlConnection con = new SqlConnection(cadena_connection))
                {
                    SqlCommand cmd = new SqlCommand(cadena_sql,con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_tipo_usuario", entity.id_tipo_usuario);
                    cmd.Parameters.AddWithValue("@cod_usuario", entity.cod_usuario);
                    cmd.Parameters.AddWithValue("@nom_usuario", entity.nom_usuario);
                    cmd.Parameters.AddWithValue("@ape_usuario", entity.ape_usuario);
                    cmd.Parameters.AddWithValue("@tel_usuario", entity.tel_usuario);
                    cmd.Parameters.AddWithValue("@cel_usuario", entity.cel_usuario);
                    cmd.Parameters.AddWithValue("@id_distrito", entity.id_distrito);
                    cmd.Parameters.AddWithValue("@dir_usuario", entity.dir_usuario);
                    cmd.Parameters.AddWithValue("@dni_usuario",entity.dni_usuario);
                    cmd.Parameters.AddWithValue("@email_usuario", entity.email_usuario);
                    cmd.Parameters.AddWithValue("@password_usuario", entity.password_usuario);
                    cmd.Parameters.AddWithValue("@imagen_usuario",entity.imagen_usuario);
                    cmd.Parameters.AddWithValue("@fechareg_usuario", entity.fechareg_usuario);
                    cmd.Parameters.AddWithValue("@fechaact_usuario", entity.fechaact_usuario);
                    cmd.Parameters.AddWithValue("@estado_usuario", entity.estado_usuario);

                    con.Open();

                    int nroRegistros = cmd.ExecuteNonQuery();

                    mensaje = $"Se insertó {nroRegistros} registros";
                }
            }
            catch (Exception ex) 
            {
                mensaje = ex.Message;
            }
            

            return mensaje;
        }

        public Usuario buscar(int id)
        {
            Usuario obj = new Usuario();

            using (SqlConnection cn = new SqlConnection(cadena_connection))
            {
                SqlCommand cmd = new SqlCommand("select * from tb_usuario where id_usuario = @id_usuario", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_usuario",id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    obj.id_usuario = dr.GetInt32(0);
                    obj.id_tipo_usuario = dr.GetInt32(1);
                    obj.cod_usuario = dr.GetString(2);
                    obj.nom_usuario = dr.GetString(3);
                    obj.ape_usuario = dr.GetString(4);
                    obj.tel_usuario = dr.GetString(5);
                    obj.cel_usuario = dr.GetString(6);
                    obj.id_distrito = dr.GetInt32(7);
                    obj.dir_usuario = dr.GetString(8);
                    obj.dni_usuario = dr.GetString(9);
                    obj.email_usuario = dr.GetString(10);
                    obj.password_usuario = dr.GetString(11);
                    obj.imagen_usuario = (byte[]?)dr.GetSqlBinary(12);
                    obj.fechareg_usuario = dr.GetDateTime(13);
                    obj.fechaact_usuario = dr.GetDateTime(14);
                    obj.estado_usuario = dr.GetString(15);

                }

            }

            return obj;
        }
    

        public string editar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public string eliminar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection cn = new SqlConnection(cadena_connection))
            {
                SqlCommand cmd = new SqlCommand("select * from tb_usuario", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario obj = new Usuario();
                    obj.id_usuario = dr.GetInt32(0);
                    obj.id_tipo_usuario = dr.GetInt32(1);
                    obj.cod_usuario = dr.GetString(2);
                    obj.nom_usuario = dr.GetString(3);
                    obj.ape_usuario = dr.GetString(4);
                    obj.tel_usuario=dr.GetString(5);
                    obj.cel_usuario=dr.GetString(6);
                    obj.id_distrito = dr.GetInt32(7);
                    obj.dir_usuario = dr.GetString(8);
                    obj.dni_usuario = dr.GetString(9);
                    obj.email_usuario = dr.GetString(10);
                    obj.password_usuario = dr.GetString(11);
                    obj.imagen_usuario = (byte[]?)dr.GetSqlBinary(12);
                    obj.fechareg_usuario = dr.GetDateTime(13);
                    obj.fechaact_usuario = dr.GetDateTime(14);
                    obj.estado_usuario = dr.GetString(15);

                    lista.Add(obj);
                }

            }

            return lista;
        }
    }
}
