using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("Multa")]
    public class Multa : Notifies
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("ValorMulta")]
        public decimal ValorMulta { get; set; }

        [Column("AplicadaEm")]
        public DateTime AplicadaEm { get; set; }

        [Column("DataExpiracao")]
        public DateTime DataExpiracao { get; set; }

        [Column("TaxaJurosDia")]
        public double TaxaJurosDia { get; set; }

        [Column("Motivo")]
        public string Motivo { get; set; }

        [ForeignKey("Usuario")]
        [Column(Order = 1)]
        public int Id_usuario { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
    }
}
