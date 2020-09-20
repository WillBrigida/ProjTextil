using PocIndustriaTextil.Core.Modulos.Acesso;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocIndustriaTextil.Mobile.Modulos.Acesso
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroPage : ContentPage
    {
        public CadastroViewModel VM { get; set; }
        public CadastroPage()
        {
            InitializeComponent();
            BindingContext = VM = new CadastroViewModel();
        }
    }
}