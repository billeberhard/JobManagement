using System.Windows.Input;

namespace PresentationLayer.ViewModels;

internal interface ICRUDDataViewModel : IUpdatable
{
    ICommand DeleteCommand { get; set; }
	ICommand SearchCommand { get; set; }
    object SelectedItem { get; set; }
}
