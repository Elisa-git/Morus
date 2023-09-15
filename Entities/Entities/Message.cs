using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Entities.Entities
{

    [Table("Mensagem")]
    public class Message : Notifies
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Titulo")]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("User")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
    
}
