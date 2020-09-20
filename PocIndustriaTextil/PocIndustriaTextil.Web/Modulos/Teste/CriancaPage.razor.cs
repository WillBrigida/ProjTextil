using Microsoft.AspNetCore.Components;
using PocIndustriaTextil.Core.Modulos.Teste.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Web.Modulos.Teste
{
    public partial class CriancaPage
    {
        [Inject]protected CriancaPageViewModel VM { get; set; }
    }
}
