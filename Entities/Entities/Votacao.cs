using Entities.Entities.Enum;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace Entities.Entities
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
