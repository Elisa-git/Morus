using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("LivroCaixa")]
    public class LivroCaixa : Notifies
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("DescricaoTransacao")]
        public string DescricaoTransacao { get; set; }

        [Column("Categoria")]
        public string Categoria { get; set; }

        [Column("Torre")]
        public string Torre { get; set; }

        [Column("NumeroConta")]
        public string NumeroConta { get; set; }

        [Column("ValorTransacao")]
        public double ValorTransacao { get; set; }

        [Column("DataTransacao")]
        public DateTime DataTransacao { get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int Id_condominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }
    }
}
