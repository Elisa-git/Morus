using Entities.Entities;
using Org.BouncyCastle.Asn1.X509;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Entities.Entities.Enum;

namespace Morus.API.Models
{
    public class UsuarioRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Torre { get; set; }
        public int Apartamento { get; set; }
        public TipoUsuario Tipo { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Id_condominio { get; set; }
    }
}
