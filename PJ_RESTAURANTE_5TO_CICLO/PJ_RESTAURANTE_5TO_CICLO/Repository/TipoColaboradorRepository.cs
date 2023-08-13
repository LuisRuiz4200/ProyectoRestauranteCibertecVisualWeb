using PJ_RESTAURANTE_5TO_CICLO.Conexion;
using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using System.Data.SqlClient;

namespace PJ_RESTAURANTE_5TO_CICLO.Repository
{
    public class TipoColaboradorRepository : SqlServer, ITipoColaborador
    {

        public List<TipoColaborador> listar()
        {

            List<TipoColaborador> lista = new List<TipoColaborador> ();

            string cadena_sql = "select * from tb_tipo_colaborador";

            using (SqlConnection conn = new SqlConnection(bd_restaurante_5to_ciclo()))
            {
                SqlCommand cmd = new SqlCommand(cadena_sql,conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read()) 
                {
                    TipoColaborador obj = new TipoColaborador();

                    obj.id_tipo_colaborador = dr.GetInt32(0);
                    obj.des_tipo_colaborador = dr.GetString(1);

                    lista.Add(obj);
                }
            }

            return lista;
        }

        public string agregar(TipoColaborador entity)
        {
            throw new NotImplementedException();
        }

        public TipoColaborador buscar(int id)
        {
            throw new NotImplementedException();
        }

        public string editar(TipoColaborador entity)
        {
            throw new NotImplementedException();
        }

        public string eliminar(int id)
        {
            throw new NotImplementedException();
        }

    }
}
