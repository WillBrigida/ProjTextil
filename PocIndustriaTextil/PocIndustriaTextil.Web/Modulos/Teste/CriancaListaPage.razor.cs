using Microsoft.AspNetCore.Components;
using PocIndustriaTextil.Core.Modulos.Teste.ViewModel;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Web.Modulos.Teste
{
    public partial class CriancaListaPage
    {
        [Inject]public CriancaListaPageViewModel VM { get; set; }

        protected override async Task OnInitializedAsync()
        {
            VM.IsBusy = true;
            await VM.GetList();
        }
    }
}
