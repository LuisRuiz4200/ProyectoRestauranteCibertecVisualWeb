
using PJ_RESTAURANTE_5TO_CICLO.Models;

namespace PJ_RESTAURANTE_5TO_CICLO.Interface
{
    public interface IProducto
    {
        Task<List<Producto>> GetProductosPortal();
        Task<List<Producto>> GetProductos();
        Task<Producto> BuscarAsync(int id);

    }
}
