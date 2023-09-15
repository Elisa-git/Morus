using System.ComponentModel.DataAnnotations.Schema;

namespace Morus.API.Models
{
    public class CondominioRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }
        public bool Porteiro { get; set; }
        public string DataCadastro { get; set; }
        public string DataAlteracao { get; set; }
        public string UserId { get; set; }
    }
}
