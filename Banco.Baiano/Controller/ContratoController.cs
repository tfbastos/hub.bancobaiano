using Banco.Baiano.Interface;
using Banco.Baiano.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Banco.Baiano.Controller
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IRepository<Cliente> _repo;


        public ContratoController(IRepository<Cliente> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult GetAllContratos()
        {

            var lista = _repo.All
                .Include(i => i.Contratos)
                .ThenInclude(t => t.SituacaoContrato)
                .Include(i => i.Contratos)
                .ThenInclude(t => t.Parcelas)
                .ToList();

            return Ok(lista);
        }

        [HttpGet("{Cpf}")]
        public IActionResult GetContrato(string Cpf)
        {

            var lista = _repo.All
                .Include(i => i.Contratos)
                .ThenInclude(t => t.SituacaoContrato)
                .Include(i => i.Contratos)
                .ThenInclude(t => t.Parcelas)
                //.Where(w => w.Contratos.Where(c => c.Numero == Contrato).Any())
                .Where(w => w.Cpf.Equals(Cpf))
                .ToList();

            if (lista.Count > 0)
                return Ok(lista);

            return BadRequest("Não foram encontrado contratos para o CPF informado.");
        }



    }
}