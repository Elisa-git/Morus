using Core;
using Domain.Validacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("Ocorrencia")]
    public class Ocorrencia : EntityBase
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("data_ocorrencia")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey("Usuario")]
        [Column(Order = 1)]
        public int? IdUsuario { get; set; }

        [Column("Resolvido")]
        public bool Resolvido { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }

        public override bool EhValido()
        {
            ResultadoValidacao = new OcorrenciaValidation().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
