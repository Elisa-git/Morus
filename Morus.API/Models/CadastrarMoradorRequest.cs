namespace Morus.API.Models
{
    public class CadastrarMoradorRequest
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Torre { get; set; }
        public int Apartamento { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
