using DataLayer.Repository;
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
            // CreateSampleData();

            InitializeComponent();
        }
        private void CustomerButton_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow = new CustomerWindow(m_Repository);
            //m_Repository.ArticleGroups.GetArticleGroupTreesView();
            DataRepository.AddSampleData(m_Repository);

            customerWindow.Show();
        }
        //private void CreateSampleData()
        //{
        //    m_Repository.Customers.Clear();
        //    m_Repository.Locations.Clear();
        //    m_Repository.Positions.Clear();
        //    m_Repository.Orders.Clear();
        //    m_Repository.Articles.Clear();
        //    m_Repository.ArticleGroups.Clear();



        //    Location location1 = new Location("94105", "San Francisco");
        //    Location location2 = new Location("10001", "New York");
        //    Location location3 = new Location("60601", "Chicago");
        //    Location location4 = new Location("90001", "Los Angeles");
        //    Location location5 = new Location("80202", "Denver");
        //    Location location6 = new Location("77056", "Houston");
        //    Location location7 = new Location("60604", "Chicago");
        //    Location location8 = new Location("75201", "Dallas");
        //    Location location9 = new Location("02108", "Boston");
        //    Location location10 = new Location("98101", "Seattle");
        //    Location location11 = new Location("10013", "New York");
        //    Location location12 = new Location("33101", "Miami");
        //    Location location13 = new Location("19102", "Philadelphia");

        //    m_Repository.Locations.Add(location1);
        //    m_Repository.Locations.Add(location1);
        //    m_Repository.Locations.Add(location2);
        //    m_Repository.Locations.Add(location3);
        //    m_Repository.Locations.Add(location4);
        //    m_Repository.Locations.Add(location5);
        //    m_Repository.Locations.Add(location6);
        //    m_Repository.Locations.Add(location7);
        //    m_Repository.Locations.Add(location8);
        //    m_Repository.Locations.Add(location9);
        //    m_Repository.Locations.Add(location10);
        //    m_Repository.Locations.Add(location11);
        //    m_Repository.Locations.Add(location12);
        //    m_Repository.Locations.Add(location13);



        //    Customer customer1 = new Customer("John", "Doe", location1, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");
        //    Customer customer2 = new Customer("Jane", "Smith", location2, "5th Ave", "100", "janesmith@example.com", "www.janesmith.com", "pass456");
        //    Customer customer3 = new Customer("James", "Johnson", location3, "Michigan Ave", "150", "jamesjohnson@example.com", "www.jamesjohnson.com", "pass789");
        //    Customer customer4 = new Customer("Emily", "Brown", location4, "Hollywood Blvd", "250", "emilybrown@example.com", "www.emilybrown.com", "pass246");
        //    Customer customer5 = new Customer("Michael", "Davis", location5, "16th St", "300", "michaeldavis@example.com", "www.michaeldavis.com", "pass369");
        //    Customer customer6 = new Customer("Sarah", "Wilson", location6, "Texas St", "400", "sarahwilson@example.com", "www.sarahwilson.com", "pass159");
        //    Customer customer7 = new Customer("David", "Moore", location7, "Lake Shore Dr", "450", "davidmoore@example.com", "www.davidmoore.com", "pass753");
        //    Customer customer8 = new Customer("Jessica", "Anderson", location8, "Main St", "500", "jessicaanderson@example.com", "www.jessicaanderson.com", "pass852");
        //    Customer customer9 = new Customer("William", "Thomas", location9, "Beacon St", "550", "williamthomas@example.com", "www.williamthomas.com", "pass147");
        //    Customer customer10 = new Customer("Ashley", "Jackson", location10, "Pike St", "600", "ashleyjackson@example.com", "www.ashleyjackson.com", "pass258");
        //    Customer customer11 = new Customer("Christopher", "White", location11, "Broadway", "650", "christopherwhite@example.com", "www.christopherwhite.com", "pass369");
        //    Customer customer12 = new Customer("Elizabeth", "Harris", location12, "Ocean Dr", "700", "elizabethharris@example.com", "www.elizabethharris.com", "pass753");
        //    Customer customer13 = new Customer("Matthew", "Clark", location13, "Walnut St", "750", "matthewclark@example.com", "www.matthewclark.com", "pass852");
        //    Customer customer14 = new Customer("Nathan", "Lewis", location1, "Mission St", "800", "nathanlewis@example.com", "www.nathanlewis.com", "pass963");
        //    Customer customer15 = new Customer("Andrew", "Walker", location3, "State St", "900", "andrewwalker@example.com", "www.andrewwalker.com", "pass123");
        //    Customer customer16 = new Customer("Samantha", "Hall", location4, "Vine St", "950", "samanthahall@example.com", "www.samanthahall.com", "pass456");
        //    Customer customer17 = new Customer("Daniel", "Allen", location5, "Larimer St", "1000", "danielallen@example.com", "www.danielallen.com", "pass789");
        //    Customer customer18 = new Customer("Ava", "King", location6, "San Jacinto St", "1050", "avaking@example.com", "www.avaking.com", "pass246");
        //    Customer customer19 = new Customer("Nicholas", "Wright", location7, "North Michigan Ave", "1100", "nicholaswright@example.com", "www.nicholaswright.com", "pass369");
        //    Customer customer20 = new Customer("Isabelle", "Lopez", location8, "Main St", "1150", "isabellelopez@example.com", "www.isabellelopez.com", "pass159");
        //    Customer customer21 = new Customer("Ethan", "Hill", location9, "Marathon St", "1200", "ethanhill@example.com", "www.ethanhill.com", "pass753");
        //    Customer customer22 = new Customer("Avery", "Green", location10, "Pike Pl", "1250", "averygreen@example.com", "www.averygreen.com", "pass852");
        //    Customer customer23 = new Customer("Ella", "Adams", location11, "Madison Ave", "1300", "ellaadams@example.com", "www.ellaadams.com", "pass963");
        //    Customer customer24 = new Customer("Alexander", "Nelson", location12, "Ocean Dr", "1350", "alexandernelson@example.com", "www.alexandernelson.com", "pass147");

        //    m_Repository.Customers.Add(customer1);
        //    m_Repository.Customers.Add(customer1);
        //    m_Repository.Customers.Add(customer2);
        //    m_Repository.Customers.Add(customer3);
        //    m_Repository.Customers.Add(customer4);
        //    m_Repository.Customers.Add(customer5);
        //    m_Repository.Customers.Add(customer6);
        //    m_Repository.Customers.Add(customer7);
        //    m_Repository.Customers.Add(customer8);
        //    m_Repository.Customers.Add(customer9);
        //    m_Repository.Customers.Add(customer10);
        //    m_Repository.Customers.Add(customer11);
        //    m_Repository.Customers.Add(customer12);
        //    m_Repository.Customers.Add(customer13);
        //    m_Repository.Customers.Add(customer14);
        //    m_Repository.Customers.Add(customer15);
        //    m_Repository.Customers.Add(customer16);
        //    m_Repository.Customers.Add(customer17);
        //    m_Repository.Customers.Add(customer18);
        //    m_Repository.Customers.Add(customer19);
        //    m_Repository.Customers.Add(customer20);
        //    m_Repository.Customers.Add(customer21);
        //    m_Repository.Customers.Add(customer22);
        //    m_Repository.Customers.Add(customer23);
        //    m_Repository.Customers.Add(customer24);



        //    DateTime date1 = new DateTime(2023, 01, 01, 12, 00, 00);
        //    DateTime date2 = new DateTime(2023, 01, 02, 14, 30, 00);
        //    DateTime date3 = new DateTime(2023, 01, 03, 16, 45, 00);
        //    DateTime date4 = new DateTime(2023, 01, 04, 18, 15, 00);
        //    DateTime date5 = new DateTime(2023, 01, 05, 19, 30, 00);

        //    Order order1 = new Order(date1, customer1);
        //    Order order2 = new Order(date2, customer2);
        //    Order order3 = new Order(date3, customer3);
        //    Order order4 = new Order(date4, customer4);
        //    Order order5 = new Order(date5, customer5);

        //    m_Repository.Orders.Add(order1);
        //    m_Repository.Orders.Add(order1);
        //    m_Repository.Orders.Add(order1);
        //    m_Repository.Orders.Add(order2);
        //    m_Repository.Orders.Add(order3);
        //    m_Repository.Orders.Add(order4);
        //    m_Repository.Orders.Add(order5);



        //    ArticleGroup vehicle = new ArticleGroup("Vehicle");
        //    ArticleGroup car = new ArticleGroup("Car", vehicle);
        //    ArticleGroup plane = new ArticleGroup("Plane", vehicle);
        //    ArticleGroup truck = new ArticleGroup("Truck", vehicle);
        //    ArticleGroup sportsCar = new ArticleGroup("Sports Car", car);
        //    ArticleGroup sedan = new ArticleGroup("Sedan", car);
        //    ArticleGroup helicopter = new ArticleGroup("Helicopter", plane);
        //    ArticleGroup airliner = new ArticleGroup("Airliner", plane);
        //    ArticleGroup pickupTruck = new ArticleGroup("Pickup Truck", truck);

        //    m_Repository.ArticleGroups.Add(vehicle);
        //    m_Repository.ArticleGroups.Add(car);
        //    m_Repository.ArticleGroups.Add(plane);
        //    m_Repository.ArticleGroups.Add(truck);
        //    m_Repository.ArticleGroups.Add(sportsCar);
        //    m_Repository.ArticleGroups.Add(sedan);
        //    m_Repository.ArticleGroups.Add(helicopter);
        //    m_Repository.ArticleGroups.Add(airliner);
        //    m_Repository.ArticleGroups.Add(pickupTruck);



        //    Article article1 = new Article("screw", 0.35M, vehicle);
        //    Article article2 = new Article("nut", 0.15M, vehicle);
        //    Article article3 = new Article("wrench", 2.5M, vehicle);
        //    Article article4 = new Article("tire", 35M, car);
        //    Article article5 = new Article("spark plug", 4M, car);
        //    Article article6 = new Article("propeller", 250M, plane);
        //    Article article7 = new Article("engine", 5000M, plane);
        //    Article article8 = new Article("trailer hitch", 120M, truck);
        //    Article article9 = new Article("turbocharger", 800M, sportsCar);
        //    Article article10 = new Article("spoiler", 500M, sportsCar);
        //    Article article11 = new Article("door handle", 25M, sedan);
        //    Article article12 = new Article("windshield wiper", 15M, sedan);
        //    Article article13 = new Article("rotor blade", 800M, helicopter);
        //    Article article14 = new Article("fuel tank", 200M, helicopter);
        //    Article article15 = new Article("overhead bin", 75M, airliner);
        //    Article article16 = new Article("seat cushion", 20M, airliner);
        //    Article article17 = new Article("tailgate", 400M, pickupTruck);
        //    Article article18 = new Article("bed liner", 300M, pickupTruck);

        //    m_Repository.Articles.Add(article1);
        //    m_Repository.Articles.Add(article2);
        //    m_Repository.Articles.Add(article3);
        //    m_Repository.Articles.Add(article4);
        //    m_Repository.Articles.Add(article5);
        //    m_Repository.Articles.Add(article6);
        //    m_Repository.Articles.Add(article7);
        //    m_Repository.Articles.Add(article8);
        //    m_Repository.Articles.Add(article9);
        //    m_Repository.Articles.Add(article10);
        //    m_Repository.Articles.Add(article11);
        //    m_Repository.Articles.Add(article12);
        //    m_Repository.Articles.Add(article13);
        //    m_Repository.Articles.Add(article14);
        //    m_Repository.Articles.Add(article15);
        //    m_Repository.Articles.Add(article16);
        //    m_Repository.Articles.Add(article17);
        //    m_Repository.Articles.Add(article18);


        //    Position position1 = new Position(article1, 17, order1);
        //    Position position2 = new Position(article2 , 3, order1);
        //    Position position3 = new Position(article3, 1, order1);
        //    Position position4 = new Position(article4, 2021, order1);
        //    Position position5 = new Position(article5, 38, order1);
        //    Position position6 = new Position(article6, 12094, order1);
        //    Position position7 = new Position(article7, 15, order1);
        //    Position position8 = new Position(article8, 19, order1);
        //    Position position9 = new Position(article9, 1, order1);
        //    Position position10 = new Position(article10, 3, order1);

        //    Position position11 = new Position(article1, 17, order2);
        //    Position position12 = new Position(article2, 3, order2);
        //    Position position13 = new Position(article3, 1, order2);
        //    Position position14 = new Position(article4, 2021, order2);
        //    Position position15 = new Position(article5, 38, order2);
        //    Position position16 = new Position(article6, 12094, order2);
        //    Position position17 = new Position(article7, 15, order2);
        //    Position position18 = new Position(article1, 19, order2);
        //    Position position19 = new Position(article8, 1, order2);
        //    Position position20 = new Position(article10, 3, order2);

        //    Position position21 = new Position(article18, 99, order3);

        //    m_Repository.Positions.Add(position1);
        //    m_Repository.Positions.Add(position2);
        //    m_Repository.Positions.Add(position3);
        //    m_Repository.Positions.Add(position4);
        //    m_Repository.Positions.Add(position5);
        //    m_Repository.Positions.Add(position6);
        //    m_Repository.Positions.Add(position7);
        //    m_Repository.Positions.Add(position8);
        //    m_Repository.Positions.Add(position9);
        //    m_Repository.Positions.Add(position10);
        //    m_Repository.Positions.Add(position11);
        //    m_Repository.Positions.Add(position12);
        //    m_Repository.Positions.Add(position13);
        //    m_Repository.Positions.Add(position14);
        //    m_Repository.Positions.Add(position15);
        //    m_Repository.Positions.Add(position16);
        //    m_Repository.Positions.Add(position17);
        //    m_Repository.Positions.Add(position18);
        //    m_Repository.Positions.Add(position19);
        //    m_Repository.Positions.Add(position20);
        //    m_Repository.Positions.Add(position21);

        //}

        private DataRepository m_Repository = new DataRepository();
    }
}
