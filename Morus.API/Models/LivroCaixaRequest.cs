using Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Morus.API.Models
{
    public class LivroCaixaRequest
    {
        public int? Id { get; set; }
        public string DescricaoTransacao { get; set; }
        public string Categoria { get; set; }
        public string Torre { get; set; }
        public decimal ValorTransacao { get; set; }
        public DateTime DataTransacao { get; set; }
        public TipoTransacao TipoTransacao { get;set; }
    }
}
