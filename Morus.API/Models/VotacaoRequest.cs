using Domain.Entities.Enum;
using Domain.Entities;
using Org.BouncyCastle.Asn1.X509;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Morus.API.Models
{
    public class VotacaoRequest
    {
        public int Id { get; set; }

        public string Tema { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataExpiracao { get; set; }

        public StatusVotacao Status { get; set; }

        public int Id_condominio { get; set; }

    }
}
