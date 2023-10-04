using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("Condominio")]
    public class Condominio
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

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
    }
}
