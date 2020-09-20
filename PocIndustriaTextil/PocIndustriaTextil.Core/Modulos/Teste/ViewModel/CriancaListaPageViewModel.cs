using MvvmHelpers;
using MvvmHelpers.Commands;
using PocIndustriaTextil.Core.Modulos.Teste.Model;
using PocIndustriaTextil.Core.Services.Api;
using PocIndustriaTextil.Core.Services.Navigation;
using PocIndustriaTextil.Core.Utils.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PocIndustriaTextil.Core.Modulos.Teste.ViewModel
{
    public class CriancaListaPageViewModel : BaseViewModel
    {
        #region Propriedades . . .
        readonly static HttpClient http = new HttpClient();
        INavigationService _navigation;
        IApiService apiService;
        public ObservableRangeCollection<Crianca> Items { get; set; } = new ObservableRangeCollection<Crianca>();
        public string DisplayMessage { get; private set; }
        #endregion

        #region Contrutor . . .
        public CriancaListaPageViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            apiService = new ApiService(http);
            Title = "Crianças";
        }
        #endregion

        #region Commands . . .
        public ICommand RemoverCommand => new Command<Crianca>(async (obj)=> await OnRemover(obj));
        public ICommand NovoCommand => new Command(async () => await OnNovo());

        public async Task OnNovo()
        {
            await _navigation.NavigateToPageAsync("teste");
        }

        #endregion

        #region Métodos . . .

        private async Task OnRemover(Crianca obj)
        {
           await apiService.DeleteItem<GenericResponse<Crianca>>("criancas", obj.CriancaId);
        }

        public async Task GetList()
        {
            Items.Clear();

            try
            {
                var response = await apiService.GetItems<GenericResponse<Crianca>>("criancas");
                if (!response.Success)
                    DisplayMessage = response.Message;

                Items.AddRange(response.Items);
#if DEBUG
                response.Items.ForEach(x => Console.WriteLine($" =====> Nome:{x.Nome}, Idade:{x.Idade}"));
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO CriancasViewModel { ex.Message }");
            }
        }
        #endregion
   }
}
