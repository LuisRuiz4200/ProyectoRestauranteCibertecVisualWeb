using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Restaurante_1.Models;

namespace Restaurante_1.Controllers
{
	[Route("polleria/[controller]")]
	[ApiController]
	public class APIPolleriaController : ControllerBase
	{
		//string cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("connection");
		// server = .; dataBase = BD_RESTAURANTE_5TO_CICLO_1; Trusted_Connection = True; Encrypt = False;
		string cadena = @"server = .; dataBase = BD_RESTAURANTE_5TO_CICLO_1; Trusted_Connection=True; MultipleActiveResultSets=True; TrustServerCertificate=False; Encrypt=False";
		IEnumerable<tb_categoria_producto> getCategoriaProductos()
		{
			List<tb_categoria_producto> lista = new List<tb_categoria_producto>();
			using (SqlConnection cn = new SqlConnection(cadena))
			{
				cn.Open();
				SqlCommand cmd = new SqlCommand("select * from tb_categoria_producto", cn);
				SqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					lista.Add(new tb_categoria_producto()
					{
						id_categoria_producto = dr.GetInt32(0),
						des_categoria_producto = dr.GetString(1)
					});
				}
				cn.Close();
			}
			return lista;
		} //fin de getCategoriaProductos

		IEnumerable<tb_producto> getProductos()
		{
			List<tb_producto> lista = new List<tb_producto>();
			using (SqlConnection cn = new SqlConnection(cadena))
			{
				cn.Open();
				SqlCommand cmd = new SqlCommand("select * from tb_producto", cn);
				SqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					//string imagen = (byte[])dr.GetValue(6); //columna 6 que contiene la imagen
					lista.Add(new tb_producto()
					{
						id_producto = dr.GetInt32(0),
						id_categoria_producto = dr.GetInt32(1),
						nom_producto = dr.GetString(2),
						des_producto = dr.GetString(3),
						preciouni_producto = dr.GetDecimal(4),
						stock_producto = dr.GetInt32(5)
					});
				}
			}
			return lista;
		} //fin de getProductos

		IEnumerable<tb_producto> getProductosById(int id)
		{
			List<tb_producto> lista = new List<tb_producto>();
			using (SqlConnection cn = new SqlConnection(cadena))
			{
				cn.Open();
				SqlCommand cmd = new SqlCommand($"select * from tb_producto where id_producto = {id}", cn);
				SqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					//string imagen = (byte[])dr.GetValue(6); //columna 6 que contiene la imagen
					lista.Add(new tb_producto()
					{
						id_producto = dr.GetInt32(0),
						id_categoria_producto = dr.GetInt32(1),
						nom_producto = dr.GetString(2),
						des_producto = dr.GetString(3),
						preciouni_producto = dr.GetDecimal(4),
						stock_producto = dr.GetInt32(5)
					});
				}
			}
			return lista;
		} //fin de getProductos



		// Dentro de apiPolleriaController
		[HttpGet("categoriaspro")]
		public async Task<ActionResult<IEnumerable<tb_categoria_producto>>> categorias()
		{
			return Ok(await Task.Run(() => getCategoriaProductos()));
		} // fin de categorias()

		[HttpGet("productos")]
		public async Task<ActionResult<IEnumerable<tb_producto>>> mproductos()
		{
			return Ok(await Task.Run(() => getProductos()));
		} // fin de productos()

		[HttpGet("productosbyid")]
		public async Task<ActionResult<IEnumerable<tb_producto>>> mproductos(int id)
		{
			return Ok(await Task.Run(() => getProductos().Where(item => item.id_producto == id).FirstOrDefault()));
		} // fin de productos()
	}
}
