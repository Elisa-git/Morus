using Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("Reserva")]
    public class Reserva
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("DataReserva")]
        public DateTime DataReserva { get; set; }

        [Column("Status")]
        public StatusReserva Status { get; set; }

        [ForeignKey("AreaComum")]
        [Column(Order = 1)]
        public int Id_AreaComum { get; set; }

        [JsonIgnore]
        public virtual AreaComum AreaComum { get; set; }

        [ForeignKey("Usuario")]
        [Column(Order = 2)]
        public int Id_Usuario { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
    }
}
