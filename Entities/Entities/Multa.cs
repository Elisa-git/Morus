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

namespace Entities.Entities
{
    [Table("Multa")]
    public class Multa : Notifies
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("ValorMulta")]
        public double ValorMulta { get; set; } 
        
        [Column("AplicadaEm")]
        public string AplicadaEm { get; set; }        
        
        [Column("DataExpiracao")]
        public DateTime DataExpiracao { get; set; }
        
        [Column("TaxaJurosDia")]
        public double TaxaJurosDia { get; set; }
        
        [Column("Motivo")]
        public string Motivo { get; set; }

        [ForeignKey("Usuario")]
        [Column(Order = 1)]
        public int Id_usuario { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
    }
}
