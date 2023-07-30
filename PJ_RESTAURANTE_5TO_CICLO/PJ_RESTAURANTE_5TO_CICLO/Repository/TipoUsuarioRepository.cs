using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using System.Data.SqlClient;

namespace PJ_RESTAURANTE_5TO_CICLO.Repository
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        string? cadena_connection = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("connection1");

        public string agregar(TipoUsuario entity)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario buscar(int id)
        {
            throw new NotImplementedException();
        }

        public string editar(TipoUsuario entity)
        {
            throw new NotImplementedException();
        }

        public string eliminar(TipoUsuario entity)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuario> listar()
        {
            List<TipoUsuario> lista = new List<TipoUsuario>();

            using (SqlConnection cn = new SqlConnection(cadena_connection))
            {
                SqlCommand cmd = new SqlCommand("select * from tb_tipo_usuario",cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    TipoUsuario obj = new TipoUsuario();
                    obj.id_tipo_usuario = dr.GetInt32(0);
                    obj.des_tipo_usuario= dr.GetString(1);

                    lista.Add(obj);
                }

            }    

            return lista;
        }
    }
}
