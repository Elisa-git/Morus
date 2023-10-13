using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class VotacaoContadorResponse
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool Ativa { get; set; }
        public int QtdVotosFavoraveis { get; set; }
        public int QtdVotosContras { get; set; }
        public int QtdVotosNulos { get; set; }
    }
}
