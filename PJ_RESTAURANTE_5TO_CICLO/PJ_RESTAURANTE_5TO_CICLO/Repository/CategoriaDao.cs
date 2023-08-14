
using Newtonsoft.Json;
using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;

namespace PJ_RESTAURANTE_5TO_CICLO.Repository
{
    public class CategoriaDao : ICategoria
    {
        public Task<List<CategoriaProducto>> GetCategoriaProductos()
        {
            return getCategoriaProductos();
        }

        async Task<List<CategoriaProducto>> getCategoriaProductos()
        {
            List<CategoriaProducto> lista = new List<CategoriaProducto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/categoria/");
                HttpResponseMessage mensaje = await client.GetAsync("getCategoria");
                string cadena = await mensaje.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<CategoriaProducto>>(cadena).Select(
                c => new CategoriaProducto
                {
                    id_categoria_producto = c.id_categoria_producto,
                    des_categoria_producto = c.des_categoria_producto,
                }).ToList();
            }
            return lista; 
        }
    }
}
