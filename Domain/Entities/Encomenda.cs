using Core;
using Domain.Validacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("Encomenda")]
    public class Encomenda : EntityBase
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Destinatario")]
        public string Destinatario { get; set; }

        [Column("QuemRecebeu")]
        public string QuemRecebeu { get; set; }

        [Column("DataRecebimento")]
        public DateTime DataRecebimento { get; set; }

        [Column("DataRecolhimento")]
        public DateTime DataRecolhimento { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [Column("Apartamento")]
        public int Apartamento { get; set; }

        [Column("Torre")]
        public string Torre { get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int IdCondominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }

        public override bool EhValido()
        {
            ResultadoValidacao = new EncomendaValidation().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
