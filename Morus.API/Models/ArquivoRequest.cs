namespace Morus.API.Models
{
    public class ArquivoRequest
    {
        public string Classificacao { get; set; }

        public IFormFile Documento { get; set; }

        public DateTime DataUpload { get; set; }

        public int Id_condominio { get; set; }
    }
}
