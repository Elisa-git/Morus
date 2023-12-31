﻿namespace Morus.API.Models
{
    public class OcorrenciaRequest
    {
        public int? Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdUsuario { get; set; }
        public bool Resolvido { get; set; }
    }
}
