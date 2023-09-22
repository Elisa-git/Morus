namespace Morus.API.Models
{
    public class MessageViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public bool Ativo { get; set; }

        public string DataCadastro { get; set; }

        public string DataAlteracao { get; set; }

        public string UserId { get; set; }
    }
}
