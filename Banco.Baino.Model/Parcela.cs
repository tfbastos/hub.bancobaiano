using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;

namespace Banco.Baiano.Model
{
    [Table("parcela")]
    public class Parcela
    {
        [JsonIgnore]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("numero")]
        public int Numero { get; set; }

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("vencimento")]
        public DateTime Vencimento { get; set; }

        [JsonIgnore]
        [Column("id_contrato")]
        public int IdContrato { get; set; }

       // public virtual Contrato Contrato { get; set; } 

    }
}
