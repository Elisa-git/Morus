using Domain.Entities;
using Org.BouncyCastle.Asn1.X509;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Morus.API.Models
{
    public class CadastrarVotacaoRequest
    {
        public string Tema { get; set; }
        public string Descricao { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
