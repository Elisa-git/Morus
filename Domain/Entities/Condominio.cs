using Core;
using Domain.Validacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Condominio")]
    public class Condominio : EntityBase
    {
        [Key]
        [Column("Id")]
        public int? Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Estado")]
        public string Estado { get; set; }

        [Column("Cidade")]
        public string Cidade { get; set; }

        [Column("Bairro")]
        public string Bairro { get; set; }

        [Column("Rua")]
        public string Rua { get; set; }

        [Column("Numero")]
        public int Numero { get; set; }

        [Column("CEP")]
        public string CEP { get; set; }

        [Column("Porteiro")]
        public bool Porteiro { get; set; }

        public override bool EhValido()
        {
            ResultadoValidacao = new CondominioValidation().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
