using System.Threading.Tasks;

namespace PocIndustriaTextil.Core.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToPageAsync(string url);
        Task NavigateBack();
        Task NavigateToPageAsync(string url, string parameterKey, string parameterValue);
    }
}
