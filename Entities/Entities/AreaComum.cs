﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Entities.Entities
{
    [Table("AreaComum")]
    public class AreaComum
    {
        [Key]
        [Column("Id")]
        public int Id {  get; set; }

        [Column("Nome")]
        public string Nome {  get; set; }

        [Column("Limite")]
        public int Limite {  get; set; }

        [ForeignKey("Condominio")]
        [Column(Order = 1)]
        public int Id_condominio { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }

    }
}
