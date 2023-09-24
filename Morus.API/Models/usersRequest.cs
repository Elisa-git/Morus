using Entities.Entities.Enum;
using Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Morus.API.Models
{
    public class usersRequest
    {
       
        public int Id { get; set; }
        
        public string? Nome { get; set; }
       
        public string CPF { get; set; }
        
        public string? Torre { get; set; }
        
        public int? Apartamento { get; set; }
        
        public DateTime? DataNascimento { get; set; }
        
        public TipoUsuario? Tipo { get; set; }       
        
        public int? Id_condominio { get; set; }

        public string user_id { get; set; }
    }
}
