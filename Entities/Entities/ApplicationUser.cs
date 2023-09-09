using Entities.Entities.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column("User_CPF")]
        public string CPF { get; set; }

        [Column("User_tipo")]
        public TipoUsuario? Tipo { get; set; }
    }
}
