using Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Morus.API.Models
{
    public class EncomendaRequest
    {
        public int? Id { get; set; }
        public string Destinatario { get; set; }
        public string QuemRecebeu { get; set; }
        public DateTime DataRecebimento { get; set; }
        public DateTime DataRecolhimento { get; set; }
        public string Status { get; set; }
        public int Apartamento { get; set; }
        public string Torre { get; set; }
    }
}
