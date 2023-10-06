using Domain.Entities;
using Domain.Entities.Enum;

namespace Application.NovaPasta1
{
    public class UsuarioLoginResponse
    {
        public string Token { get; set; }
        public UsuarioLogadoResponse Usuario { get; set; }
    }

    public class UsuarioLogadoResponse
    {
        public string? Nome { get; set; }
        public string CPF { get; set; }
        public string? Torre { get; set; }
        public int? Apartamento { get; set; }
        public DateTime? DataNascimento { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public virtual Condominio? Condominio { get; set; }
    }
}
