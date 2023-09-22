using Google.Protobuf.Collections;
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
    [Table("Arquivo")]
    public class Arquivo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Classificacao")]
        public string Classificacao { get; set; }

        [Column("TamanhoArquivo")]
        public string TamanhoArquivo { get; set; }

        [Column("DataUpload")]
        public DateTime DataUpload {  get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int Id_condominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }

    }
}
