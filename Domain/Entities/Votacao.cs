using Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("Votacao")]
    public class Votacao
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

        [Column("Status")]
        public StatusVotacao Status { get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int Id_condominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }
    }
}
