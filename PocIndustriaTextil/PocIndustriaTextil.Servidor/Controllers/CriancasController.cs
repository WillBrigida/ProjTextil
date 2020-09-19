using Microsoft.AspNetCore.Mvc;
using PocIndustriaTextil.Core.Teste;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Servidor.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CriancasController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Criancas>>> Get()
        {
            var criancas = new List<Criancas>
            {
                new Criancas{Nome = "Arthur", Idade = 4},
                new Criancas{Nome = "Victória", Idade = 16},
                new Criancas{Nome = "Luiza", Idade = 14},
                new Criancas{Nome = "Maria Eduarda", Idade = 14},
            };
            return Ok(await Task.Run(() => criancas));
        }
    }
}