using DataLayer.Repository;
using DataLayer.TransferObjects;
using System;
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
            CreateSampleData();

            InitializeComponent();
        }

        private void CustomerButton_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow = new CustomerWindow(m_Repository);
            customerWindow.Show();
        }

        private void CreateSampleData()
        {
            m_Repository.Locations.Clear();
            m_Repository.Customers.Clear();
            m_Repository.Orders.Clear();
            m_Repository.Articles.Clear();
            m_Repository.ArticleGroups.Clear();
            m_Repository.Positions.Clear();

            Location location1 = new Location("94105", "San Francisco");
            Location location2 = new Location("10001", "New York");
            Location location3 = new Location("60601", "Chicago");
            Location location4 = new Location("90001", "Los Angeles");
            Location location5 = new Location("80202", "Denver");
            Location location6 = new Location("77056", "Houston");
            Location location7 = new Location("60604", "Chicago");
            Location location8 = new Location("75201", "Dallas");
            Location location9 = new Location("02108", "Boston");
            Location location10 = new Location("98101", "Seattle");
            Location location11 = new Location("10013", "New York");
            Location location12 = new Location("33101", "Miami");
            Location location13 = new Location("19102", "Philadelphia");

            m_Repository.Locations.Add(location1);
            m_Repository.Locations.Add(location1);
            m_Repository.Locations.Add(location2);
            m_Repository.Locations.Add(location3);
            m_Repository.Locations.Add(location4);
            m_Repository.Locations.Add(location5);
            m_Repository.Locations.Add(location6);
            m_Repository.Locations.Add(location7);
            m_Repository.Locations.Add(location8);
            m_Repository.Locations.Add(location9);
            m_Repository.Locations.Add(location10);
            m_Repository.Locations.Add(location11);
            m_Repository.Locations.Add(location12);
            m_Repository.Locations.Add(location13);



            Customer customer1 = new Customer(1, "John", "Doe", location1, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");
            Customer customer2 = new Customer(2, "Jane", "Smith", location2, "5th Ave", "100", "janesmith@example.com", "www.janesmith.com", "pass456");
            Customer customer3 = new Customer(3, "James", "Johnson", location3, "Michigan Ave", "150", "jamesjohnson@example.com", "www.jamesjohnson.com", "pass789");
            Customer customer4 = new Customer(4, "Emily", "Brown", location4, "Hollywood Blvd", "250", "emilybrown@example.com", "www.emilybrown.com", "pass246");
            Customer customer5 = new Customer(5, "Michael", "Davis", location5, "16th St", "300", "michaeldavis@example.com", "www.michaeldavis.com", "pass369");
            Customer customer6 = new Customer(6, "Sarah", "Wilson", location6, "Texas St", "400", "sarahwilson@example.com", "www.sarahwilson.com", "pass159");
            Customer customer7 = new Customer(7, "David", "Moore", location7, "Lake Shore Dr", "450", "davidmoore@example.com", "www.davidmoore.com", "pass753");
            Customer customer8 = new Customer(8, "Jessica", "Anderson", location8, "Main St", "500", "jessicaanderson@example.com", "www.jessicaanderson.com", "pass852");
            Customer customer9 = new Customer(9, "William", "Thomas", location9, "Beacon St", "550", "williamthomas@example.com", "www.williamthomas.com", "pass147");
            Customer customer10 = new Customer(10, "Ashley", "Jackson", location10, "Pike St", "600", "ashleyjackson@example.com", "www.ashleyjackson.com", "pass258");
            Customer customer11 = new Customer(11, "Christopher", "White", location11, "Broadway", "650", "christopherwhite@example.com", "www.christopherwhite.com", "pass369");
            Customer customer12 = new Customer(12, "Elizabeth", "Harris", location12, "Ocean Dr", "700", "elizabethharris@example.com", "www.elizabethharris.com", "pass753");
            Customer customer13 = new Customer(13, "Matthew", "Clark", location13, "Walnut St", "750", "matthewclark@example.com", "www.matthewclark.com", "pass852");
            Customer customer14 = new Customer(14, "Nathan", "Lewis", location1, "Mission St", "800", "nathanlewis@example.com", "www.nathanlewis.com", "pass963");
            Customer customer15 = new Customer(15, "Andrew", "Walker", location3, "State St", "900", "andrewwalker@example.com", "www.andrewwalker.com", "pass123");
            Customer customer16 = new Customer(16, "Samantha", "Hall", location4, "Vine St", "950", "samanthahall@example.com", "www.samanthahall.com", "pass456");
            Customer customer17 = new Customer(17, "Daniel", "Allen", location5, "Larimer St", "1000", "danielallen@example.com", "www.danielallen.com", "pass789");
            Customer customer18 = new Customer(18, "Ava", "King", location6, "San Jacinto St", "1050", "avaking@example.com", "www.avaking.com", "pass246");
            Customer customer19 = new Customer(19, "Nicholas", "Wright", location7, "North Michigan Ave", "1100", "nicholaswright@example.com", "www.nicholaswright.com", "pass369");
            Customer customer20 = new Customer(20, "Isabelle", "Lopez", location8, "Main St", "1150", "isabellelopez@example.com", "www.isabellelopez.com", "pass159");
            Customer customer21 = new Customer(21, "Ethan", "Hill", location9, "Marathon St", "1200", "ethanhill@example.com", "www.ethanhill.com", "pass753");
            Customer customer22 = new Customer(22, "Avery", "Green", location10, "Pike Pl", "1250", "averygreen@example.com", "www.averygreen.com", "pass852");
            Customer customer23 = new Customer(23, "Ella", "Adams", location11, "Madison Ave", "1300", "ellaadams@example.com", "www.ellaadams.com", "pass963");
            Customer customer24 = new Customer(24, "Alexander", "Nelson", location12, "Ocean Dr", "1350", "alexandernelson@example.com", "www.alexandernelson.com", "pass147");

            m_Repository.Customers.Add(customer1);
            m_Repository.Customers.Add(customer1);
            m_Repository.Customers.Add(customer2);
            m_Repository.Customers.Add(customer3);
            m_Repository.Customers.Add(customer4);
            m_Repository.Customers.Add(customer5);
            m_Repository.Customers.Add(customer6);
            m_Repository.Customers.Add(customer7);
            m_Repository.Customers.Add(customer8);
            m_Repository.Customers.Add(customer9);
            m_Repository.Customers.Add(customer10);
            m_Repository.Customers.Add(customer11);
            m_Repository.Customers.Add(customer12);
            m_Repository.Customers.Add(customer13);
            m_Repository.Customers.Add(customer14);
            m_Repository.Customers.Add(customer15);
            m_Repository.Customers.Add(customer16);
            m_Repository.Customers.Add(customer17);
            m_Repository.Customers.Add(customer18);
            m_Repository.Customers.Add(customer19);
            m_Repository.Customers.Add(customer20);
            m_Repository.Customers.Add(customer21);
            m_Repository.Customers.Add(customer22);
            m_Repository.Customers.Add(customer23);
            m_Repository.Customers.Add(customer24);


            DateTime date1 = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order1 = new Order(date1, customer1);

            DateTime date2 = new DateTime(2023, 01, 02, 14, 30, 00);
            Order order2 = new Order(date2, customer2);

            DateTime date3 = new DateTime(2023, 01, 03, 16, 45, 00);
            Order order3 = new Order(date3, customer3);

            DateTime date4 = new DateTime(2023, 01, 04, 18, 15, 00);
            Order order4 = new Order(date4, customer4);

            DateTime date5 = new DateTime(2023, 01, 05, 19, 30, 00);
            Order order5 = new Order(date5, customer5);


            m_Repository.Orders.Add(order1);
            m_Repository.Orders.Add(order1);
            m_Repository.Orders.Add(order1);
            m_Repository.Orders.Add(order2);
            m_Repository.Orders.Add(order3);
            m_Repository.Orders.Add(order4);
            m_Repository.Orders.Add(order5);
        }


        private DataRepository m_Repository = new DataRepository();
    }
}
