using PresentationLayer.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PresentationLayer.Components
{
    /// <summary>
    /// Interaction logic for CustomersGridView.xaml
    /// </summary>
    public partial class CustomersGridView : UserControl
    {
        public CustomersGridView()
        {
            InitializeComponent();
        }

        private void DataGridOrderData_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as CustomerGridViewModel;
            viewModel.LoadCommand?.Execute(null);
        }
    }
}
