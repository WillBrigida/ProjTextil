using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocIndustriaTextil.Core.Modulos.Teste.Model;
using PocIndustriaTextil.Core.Utils.Responses;
using PocIndustriaTextil.Servidor.Data;
using PocIndustriaTextil.Servidor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Servidor.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CriancasController : ControllerBase
    {
        readonly AppDbContext _context;

        public CriancasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crianca>>> ObterTodas()
        {
            try
            {
                var criancas = await _context.T_crianca
                    .AsNoTracking()
                    .Where(x => x.RegistroAtivo == true)
                    .ToListAsync();
                return Ok(new GenericResponse<Crianca> { Success = true, Items = criancas });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResponse<Crianca> { Success = false, Message = $"{MessageError.MensagemResponse}\n Erro:{ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Crianca>>> ObterPorId(int id)
        {
            try
            {
                var crianca = await _context.T_crianca
                    .SingleAsync(x => x.CriancaId == id);

                if (crianca == null)
                    return Ok(new GenericResponse<Crianca> { Success = false, Message = "Crianca não encontrada" });

                return Ok(new GenericResponse<Crianca> { Success = true, Item = crianca });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResponse<Crianca> { Success = false, Message = $"{MessageError.MensagemResponse}\n Erro:{ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Crianca>> Incluir([FromBody]Crianca crianca)
        {
            try
            {
                await _context.AddAsync(crianca);
                await _context.SaveChangesAsync();
                return Ok(new GenericResponse<Crianca> { Success = true, Item = crianca });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResponse<Crianca> { Success = false, Message = $"{MessageError.MensagemResponse}\n Erro:{ex.Message}" });
            }
        }

        [HttpPut]
        public async Task<ActionResult<Crianca>> Alterar([FromBody] Crianca crianca)
        {
            try
            {
                _context.Entry(crianca).State = EntityState.Modified; 
                await _context.SaveChangesAsync();
                return Ok(new GenericResponse<Crianca> { Success = true, Item = crianca });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResponse<Crianca> { Success = false, Message = $"{MessageError.MensagemResponse}\n Erro:{ex.Message}" });
            }
        }

        [HttpPut("deletar")]
        public async Task<ActionResult<Crianca>> DeletarPorId([FromBody] Crianca crianca)
        {
            try
            {
                crianca.RegistroAtivo = false;
                crianca.DataDesativacao = DateTime.Now;

                _context.Entry(crianca).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new GenericResponse<Crianca> { Success = true, Item = crianca });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResponse<Crianca> { Success = false, Message = $"{MessageError.MensagemResponse}\n Erro:{ex.Message}" });
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Crianca>> DeletarPorId(int id)
        {
            try
            {
                var crianca = new Crianca { CriancaId = id };
                _context.Remove(crianca);
                await _context.SaveChangesAsync();
                return Ok(crianca);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new GenericResponse<Crianca> { Success = false, Message = $"{MessageError.MensagemResponse}\n Erro:{ex.Message}" });
            }
        }
    }
}