using PresentationLayer.ViewModels;
using System.Windows.Controls;

namespace PresentationLayer.Views;

/// <summary>
///     Interaction logic for MainView.xaml
/// </summary>
public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void SearchButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var searchContext = SearchContext.Text;
        if (searchContext == null)
            return;

        var viewModel = DataContext as MainViewModel;
        viewModel.SearchCommand?.Execute(searchContext);
    }

    private void SearchContext_TextChanged(object sender, TextChangedEventArgs e)
    {
        var searchContext = SearchContext.Text;
        if (searchContext == null)
            return;

        var viewModel = DataContext as MainViewModel;
        viewModel.SearchCommand?.Execute(searchContext);
    }
}