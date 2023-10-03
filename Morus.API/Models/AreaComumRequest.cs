using Entities.Entities;
using Org.BouncyCastle.Asn1.X509;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Morus.API.Models
{
    public class AreaComumRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Limite { get; set; }
        public int Id_condominio { get; set; }
    }

}
