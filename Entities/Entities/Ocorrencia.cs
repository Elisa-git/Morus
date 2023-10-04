using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Entities.Validacoes;
using Core.Notificador;
using Core;

namespace Entities.Entities
{
    [Table("Ocorrencia")]
    public class Ocorrencia : EntityBase
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("data_ocorrencia")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey("Usuario")]
        [Column(Order = 1)]
        public int Id_usuario { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }

        public override bool EhValido()
        {
            ResultadoValidacao = new OcorrenciaValidation().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
