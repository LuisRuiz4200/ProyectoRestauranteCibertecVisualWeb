namespace PJ_RESTAURANTE_5TO_CICLO.Models
{
    public class Seguimiento_Pedido
    {
        public int id_pedido { get;set; }
        public int id_seguimiento_pedido { get;set; }
        public DateTime fechareg_seguimiento_pedido { get; set; }
        public string? estado_seguimiento_pedido { get; set; }
    }
}
