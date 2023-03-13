using PresentationLayer.ViewModels;
using System.Windows.Controls;

namespace PresentationLayer.Components
{
    /// <summary>
    /// Interaction logic for ArticleGroupGridView.xaml
    /// </summary>
    public partial class ArticleGroupGridView : UserControl
    {
        public ArticleGroupGridView()
        {
            InitializeComponent();
        }

        private void ArticleGroupTreeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            var viewModel = DataContext as ArticleGroupGridViewModel;
            var selectedItem = ArticleGroupTreeView.SelectedItem;
            if (selectedItem != null)
                viewModel.SelectedItem = selectedItem;
        }
    }
}
