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
                "@dni_usuario,@email_usuario,@password_usuario,null,@fechareg_usuario,@fechaact_usuario,@estado_usuario)";
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
                    cmd.Parameters.AddWithValue("@dir_usuario", entity.dir_distrito);
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
