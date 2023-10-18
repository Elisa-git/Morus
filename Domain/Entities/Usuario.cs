using Core;
using Domain.Validacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("Usuario")]
    public class Usuario : EntityBase
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string? Nome { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("Torre")]
        public string? Torre { get; set; }

        [Column("Apartamento")]
        public int? Apartamento { get; set; }

        [Column("DataNascimento")]
        public DateTime? DataNascimento { get; set; }

        //[Column("Tipo")]
        //public TipoUsuario Tipo { get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int Id_condominio { get; set; }

        [ForeignKey("User")]
        public string IdUserIdentity { get; set; }

        [JsonIgnore]
        public virtual User? User { get; set; }

        [JsonIgnore]
        public virtual Condominio? Condominio { get; set; }

        public override bool EhValido()
        {
            ResultadoValidacao = new UsuarioValidation().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
