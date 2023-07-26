namespace PJ_RESTAURANTE_5TO_CICLO.Models
{
    public class Compra
    {
        public int id_compra { get; set; }
        public int id_pedido { get; set; }
        public int id_medio_pago { get; set; }
        public double monto_compra { get; set; }
        public DateTime fechareg_compra { get; set; }
        public string? estado_compra { get; set; }
    }
}
