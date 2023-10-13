using Core;
using Domain.Entities.Enum;
using Domain.Validacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("Votacao")]
    public class Votacao : EntityBase
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tema")]
        public string Tema { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        [Column("DataExpiracao")]
        public DateTime DataExpiracao { get; set; }

        [Column("Ativa")]
        public bool Ativa { get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int IdCondominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }

        public override bool EhValido()
        {
            //para implementação seguir modelo de ocorrencia
            return true;
        }
    }
}
