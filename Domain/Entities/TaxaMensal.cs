using Core;
using Domain.Validacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("TaxaMensal")]
    public class TaxaMensal : EntityBase
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Valor")]
        public double Valor { get; set; }

        [Column("Recorrente")]
        public bool Recorrente { get; set; }

        [Column("DataInicio")]
        public DateTime DataInicio { get; set; }

        [Column("DataFim")]
        public DateTime DataFim { get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int IdCondominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }

        public override bool EhValido()
        {
            ResultadoValidacao = new TaxaMensalValidation().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
