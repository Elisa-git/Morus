using Core;
using Domain.Validacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("Informacao")]
    public class Informacao : EntityBase
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int IdCondominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; set; }

        public override bool EhValido()
        {
            ResultadoValidacao = new InformacaoValidation().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
