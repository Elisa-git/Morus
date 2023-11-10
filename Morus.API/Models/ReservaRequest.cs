using Domain.Entities.Enum;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Morus.API.Models
{
    public class ReservaRequest
    {
        public int Id { get; set; }

        public DateTime DataReserva { get; set; }

        public StatusReserva Status { get; set; }

        public int Id_AreaComum { get; set; }

        public string UserId { get; set; }

    }
}
