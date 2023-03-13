using System.Windows.Input;

namespace PresentationLayer.ViewModels;

internal interface ICRUDDataViewModel
{
    ICommand LoadCommand { get; set; }
    ICommand DeleteCommand { get; set; }
	ICommand SearchCommand { get; set; }
    object SelectedItem { get; set; }
}
