using Microsoft.OData.Edm;
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

namespace Entities.Entities
{
    [Table("TaxaMensal")]
    public class TaxaMensal : Notifies
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Valor")]
        public double Valor { get; set; }

        [Column("Recorrente")]
        public bool Recorrente { get; set; }

        [Column("DataInicio")]
        public DateTime DataInicio { get; set; }

        [Column("DataFim")]
        public DateTime DataFim { get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int Id_condominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }
    }
}
