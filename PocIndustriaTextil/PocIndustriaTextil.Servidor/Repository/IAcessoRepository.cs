using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PocIndustriaTextil.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Servidor.Repository
{
    public interface IAcessoRepository
    {

        Task<ApplicationUser> ObterUsuario(string email, string senha);
        Task<IdentityResult> Registrar(ApplicationUser applicationUser, string password);
    }
    internal class AcessoRepository : IAcessoRepository
    {
        readonly UserManager<ApplicationUser> _userManager;

        public AcessoRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<ApplicationUser> ObterUsuario(string email, string senha)
        {
            var usuario = await _userManager.Users
                .SingleAsync(x => x.UserName == email);

            if (await _userManager.CheckPasswordAsync(usuario, senha))
                return usuario;

            else
            {
                //Usuario nao encontrado
                throw new Exception("Verifique se os dados estão corretos e tente novamente.");
            }
        }

        public async Task<IdentityResult> Registrar(ApplicationUser applicationUser, string password)
        {
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
                return result;
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var erro in result.Errors)
                    sb.Append(erro.Description);

                throw new Exception($"usuario não cadastrado! {sb.ToString()}");
            }
        }
    }
}
