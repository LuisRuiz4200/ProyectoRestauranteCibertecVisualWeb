using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using System.Data.SqlClient;
using System.Data;
using PJ_RESTAURANTE_5TO_CICLO.Conexion;

namespace PJ_RESTAURANTE_5TO_CICLO.Repository
{
    public class ColaboradorRepository : SqlServer, IColaborador
    {

        public string agregar(Colaborador entity)
        {
            string cadena_sql = "insert into tb_colaborador values (@id_tipo_colaborador, @nom_colaborador, @ape_colaborador, @dni_colaborador, @imagen_colaborador, @fechareg_colaborador, @fechaact_colaborador, @estado_colaborador)";
            string mensaje = "";

            try
            {
                using (SqlConnection con = new SqlConnection(bd_restaurante_5to_ciclo()))
                {
                    SqlCommand cmd = new SqlCommand(cadena_sql, con);

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@id_tipo_colaborador", entity.id_tipo_colaborador);
                    cmd.Parameters.AddWithValue("@nom_colaborador", entity.nom_colaborador);
                    cmd.Parameters.AddWithValue("@ape_colaborador", entity.ape_colaborador);
                    cmd.Parameters.AddWithValue("@dni_colaborador", entity.dni_colaborador);
                    cmd.Parameters.AddWithValue("@imagen_colaborador", entity.imagen_colaborador);
                    cmd.Parameters.AddWithValue("@fechareg_colaborador", entity.fechaact_colaborador);
                    cmd.Parameters.AddWithValue("@fechaact_colaborador",entity.fechaact_colaborador);
                    cmd.Parameters.AddWithValue("@estado_colaborador", entity.estado_colaborador);

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

        public Colaborador? buscar(int id)
        {
            Colaborador? obj = null;

            using (SqlConnection cn = new SqlConnection(bd_restaurante_5to_ciclo()))
            {
                SqlCommand cmd = new SqlCommand("select * from tb_colaborador where id_colaborador = @id_colaborador", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_colaborador",id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = new Colaborador();

                    obj.id_colaborador = dr.GetInt32(0);
                    obj.id_tipo_colaborador = dr.GetInt32(1);
                    obj.nom_colaborador = dr.GetString(2);
                    obj.ape_colaborador = dr.GetString(3);
                    obj.dni_colaborador = dr.GetString(4);
                    obj.imagen_colaborador = (byte[]?)dr.GetSqlBinary(5);
                    obj.fechareg_colaborador = dr.GetDateTime(6);
                    obj.fechaact_colaborador = dr.GetDateTime(7);
                    obj.estado_colaborador = dr.GetString(8);

                }

            }

            return obj;
        }

        public string editar(Colaborador entity)
        {
            string cadena_sql = "update tb_colaborador set id_tipo_colaborador=@id_tipo_colaborador, nom_colaborador = @nom_colaborador, ape_colaborador=@ape_colaborador, dni_colaborador =@dni_colaborador, " +
                "imagen_colaborador=@imagen_colaborador, fechareg_colaborador= @fechareg_colaborador, fechaact_colaborador=@fechaact_colaborador, estado_colaborador=@estado_colaborador " +
                "where id_colaborador = @id_colaborador";
            string mensaje = "";

            try
            {
                using (SqlConnection con = new SqlConnection(bd_restaurante_5to_ciclo()))
                {
                    SqlCommand cmd = new SqlCommand(cadena_sql, con);

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@id_colaborador", entity.id_colaborador);
                    cmd.Parameters.AddWithValue("@id_tipo_colaborador", entity.id_tipo_colaborador);
                    cmd.Parameters.AddWithValue("@nom_colaborador", entity.nom_colaborador);
                    cmd.Parameters.AddWithValue("@ape_colaborador", entity.ape_colaborador);
                    cmd.Parameters.AddWithValue("@dni_colaborador", entity.dni_colaborador);
                    cmd.Parameters.AddWithValue("@imagen_colaborador", entity.imagen_colaborador);
                    cmd.Parameters.AddWithValue("@fechareg_colaborador", entity.fechaact_colaborador);
                    cmd.Parameters.AddWithValue("@fechaact_colaborador", entity.fechaact_colaborador);
                    cmd.Parameters.AddWithValue("@estado_colaborador",entity.estado_colaborador);


                    con.Open();

                    int nroRegistros = cmd.ExecuteNonQuery();

                    mensaje = $"Se actualizó {nroRegistros} registros";
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }


            return mensaje;
        }

        public string eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Colaborador> listar()
        {
            List<Colaborador> lista = new List<Colaborador>();

            using (SqlConnection cn = new SqlConnection(bd_restaurante_5to_ciclo()))
            {
                SqlCommand cmd = new SqlCommand("select * from tb_colaborador", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Colaborador obj = new Colaborador();

                    obj.id_colaborador = dr.GetInt32(0);
                    obj.id_tipo_colaborador = dr.GetInt32(1);
                    obj.nom_colaborador = dr.GetString(2);
                    obj.ape_colaborador = dr.GetString(3);
                    obj.dni_colaborador = dr.GetString(4);
                    obj.imagen_colaborador = (byte[]?)dr.GetSqlBinary(5);
                    obj.fechareg_colaborador = dr.GetDateTime(6);
                    obj.fechaact_colaborador = dr.GetDateTime(7);
                    obj.estado_colaborador = dr.GetString(8);

                    lista.Add(obj);
                }

            }

            return lista;
        }
    }
}
