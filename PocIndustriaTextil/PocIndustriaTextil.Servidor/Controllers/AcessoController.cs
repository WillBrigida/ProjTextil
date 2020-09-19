using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PocIndustriaTextil.Core.Model.DTO;
using PocIndustriaTextil.Core.Model;
using PocIndustriaTextil.Servidor.Repository;
using PocIndustriaTextil.Servidor.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PocIndustriaTextil.Core.Utils.Responses;

namespace PocIndustriaTextil.Servidor.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AcessoController : ControllerBase
    {
        readonly IAcessoRepository _acessoRepository;
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly UserManager<ApplicationUser> _userManager;
        readonly AppSettings _appSettings;



        public AcessoController(IAcessoRepository acessoRepository,
                                 SignInManager<ApplicationUser> signInManager,
                                 UserManager<ApplicationUser> userManager,
                                 IOptions<AppSettings> appSettings)
        {
            _acessoRepository = acessoRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

#if DEBUG
        [HttpGet("modelo/login")]
        public async Task<ActionResult> GetModeloLogin()
        {
            return base.Ok(new UsuarioLoginDTO());
        }

        [HttpGet("modelo/cadastro")]
        public async Task<ActionResult> GetModeloCadastro()
        {
            return base.Ok(new UsuarioCadastroDTO());
        }
#endif

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO usuario)
        {
            try
            {
                var usr = await _acessoRepository.ObterUsuario(usuario.Login, usuario.Senha);

                if (usr == null)
                    return NoContent();

                else
                    return Ok(new LoginResponse { Sucess = true, Token = await GenerateTokenAsync(usr) });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=====>{ex.Message}");
                return BadRequest(new LoginResponse { Sucess = false, Message = MessageError.MensagemResponse });
            }
        }


        [HttpPost("cadastro")]
        public async Task<ActionResult> Post([FromBody] UsuarioCadastroDTO usuario)
        {
            Console.WriteLine($"=====> Entrou controller HttpPost/cadastro");

            try
            {
                var user = new ApplicationUser
                {
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    NomeCompleto = ($"{usuario.Nome} {usuario.Sobrenome}"),
                    UserName = usuario.Login,
                };

                var result = await _acessoRepository.Registrar(user, usuario.Senha);

                if (!result.Succeeded)
                {
                    Console.WriteLine($"{result.Errors}");
                    return BadRequest(new GenericResponse<UsuarioCadastroDTO> { Success = false, Message = MessageError.MensagemResponse });
                }
                return Created($"", new GenericResponse<UsuarioCadastroDTO> { Success = true});
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return BadRequest(new GenericResponse<UsuarioCadastroDTO> { Success = false, Message = MessageError.MensagemResponse });
            }
        }
        private async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            //var roles = await _signInManager.UserManager.GetRolesAsync(user);

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

            //foreach (var role in roles)
            //    claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras);

            JwtSecurityToken token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
