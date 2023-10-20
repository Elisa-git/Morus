using Core;
using Domain.Entities.Enum;
using Domain.Validacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("LivroCaixa")]
    public class LivroCaixa : EntityBase
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

        [Column("ValorTransacao")]
        public decimal ValorTransacao { get; set; }

        [Column("DataTransacao")]
        public DateTime DataTransacao { get; set; }

        [Column("TipoTransacao")]
        public TipoTransacao TipoTransacao { get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int IdCondominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }

        public override bool EhValido()
        {
            ResultadoValidacao = new LivroCaixaValidation().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
