namespace Morus.API.Models
{
    public class ArquivoRequest
    {
        public int Id { get; set; }

        public string Classificacao { get; set; }

        public string TamanhoArquivo { get; set; }

        public DateTime DataUpload { get; set; }

        public int Id_condominio { get; set; }

    }
}
