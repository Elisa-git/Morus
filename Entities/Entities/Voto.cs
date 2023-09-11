using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Text.Json.Serialization;
using Entities.Entities.Enum;

namespace Entities.Entities
{
    [Table("Voto")]
    public class Voto
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public ValorVotoEnum ValorVoto { get; set; }

        [ForeignKey("Votacao")]
        [Column(Order = 1)]
        public int Id_votacao { get; set; }

        [JsonIgnore]
        public virtual Votacao Votacao { get; set; }
        
        [ForeignKey("Usuario")]
        [Column(Order = 1)]
        public string Id_usuario { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
    }
}
