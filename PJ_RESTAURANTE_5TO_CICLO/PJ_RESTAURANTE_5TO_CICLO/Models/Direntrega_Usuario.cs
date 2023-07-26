namespace PJ_RESTAURANTE_5TO_CICLO.Models
{
    public class Direntrega_Usuario
    {
        public int id_usuario { get; set; }
        public int id_direntrega { get; set; }
        public int id_distrito { get; set; }
        public DateTime fechareg_direntrega { get; set; }
        public string? estado_direntrega { get;set; }
    }
}
