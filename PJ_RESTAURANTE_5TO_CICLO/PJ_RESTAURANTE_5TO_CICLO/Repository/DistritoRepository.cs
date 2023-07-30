using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using System.Data.SqlClient;

namespace PJ_RESTAURANTE_5TO_CICLO.Repository
{
    public class DistritoRepository : IDistrito
    {
        string? cadena_connection = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("connection1");
        public string agregar(Distrito entity)
        {
            throw new NotImplementedException();
        }

        public Distrito buscar(int id)
        {
            throw new NotImplementedException();
        }

        public string editar(Distrito entity)
        {
            throw new NotImplementedException();
        }

        public string eliminar(Distrito entity)
        {
            throw new NotImplementedException();
        }

        public List<Distrito> listar()
        {
            List<Distrito> lista = new List<Distrito>();
            using (SqlConnection con = new SqlConnection(cadena_connection))
            {
                SqlCommand cmd = new SqlCommand("Select * from tb_distrito",con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    Distrito obj = new Distrito();
                    obj.id_distrito = dr.GetInt32(0);
                    obj.des_distrito = dr.GetString(1);

                    lista.Add(obj);
                }
            }

            return lista;
        }
    }
}
