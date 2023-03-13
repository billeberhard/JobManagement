using PresentationLayer.ViewModels;
using System.Windows.Controls;

namespace PresentationLayer.Components;

/// <summary>
///     Interaction logic for JobView.xaml
/// </summary>
public partial class OrderGridView : UserControl
{
    private OrderGridViewModel m_OrderGridViewModel = new OrderGridViewModel();
    public OrderGridView()
    {
        DataContext = m_OrderGridViewModel;
        InitializeComponent();
    }

    private void OrderGridView_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        m_OrderGridViewModel.LoadCommand?.Execute(null);
    }
}