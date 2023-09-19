using Entities.Entities;
using Org.BouncyCastle.Asn1.X509;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Morus.API.Models
{
    public class MultaRequest
    {
        public int Id { get; set; }
        public double ValorMulta { get; set; }
        public string AplicadaEm { get; set; }
        public string DataExpiracao { get; set; }
        public double TaxaJurosDia { get; set; }
        public string Motivo { get; set; }
        public int Id_usuario { get; set; }
    }
}
