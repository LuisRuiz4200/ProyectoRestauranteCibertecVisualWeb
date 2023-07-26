namespace PJ_RESTAURANTE_5TO_CICLO.Models
{
    public class Comentario
    {
        public int id_comentario { get;set; }
        public int id_usuario_cliente { get;set; }
        public string? des_comentario { get; set; }
        public int cantestrella_comentario { get; set; }
        public DateTime fechareg_comentario { get; set; }
        public string? estado_comentario { get; set; }
    }
}
