
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using PJ_RESTAURANTE_5TO_CICLO.Repository;

namespace PJ_RESTAURANTE_5TO_CICLO.Controllers
{
    public class ProductoController : Controller
    {
        private IProducto iProducto = new ProductoDao();
        private ICategoria iCategoria = new CategoriaDao();

        //ProductoController()
        //{
        //    iProducto = 
        //    iCategoria = 
        //}

        public async Task<IActionResult> Index()
        {
            return View(await iProducto.GetProductos());
        }

        public async Task<IActionResult> Agregar(int id = 0)
        {
            return View(await Task.Run(() => iProducto.BuscarAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(int idproducto, int cantidad)
        {
            //buscar al registro de producto por idproducto
            List<Producto> productos = await iProducto.GetProductosPortal();
            Producto reg = productos.FirstOrDefault(p => p.id_producto == idproducto)!;

            //instanciar Registro y pasar sus datos
            ItemProductoModel it = new()
            {
                id_producto = idproducto,
                nom_producto = reg.nom_producto,
                des_producto = reg.des_producto,
                des_categoria_producto = reg.id_categoria_producto.ToString(),
                preciouni_producto = reg.preciouni_producto,
                stock_producto = cantidad
            };

            //deserializar la Sesion canasta y lo almaceno en temporal
            List<ItemProductoModel> temporal = JsonConvert.DeserializeObject<List<ItemProductoModel>>(HttpContext.Session.GetString("Canasta")!)!;
            temporal.Add(it);

            //volver a serializar almacenando el Session
            HttpContext.Session.SetString("Canasta", JsonConvert.SerializeObject(temporal));
            ViewBag.mensaje = "Producto Agregado";
            return View(reg);
        }

        public IActionResult Canasta()
        {
            if (HttpContext.Session.GetString("Canasta") == null)
            {
                return RedirectToAction("Portal");
            }

            //enviar el contenido del Sesion canasta a la vista
            return View(
            JsonConvert.DeserializeObject<List<ItemProductoModel>>(HttpContext.Session.GetString("Canasta")));
        }

        public IActionResult Delete(int id, int q)
        {
            //eliminar el registro del Session canasta por idproducto y cantidad
            //deserializa
            List<ItemProductoModel> registros =
                JsonConvert.DeserializeObject<List<ItemProductoModel>>(HttpContext.Session.GetString("Canasta"));

            registros.Remove(registros.Find(p => p.id_producto == id && p.stock_producto == q));

            HttpContext.Session.SetString("Canasta", JsonConvert.SerializeObject(registros));
            //redireccionar hacia el Resumen
            return RedirectToAction("Canasta");
        }


        public async Task<IActionResult> Portal()
        {
            if (HttpContext.Session.GetString("Canasta") == null)
            {
                HttpContext.Session.SetString("Canasta", JsonConvert.SerializeObject(new List<ItemProductoModel>()));
            }
            return View(await Task.Run(() => iProducto.GetProductosPortal()));
        }//Fin de Portal

    }
}
