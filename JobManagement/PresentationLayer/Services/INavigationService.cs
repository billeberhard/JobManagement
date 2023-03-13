using PresentationLayer.Core;

namespace PresentationLayer.Services
{
    public interface INavigationService
    {
        ViewModel CurrentView { get; }
        TViewModel NavigateTo<TViewModel>() where TViewModel: ViewModel;
    }
}
