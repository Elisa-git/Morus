namespace Morus.API.Models
{
    public class InformacaoRequest
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
