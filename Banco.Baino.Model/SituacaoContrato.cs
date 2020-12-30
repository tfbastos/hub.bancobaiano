using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Banco.Baiano.Model
{
    [Table("situacaocontrato")]
    public class SituacaoContrato
    {
        [JsonIgnore]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        // public virtual Contrato Contrato { get; set; }
    }
}
