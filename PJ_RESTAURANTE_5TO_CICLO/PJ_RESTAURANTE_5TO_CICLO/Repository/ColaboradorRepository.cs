using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using System.Data.SqlClient;
using System.Data;

namespace PJ_RESTAURANTE_5TO_CICLO.Repository
{
    public class ColaboradorRepository : IColaborador
    {
        string? cadena_connection = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("connection1");

        public string agregar(Colaborador entity)
        {
            string cadena_sql = "insert into tb_colaborador values (@nom_colaborador, @ape_colaborador, @dni_colaborador, @imagen_colaborador, @fechareg_colaborador, @fechaact_colaborador, @estado_colaborador)";
            string mensaje = "";

            try
            {
                using (SqlConnection con = new SqlConnection(cadena_connection))
                {
                    SqlCommand cmd = new SqlCommand(cadena_sql, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@nom_colaborador", entity.nom_colaborador);
                    cmd.Parameters.AddWithValue("@ape_colaborador", entity.ape_colaborador);
                    cmd.Parameters.AddWithValue("@dni_colaborador", entity.dni_colaborador);
                    cmd.Parameters.AddWithValue("@imagen_colaborador", entity.imagen_colaborador);
                    cmd.Parameters.AddWithValue("@fechareg_colaborador", entity.fechaact_colaborador);
                    cmd.Parameters.AddWithValue("@fechaact_colaborador",entity.fechaact_colaborador);
                    

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

        public Colaborador buscar(int id)
        {
            throw new NotImplementedException();
        }

        public string editar(Colaborador entity)
        {
            throw new NotImplementedException();
        }

        public string eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Colaborador> listar()
        {
            throw new NotImplementedException();
        }
    }
}
