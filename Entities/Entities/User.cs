using Entities.Entities.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class User : IdentityUser
    {  
        [Column("Nome")]
        public string? Nome { get; set; }
        
        [Column("CPF")]
        public string CPF { get; set; }

        [Column("Token")]
        public string? Token { get; set; }

        //[Column("Torre")]
        //public string? Torre { get; set; }

        //[Column("Apartamento")]
        //public int? Apartamento { get; set; }

        //[Column("DataNascimento")]
        //public DateTime? DataNascimento { get; set; }

        [Column("Tipo")]
        public TipoUsuario Tipo { get; set; }

        //[ForeignKey("Condominio")]
        //[Column(Order = 1)]
        //public int? Id_condominio { get; set; }

        //[JsonIgnore]
        //public virtual Condominio? Condominio { get; set; }
    }
}
