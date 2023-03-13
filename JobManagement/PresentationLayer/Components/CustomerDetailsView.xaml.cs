using PresentationLayer.ViewModels;
using System.Windows.Controls;

namespace PresentationLayer.Components
{
    /// <summary>
    /// Interaction logic for CustomerDetailsView.xaml
    /// </summary>
    public partial class CustomerDetailsView : UserControl
    {
        public CustomerDetailsView()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = DataContext as CustomerDetailsViewModel;
            viewModel.SaveCommand?.Execute(null);
        }

        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = DataContext as CustomerDetailsViewModel;
            viewModel.CancelCommand?.Execute(null);
        }
    }
}
