using DataLayer.Repository;
using DataLayer.TransferObjects;
using System.Collections.Generic;
using System.Windows;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //DataRepository.AddSampleData(m_Repository);

            InitializeComponent();
        }
        private void CustomerButton_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow = new CustomerWindow(m_Repository);
            // DataRepository.AddSampleData(m_Repository);
            ICollection<HierarcicalArticleGroup> hirarchicalArticleGroups = m_Repository.ArticleGroups.GetHirarcicalArticleGroups();
            ICollection<OrderEvaluation> orderEvaluations = m_Repository.Orders.GetOrderEvaluations(new OrderEvaluationFilterCriterias() { });

            customerWindow.Show();
        }
        
        private DataRepository m_Repository = new DataRepository();
    }
}
