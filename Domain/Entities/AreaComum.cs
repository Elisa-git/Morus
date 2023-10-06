using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("AreaComum")]
    public class AreaComum : Notifies
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Limite")]
        public int Limite { get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int Id_condominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }

    }
}
