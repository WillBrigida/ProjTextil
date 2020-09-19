using Microsoft.AspNetCore.Components;
using PocIndustriaTextil.Core;
using PocIndustriaTextil.Core.Services.Api;
using PocIndustriaTextil.Core.Teste;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Web.Pages
{
    public partial class Teste
    {
        [Inject]protected CriancasViewModel VM { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await VM.GetList();
        }
    }
}
