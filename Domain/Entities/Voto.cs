using Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("Voto")]
    public class Voto
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public bool? ValorVoto { get; set; }

        [ForeignKey("Votacao")]
        [Column(Order = 1)]
        public int IdVotacao { get; set; }

        [JsonIgnore]
        public virtual Votacao Votacao { get; set; }

        [ForeignKey("Usuario")]
        [Column(Order = 2)]
        public int IdUsuario { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
    }
}
