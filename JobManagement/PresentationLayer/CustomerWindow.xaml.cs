using DataLayer.Repository;
using DataLayer.TransferObjects;
using System.Collections.Generic;
using System.Windows;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow(DataRepository repository)
        {
            InitializeComponent();
            m_Repository = repository;

            m_Customers = m_Repository.Customers.GetAll();

            CustomerList.ItemsSource = m_Customers;
        }


        private void CustomerList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Customer? customer = CustomerList.SelectedItem as Customer;
            if (customer == null)
                return;

            ICollection<Order> ordersOfCustomer = new List<Order>();//m_Repository.Customers.GetAllOrders(customer);

            OrdersOfCustomer.ItemsSource = ordersOfCustomer;
        }

        DataRepository m_Repository;
        private ICollection<Customer> m_Customers;
    }
}
