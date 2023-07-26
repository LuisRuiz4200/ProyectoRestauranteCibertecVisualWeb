﻿namespace PJ_RESTAURANTE_5TO_CICLO.Models
{
    public class Usuario
    {
        public int id_usuario {  get; set; }
        public int id_tipo_usuario { get; set; }
        public string? cod_usuario { get; set; }
        public string? nom_usuario { get; set; }
        public string? ape_usuario { get; set; }
        public int tel_usuario { get; set; }
        public int cel_usuario { get; set; }
        public int id_distrito { get;set; }
        public string? dir_distrito { get; set; }
        public string? dni_usuario { get; set; } 
        public string? email_usuario { get; set; }
        public string? password_usuario { get; set; }
        public byte[]? imagen_usuario { get; set; }
        public DateTime fechareg_usuario { get; set; }
        public DateTime fechaact_usuario { get; set; }
        public string? estado_usuario { get;set }

    }
}
