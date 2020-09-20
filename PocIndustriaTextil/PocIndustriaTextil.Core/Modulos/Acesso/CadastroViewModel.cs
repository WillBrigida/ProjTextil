using MvvmHelpers;
using MvvmHelpers.Commands;
using PocIndustriaTextil.Core.Model.DTO;
using PocIndustriaTextil.Core.Services.Api;
using PocIndustriaTextil.Core.Utils.Responses;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PocIndustriaTextil.Core.Modulos.Acesso
{
    public class CadastroViewModel : BaseViewModel
    {
        readonly static HttpClient http = new HttpClient();
        IApiService apiService;
        public UsuarioCadastroDTO Usuario { get; set; }

        public CadastroViewModel()
        {
            apiService = new ApiService(http);
            Usuario = new UsuarioCadastroDTO();
        }

        public ICommand CadastroCommand => new Command( async () => await OnCadastro());

        public async Task OnCadastro()
        {
            Console.WriteLine($"=====> {Usuario.Nome} {Usuario.Sobrenome}, {Usuario.Login}, {Usuario.Senha}");
            var result = await apiService.PostItem<GenericResponse<UsuarioCadastroDTO>>("acesso/cadastro", Usuario);
        }
    }
}
