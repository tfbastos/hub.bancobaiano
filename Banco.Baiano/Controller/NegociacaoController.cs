using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Banco.Baiano.Interface;
using Banco.Baiano.Model;
using Banco.Baiano.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Banco.Baiano.Controller
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class NegociacaoController : ControllerBase
    {
        private readonly IRepository<Negociacao> _repo;

        public NegociacaoController(IRepository<Negociacao> repository)
        {
            _repo = repository;
        }

        [HttpPost]
        public IActionResult IncluiNegociacao([FromBody] NegociacaoDto negociacao)
        {
            if (ModelState.IsValid)
            {
                decimal somaParcelas = negociacao.Parcelas.Sum(p => p.Valor);
                var valorPrincipal = somaParcelas.ToString("C");
                var juros = 0.0;
                var desconto = (double)somaParcelas * 0.1;
                var valorPago = (double)somaParcelas - desconto;
                var idNeg = Guid.NewGuid().ToString(); 

                var obj = new
                {
                    Acordo = idNeg,
                    Contrato = negociacao.Contrato,
                    Vencimento = negociacao.Data,
                    Desconto = desconto.ToString("C"),
                    Valor = valorPago.ToString("C"),
                };

                var neg = new Negociacao
                {
                    Numero = idNeg,
                    Dados = JsonConvert.SerializeObject(obj)
                };

                _repo.Incluir(neg);

                return Ok(obj);
            }
            return BadRequest();
        }
    }
}