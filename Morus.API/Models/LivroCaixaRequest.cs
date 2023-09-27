using Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Morus.API.Models
{
    public class LivroCaixaRequest
    {
        public int Id { get; set; }

        public string DescricaoTransacao { get; set; }

        public string Categoria { get; set; }

        public string Torre { get; set; }

        public string NumeroConta { get; set; }

        public double ValorTransacao { get; set; }

        public DateTime DataTransacao { get; set; }

        public int Id_condominio { get; set; }

    }
}
