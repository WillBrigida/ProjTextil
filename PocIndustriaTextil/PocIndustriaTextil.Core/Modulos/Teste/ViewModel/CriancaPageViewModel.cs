using MvvmHelpers;
using MvvmHelpers.Commands;
using PocIndustriaTextil.Core.Modulos.Teste.Model;
using PocIndustriaTextil.Core.Services.Api;
using PocIndustriaTextil.Core.Services.Navigation;
using PocIndustriaTextil.Core.Utils.Responses;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PocIndustriaTextil.Core.Modulos.Teste.ViewModel
{
    public class CriancaPageViewModel : BaseViewModel
    {
        #region Propriedades . . .
        readonly INavigationService _navigation;
        readonly static HttpClient http = new HttpClient();
        IApiService apiService;
        public Crianca Item { get; set; }
        public string DisplayMessage { get; private set; }
        #endregion

        #region Contrutor . . .
        public CriancaPageViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            Title = "Criança";
            Item = new Crianca();
            apiService = new ApiService(http);
        }
        #endregion

        #region Commands . . .
        public ICommand IncluirCommand => new Command(async () => await OnIncluir());
        public ICommand RemoverCommand => new Command<Crianca>(async (obj) => await OnRemover(obj));
        public ICommand EditarCommand => new Command<Crianca>(async (obj) => await OnEditar(obj));
        #endregion

        #region Métodos . . .
        public async Task OnIncluir()
        {
#if DEBUG
            Console.WriteLine($" =====> Nome:{Item.Nome}, Idade:{Item.Idade}");
#endif
            var response = await apiService.PostItem<GenericResponse<Crianca>>("criancas", Item);

            DisplayMessage = response.Message;
            await _navigation.NavigateBack();
        }

        public async Task OnRemover(Crianca obj)
        {
            await apiService.DeleteItem<GenericResponse<Crianca>>("crianca", obj.CriancaId);
        }

        public async Task OnEditar(Crianca obj)
        {
            var response = await apiService.PutItem<GenericResponse<Crianca>>("crianca", obj);
            DisplayMessage = response.Message;
        }
        #endregion
    }
}
