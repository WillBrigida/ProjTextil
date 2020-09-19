using PocIndustriaTextil.Core.Model;
using PocIndustriaTextil.Core.Model.DTO;
using PocIndustriaTextil.Core.Utils.Responses;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Web.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(UsuarioLoginDTO usuario);
        Task Logout();
        Task<GenericResponse<UsuarioCadastroDTO>> Register(UsuarioCadastroDTO usuario);
    }
}
