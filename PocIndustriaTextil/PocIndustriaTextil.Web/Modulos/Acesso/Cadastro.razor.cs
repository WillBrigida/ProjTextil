using Microsoft.AspNetCore.Components;
using PocIndustriaTextil.Core.Modulos.Acesso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Web.Modulos.Acesso
{
    public partial class Cadastro
    {
        [Inject]public CadastroViewModel VM { get; set; }
    }
}
