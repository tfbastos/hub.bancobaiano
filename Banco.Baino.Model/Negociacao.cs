using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Banco.Baiano.Model
{
    [Table("negociacao")]
    public class Negociacao
    {
        [JsonIgnore]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("dados")]
        public string Dados { get; set; }
    }
}
