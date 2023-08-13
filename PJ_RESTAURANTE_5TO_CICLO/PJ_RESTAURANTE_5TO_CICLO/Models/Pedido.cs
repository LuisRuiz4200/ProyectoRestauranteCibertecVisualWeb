namespace PJ_RESTAURANTE_5TO_CICLO.Models
{
    public class Pedido
    {
        public int id_pedido { get; set; }
        public int id_usuario_cliente { get; set; }
        public int id_direntrega { get; set; }
        public int id_colaborador_repartidar { get; set; }
        public TimeOnly tiempoentrega_pedido { get; set; } 
        public DateTime fechareg_pedido { get; set; }
        public DateTime fechaact_pedido { get; set; }
        public string? estado_pedido { get; set; }
    }
}
