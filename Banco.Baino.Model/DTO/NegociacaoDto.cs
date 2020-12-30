using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Baiano.Model.DTO
{
    public class NegociacaoDto
    {
        public long Contrato { get; set; }
        public DateTime Data { get; set; }
        public List<ParcelaDto> Parcelas {get; set;}
    }
}
