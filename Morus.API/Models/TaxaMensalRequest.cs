namespace Morus.API.Models
{
    public class TaxaMensalRequest
    {
        public int? Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public double Valor { get; set; }

        public bool Recorrente { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Id_condominio { get; set; }
    }
}
