using Domain.Entities.Enum;

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
