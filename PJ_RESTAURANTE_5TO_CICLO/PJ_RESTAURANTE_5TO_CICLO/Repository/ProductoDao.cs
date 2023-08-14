
using Newtonsoft.Json;
using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;

namespace PJ_RESTAURANTE_5TO_CICLO.Repository
{
    public class ProductoDao : IProducto
    {
        public Task<List<Producto>> GetProductosPortal()
        {
            return getProductoPortal();
        }
        public Task<List<Producto>> GetProductos()
        {
            return getProductos();
        }

        public Task<Producto> BuscarAsync(int id)
        {
            return buscarAsync(id);
        }

        private async Task<List<Producto>> getProductos()
        {
            List<Producto> lista = new List<Producto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/producto/");
                HttpResponseMessage mensaje = await client.GetAsync("getProductos");
                string cadena = await mensaje.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Producto>>(cadena).Select(
                p => new Producto
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
        }

        private async Task<List<Producto>> getProductoPortal()
        {
            List<Producto> pro = new List<Producto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/producto/"); //TODO
                HttpResponseMessage mensaje = await client.GetAsync("getProductosPortal");
                string cadena = await mensaje.Content.ReadAsStringAsync();
                pro = JsonConvert.DeserializeObject<List<Producto>>(cadena).Select(
                    p => new Producto
                    {
                        id_producto = p.id_producto,
                        nom_producto = p.nom_producto,
                        des_producto = p.des_producto,
                        id_categoria_producto = p.id_categoria_producto,
                        preciouni_producto = p.preciouni_producto,
                        stock_producto = p.stock_producto,
                    }).ToList();
            }
            return pro;
        }

        private async Task<Producto> buscarAsync(int id)
        {
            List<Producto> productos = await getProductoPortal();
            var producto = productos.Where(p => p.id_producto == id).FirstOrDefault();
            if (producto == null)
            {
                producto = new Producto();
            }
            return producto;
        }
    }
}
