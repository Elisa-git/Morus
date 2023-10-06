using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("Arquivo")]
    public class Arquivo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Classificacao")]
        public string Classificacao { get; set; }

        [Column("TamanhoArquivo")]
        public string TamanhoArquivo { get; set; }

        [Column("DataUpload")]
        public DateTime DataUpload { get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int Id_condominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }

    }
}
