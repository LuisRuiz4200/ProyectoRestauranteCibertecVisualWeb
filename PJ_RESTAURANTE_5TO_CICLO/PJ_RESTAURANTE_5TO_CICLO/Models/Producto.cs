namespace PJ_RESTAURANTE_5TO_CICLO.Models
{
    public class Producto
    {
        public int id_producto { get; set; }
        public int id_categoria_producto { get; set; }
        public string? nom_producto { get; set; }
        public string? des_producto { get; set; }
        public double preciouni_producto { get; set; }
        public int stock_producto { get; set; }
        public byte[]? imagen_producto { get; set; }
        public string? estado_producto { get; set; }
    }
}
