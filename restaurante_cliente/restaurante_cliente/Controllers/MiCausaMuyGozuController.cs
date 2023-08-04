using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using restaurante_cliente.Models;

namespace restaurante_cliente.Controllers
{
	public class MiCausaMuyGozuController : Controller
	{
		async Task<List<tb_categoria_producto>> getCategoriaProductos()
		{
			List<tb_categoria_producto> lista = new List<tb_categoria_producto>();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:7207/polleria/APIPolleria/");
				HttpResponseMessage mensaje = await client.GetAsync("categoriaspro");
				string cadena = await mensaje.Content.ReadAsStringAsync();
				lista = JsonConvert.DeserializeObject<List<tb_categoria_producto>>(cadena).Select(
				c => new tb_categoria_producto
				{
					id_categoria_producto = c.id_categoria_producto,
					des_categoria_producto = c.des_categoria_producto,
				}).ToList();
			}
			return lista;
		}//Fin de getCategoriaProductos

		async Task<List<tb_producto>> getProductos()
		{
			List<tb_producto> lista = new List<tb_producto>();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:7207/polleria/APIPolleria/");
				HttpResponseMessage mensaje = await client.GetAsync("productos");
				string cadena = await mensaje.Content.ReadAsStringAsync();
				lista = JsonConvert.DeserializeObject<List<tb_producto>>(cadena).Select(
				p => new tb_producto
				{
					id_producto = p.id_producto,
					id_categoria_producto = p.id_categoria_producto,
					nom_producto = p.nom_producto,
					des_producto = p.des_producto,
					preciouni_producto = p.preciouni_producto,
					stock_producto = p.stock_producto
				}).ToList();
			}
			return lista;
		}//Fin de getProductos


		public async Task<IActionResult> Index()
		{
			return View(await getProductos());
		}
	}
}
