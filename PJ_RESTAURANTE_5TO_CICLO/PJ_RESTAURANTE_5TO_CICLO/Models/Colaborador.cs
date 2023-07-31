namespace PJ_RESTAURANTE_5TO_CICLO.Models
{
    public class Colaborador
    {
        public int id_colaborador { get;set; }
        public int id_tipo_colaborador { get;set; }
        public string? nom_colaborador { get; set; }
        public string? ape_colaborador { get; set; }
        public string? dni_colaborador { get; set; }
        public byte[]? imagen_colaborador { get; set; }
        public DateTime fechareg_colaborador { get; set; }
        public DateTime fechaact_colaborador { get; set; }
        public string? estado_colaborador { get; set; }
    }
}
