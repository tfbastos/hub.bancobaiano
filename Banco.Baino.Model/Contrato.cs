using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Banco.Baiano.Model
{
    [Table("contrato")]
    public class Contrato
    {
        [JsonIgnore]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("numero")]
        public long Numero { get; set; }

        [JsonIgnore]
        [Column("id_situacao")]
        public int IdSituacao { get; set; }

        [JsonIgnore]
        [Column("id_cliente")]
        public int IdCliente { get; set; }


        public virtual SituacaoContrato SituacaoContrato { get; set; }

        public List<Parcela> Parcelas { get; set; }

    }
}
