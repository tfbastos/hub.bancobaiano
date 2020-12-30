using Banco.Baiano.Model;
using JwtServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace Banco.Baiano.Authetication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult NovoToken([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var jwt = new TokenProvinder(_config);
                var token = jwt.GenerateToken(model.Username);

                return Ok(token);//200
            }

            return BadRequest(); //400
        }
    }
}