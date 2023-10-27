namespace Morus.API.Models
{
    public class MultaRequest
    {
        public int Id { get; set; }
        public double ValorMulta { get; set; }
        public DateTime AplicadaEm { get; set; }
        public DateTime DataExpiracao { get; set; }
        public double TaxaJurosDia { get; set; }
        public string Motivo { get; set; }
        public int Id_usuario { get; set; }
    }
}
