using Banco.Baiano.HttpClients;
using Banco.Baiano.Interface;
using Banco.Baiano.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace Banco.Baiano.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetToken([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var token = new AuthenticationApi().GetToken(model);

                return Ok(token);

            }
            return BadRequest();
        }
    }
}