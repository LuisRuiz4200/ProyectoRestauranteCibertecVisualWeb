namespace PJ_RESTAURANTE_5TO_CICLO.Models
{
    public class Producto_Pedido
    {
        public int id_pedido { get; set; }
        public int id_producto_pedido { get; set; }
        public int id_producto { get; set; }
        public int cantidad_producto { get; set; }  
    }
}
