using DataLayer.DataProvider;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    public class DataRepository
    {
        public ICustomerRepository Customers { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IArticleRepository Articles { get; private set; }
        public IArticleGroupRepository ArticleGroups { get; private set; }

        public DataRepository()
        {
            IDataProvider dataProvider = new SQLDataProvider();

            Customers = new CustomerRepository(dataProvider);
            Orders = new OrderRepository(dataProvider);
            Articles = new ArticleRepository(dataProvider);
            ArticleGroups = new ArticleGroupRepository(dataProvider);
        }

        public static void AddSampleData(DataRepository repo)
        {
            RemoveAllData(repo);


            Customer customer1 = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            Customer customer2 = new Customer() { FirstName = "Jane", LastName = "Smith", PostalCode = "10001", City = "New York", StreetName = "5th Ave", HouseNumber = "100", EmailAddress = "janesmith@example.com", WebsiteURL = "www.janesmith.com", Password = "pass456" };
            Customer customer3 = new Customer() { FirstName = "James", LastName = "Johnson", PostalCode = "60601", City = "Chicago", StreetName = "Michigan Ave", HouseNumber = "150", EmailAddress = "jamesjohnson@example.com", WebsiteURL = "www.jamesjohnson.com", Password = "pass789" };
            Customer customer4 = new Customer() { FirstName = "Emily", LastName = "Brown", PostalCode = "90001", City = "Los Angeles", StreetName = "Hollywood Blvd", HouseNumber = "250", EmailAddress = "emilybrown@example.com", WebsiteURL = "www.emilybrown.com", Password = "pass246" };
            Customer customer5 = new Customer() { FirstName = "Michael", LastName = "Davis", PostalCode = "80202", City = "Denver", StreetName = "16th St", HouseNumber = "300", EmailAddress = "michaeldavis@example.com", WebsiteURL = "www.michaeldavis.com", Password = "pass369" };
            Customer customer6 = new Customer() { FirstName = "Sarah", LastName = "Wilson", PostalCode = "77056", City = "Houston", StreetName = "Texas St", HouseNumber = "400", EmailAddress = "sarahwilson@example.com", WebsiteURL = "www.sarahwilson.com", Password = "pass159" };
            Customer customer7 = new Customer() { FirstName = "David", LastName = "Moore", PostalCode = "60604", City = "Chicago", StreetName = "Lake Shore Dr", HouseNumber = "450", EmailAddress = "davidmoore@example.com", WebsiteURL = "www.davidmoore.com", Password = "pass753" };
            Customer customer8 = new Customer() { FirstName = "Jessica", LastName = "Anderson", PostalCode = "75201", City = "Dallas", StreetName = "Main St", HouseNumber = "500", EmailAddress = "jessicaanderson@example.com", WebsiteURL = "www.jessicaanderson.com", Password = "pass852" };
            Customer customer9 = new Customer() { FirstName = "William", LastName = "Thomas", PostalCode = "02108", City = "Boston", StreetName = "Beacon St", HouseNumber = "550", EmailAddress = "williamthomas@example.com", WebsiteURL = "www.williamthomas.com", Password = "pass147" };
            Customer customer10 = new Customer() { FirstName = "Ashley", LastName = "Jackson", PostalCode = "98101", City = "Seattle", StreetName = "Pike St", HouseNumber = "600", EmailAddress = "ashleyjackson@example.com", WebsiteURL = "www.ashleyjackson.com", Password = "pass258" };
            Customer customer11 = new Customer() { FirstName = "Christopher", LastName = "White", PostalCode = "10013", City = "New York", StreetName = "Broadway", HouseNumber = "650", EmailAddress = "christopherwhite@example.com", WebsiteURL = "www.christopherwhite.com", Password = "pass369" };
            Customer customer12 = new Customer() { FirstName = "Elizabeth", LastName = "Harris", PostalCode = "33101", City = "Miami", StreetName = "Ocean Dr", HouseNumber = "700", EmailAddress = "elizabethharris@example.com", WebsiteURL = "www.elizabethharris.com", Password = "pass753" };
            Customer customer13 = new Customer() { FirstName = "Matthew", LastName = "Clark", PostalCode = "19102", City = "Philadelphia", StreetName = "Walnut St", HouseNumber = "750", EmailAddress = "matthewclark@example.com", WebsiteURL = "www.matthewclark.com", Password = "pass852" };
            Customer customer14 = new Customer() { FirstName = "Nathan", LastName = "Lewis", PostalCode = "94105", City = "San Francisco", StreetName = "Mission St", HouseNumber = "800", EmailAddress = "nathanlewis@example.com", WebsiteURL = "www.nathanlewis.com", Password = "pass963" };
            Customer customer15 = new Customer() { FirstName = "Andrew", LastName = "Walker", PostalCode = "60601", City = "Chicago", StreetName = "State St", HouseNumber = "900", EmailAddress = "andrewwalker@example.com", WebsiteURL = "www.andrewwalker.com", Password = "pass123" };
            Customer customer16 = new Customer() { FirstName = "Samantha", LastName = "Hall", PostalCode = "90001", City = "Los Angeles", StreetName = "Vine St", HouseNumber = "950", EmailAddress = "samanthahall@example.com", WebsiteURL = "www.samanthahall.com", Password = "pass456" };
            Customer customer17 = new Customer() { FirstName = "Daniel", LastName = "Allen", PostalCode = "80202", City = "Denver", StreetName = "Larimer St", HouseNumber = "1000", EmailAddress = "danielallen@example.com", WebsiteURL = "www.danielallen.com", Password = "pass789" };
            Customer customer18 = new Customer() { FirstName = "Ava", LastName = "King", PostalCode = "77056", City = "Houston", StreetName = "San Jacinto St", HouseNumber = "1050", EmailAddress = "avaking@example.com", WebsiteURL = "www.avaking.com", Password = "pass246" };
            Customer customer19 = new Customer() { FirstName = "Nicholas", LastName = "Wright", PostalCode = "60604", City = "Chicago", StreetName = "North Michigan Ave", HouseNumber = "1100", EmailAddress = "nicholaswright@example.com", WebsiteURL = "www.nicholaswright.com", Password = "pass369" };
            Customer customer20 = new Customer() { FirstName = "Isabelle", LastName = "Lopez", PostalCode = "75201", City = "Dallas", StreetName = "Main St", HouseNumber = "1150", EmailAddress = "isabellelopez@example.com", WebsiteURL = "www.isabellelopez.com", Password = "pass159" };
            Customer customer21 = new Customer() { FirstName = "Ethan", LastName = "Hill", PostalCode = "02108", City = "Boston", StreetName = "Marathon St", HouseNumber = "1200", EmailAddress = "ethanhill@example.com", WebsiteURL = "www.ethanhill.com", Password = "pass753" };
            Customer customer22 = new Customer() { FirstName = "Avery", LastName = "Green", PostalCode = "98101", City = "Seattle", StreetName = "Pike Pl", HouseNumber = "1250", EmailAddress = "averygreen@example.com", WebsiteURL = "www.averygreen.com", Password = "pass852" };
            Customer customer23 = new Customer() { FirstName = "Ella", LastName = "Adams", PostalCode = "10013", City = "New York", StreetName = "Madison Ave", HouseNumber = "1300", EmailAddress = "ellaadams@example.com", WebsiteURL = "www.ellaadams.com", Password = "pass963" };
            Customer customer24 = new Customer() { FirstName = "Alexander", LastName = "Nelson", PostalCode = "33101", City = "Miami", StreetName = "Ocean Dr", HouseNumber = "1350", EmailAddress = "alexandernelson@example.com", WebsiteURL = "www.alexandernelson.com", Password = "pass147" };

            repo.Customers.Add(customer1);
            repo.Customers.Add(customer1);
            repo.Customers.Add(customer2);
            repo.Customers.Add(customer3);
            repo.Customers.Add(customer4);
            repo.Customers.Add(customer5);
            repo.Customers.Add(customer6);
            repo.Customers.Add(customer7);
            repo.Customers.Add(customer8);
            repo.Customers.Add(customer9);
            repo.Customers.Add(customer10);
            repo.Customers.Add(customer11);
            repo.Customers.Add(customer12);
            repo.Customers.Add(customer13);
            repo.Customers.Add(customer14);
            repo.Customers.Add(customer15);
            repo.Customers.Add(customer16);
            repo.Customers.Add(customer17);
            repo.Customers.Add(customer18);
            repo.Customers.Add(customer19);
            repo.Customers.Add(customer20);
            repo.Customers.Add(customer21);
            repo.Customers.Add(customer22);
            repo.Customers.Add(customer23);
            repo.Customers.Add(customer24);


            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };
            ArticleGroup plane = new ArticleGroup() { Name = "Plane", SuperiorArticleGroup = vehicle };
            ArticleGroup truck = new ArticleGroup() { Name = "Truck", SuperiorArticleGroup = vehicle };
            ArticleGroup sportsCar = new ArticleGroup() { Name = "Sports Car", SuperiorArticleGroup = car };
            ArticleGroup sedan = new ArticleGroup() { Name = "Sedan", SuperiorArticleGroup = car };
            ArticleGroup helicopter = new ArticleGroup() { Name = "Helicopter", SuperiorArticleGroup = plane };
            ArticleGroup airliner = new ArticleGroup() { Name = "Airliner", SuperiorArticleGroup = plane };
            ArticleGroup pickupTruck = new ArticleGroup() { Name = "Pickup Truck", SuperiorArticleGroup = truck };

            repo.ArticleGroups.Add(vehicle);
            repo.ArticleGroups.Add(car);
            repo.ArticleGroups.Add(plane);
            repo.ArticleGroups.Add(truck);
            repo.ArticleGroups.Add(sportsCar);
            repo.ArticleGroups.Add(sedan);
            repo.ArticleGroups.Add(helicopter);
            repo.ArticleGroups.Add(airliner);
            repo.ArticleGroups.Add(pickupTruck);


            Article article1 = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };
            Article article2 = new Article() { Name = "nut", Price = 0.15M, ArticleGroup = vehicle };
            Article article3 = new Article() { Name = "wrench", Price = 2.5M, ArticleGroup = vehicle };
            Article article4 = new Article() { Name = "tire", Price = 35M, ArticleGroup = car };
            Article article5 = new Article() { Name = "spark plug", Price = 4M, ArticleGroup = car };
            Article article6 = new Article() { Name = "propeller", Price = 250M, ArticleGroup = plane };
            Article article7 = new Article() { Name = "engine", Price = 5000M, ArticleGroup = plane };
            Article article8 = new Article() { Name = "trailer hitch", Price = 120M, ArticleGroup = truck };
            Article article9 = new Article() { Name = "turbocharger", Price = 800M, ArticleGroup = sportsCar };
            Article article10 = new Article() { Name = "spoiler", Price = 500M, ArticleGroup = sportsCar };
            Article article11 = new Article() { Name = "door handle", Price = 25M, ArticleGroup = sedan };
            Article article12 = new Article() { Name = "windshield wiper", Price = 15M, ArticleGroup = sedan };
            Article article13 = new Article() { Name = "rotor blade", Price = 800M, ArticleGroup = helicopter };
            Article article14 = new Article() { Name = "fuel tank", Price = 200M, ArticleGroup = helicopter };
            Article article15 = new Article() { Name = "overhead bin", Price = 75M, ArticleGroup = airliner };
            Article article16 = new Article() { Name = "seat cushion", Price = 20M, ArticleGroup = airliner };
            Article article17 = new Article() { Name = "tailgate", Price = 400M, ArticleGroup = pickupTruck };
            Article article18 = new Article() { Name = "bed liner", Price = 300M, ArticleGroup = pickupTruck };

            repo.Articles.Add(article1);
            repo.Articles.Add(article2);
            repo.Articles.Add(article3);
            repo.Articles.Add(article4);
            repo.Articles.Add(article5);
            repo.Articles.Add(article6);
            repo.Articles.Add(article7);
            repo.Articles.Add(article8);
            repo.Articles.Add(article9);
            repo.Articles.Add(article10);
            repo.Articles.Add(article11);
            repo.Articles.Add(article12);
            repo.Articles.Add(article13);
            repo.Articles.Add(article14);
            repo.Articles.Add(article15);
            repo.Articles.Add(article16);
            repo.Articles.Add(article17);
            repo.Articles.Add(article18);


            DateTime date1 = new DateTime(2022, 01, 01, 12, 00, 00);
            DateTime date2 = new DateTime(2021, 05, 05, 14, 30, 00);
            DateTime date3 = new DateTime(2022, 09, 03, 16, 45, 00);
            DateTime date4 = new DateTime(2021, 11, 04, 18, 15, 00);
            DateTime date5 = new DateTime(2023, 03, 05, 19, 30, 00);

            Order order1 = new Order() { CreationDate = date1, Customer = customer1 };
            Order order6 = new Order() { CreationDate = date2, Customer = customer1 };
            Order order7 = new Order() { CreationDate = date3, Customer = customer1 };
            Order order8 = new Order() { CreationDate = date4, Customer = customer1 };
            Order order9 = new Order() { CreationDate = date5, Customer = customer1 };

            Order order2 = new Order() { CreationDate = date2, Customer = customer2 };
            Order order3 = new Order() { CreationDate = date3, Customer = customer3 };
            Order order4 = new Order() { CreationDate = date4, Customer = customer4 };
            Order order5 = new Order() { CreationDate = date5, Customer = customer5 };

            order1.Positions.Add(new Position() { Article = article1, Amount = 17 });
            order1.Positions.Add(new Position() { Article = article2, Amount = 3 });
            order1.Positions.Add(new Position() { Article = article3, Amount = 34 });
            order1.Positions.Add(new Position() { Article = article4, Amount = 235 });
            order1.Positions.Add(new Position() { Article = article5, Amount = 38 });
            order1.Positions.Add(new Position() { Article = article6, Amount = 2345 });
            order1.Positions.Add(new Position() { Article = article7, Amount = 15 });
            order1.Positions.Add(new Position() { Article = article8, Amount = 1469 });
            order1.Positions.Add(new Position() { Article = article9, Amount = 1 });
            order1.Positions.Add(new Position() { Article = article10, Amount = 3 });
            order1.Positions.Add(new Position() { Article = article1, Amount = 157 });
            order1.Positions.Add(new Position() { Article = article2, Amount = 3 });
            order1.Positions.Add(new Position() { Article = article3, Amount = 1 });
            order1.Positions.Add(new Position() { Article = article4, Amount = 2021 });
            order1.Positions.Add(new Position() { Article = article5, Amount = 34578 });
            order1.Positions.Add(new Position() { Article = article6, Amount = 12094 });
            order1.Positions.Add(new Position() { Article = article7, Amount = 15 });
            order1.Positions.Add(new Position() { Article = article1, Amount = 149 });
            order1.Positions.Add(new Position() { Article = article8, Amount = 1 });
            order1.Positions.Add(new Position() { Article = article10, Amount = 443 });
            order1.Positions.Add(new Position() { Article = article18, Amount = 499 });

            order2.Positions.Add(new Position() { Article = article1, Amount = 117 });
            order2.Positions.Add(new Position() { Article = article2, Amount = 3 });
            order2.Positions.Add(new Position() { Article = article3, Amount = 1 });
            order2.Positions.Add(new Position() { Article = article4, Amount = 2021 });
            order2.Positions.Add(new Position() { Article = article5, Amount = 38 });
            order2.Positions.Add(new Position() { Article = article6, Amount = 12094 });
            order2.Positions.Add(new Position() { Article = article7, Amount = 155 });
            order2.Positions.Add(new Position() { Article = article8, Amount = 19 });
            order2.Positions.Add(new Position() { Article = article9, Amount = 1 });
            order2.Positions.Add(new Position() { Article = article10, Amount = 43 });
            order2.Positions.Add(new Position() { Article = article1, Amount = 17 });
            order2.Positions.Add(new Position() { Article = article2, Amount = 3 });
            order2.Positions.Add(new Position() { Article = article3, Amount = 51 });
            order2.Positions.Add(new Position() { Article = article4, Amount = 62021 });
            order2.Positions.Add(new Position() { Article = article5, Amount = 386 });
            order2.Positions.Add(new Position() { Article = article6, Amount = 12094 });
            order2.Positions.Add(new Position() { Article = article7, Amount = 15 });
            order2.Positions.Add(new Position() { Article = article1, Amount = 1659 });
            order2.Positions.Add(new Position() { Article = article8, Amount = 1 });
            order2.Positions.Add(new Position() { Article = article10, Amount = 73 });
            order2.Positions.Add(new Position() { Article = article18, Amount = 989 });

            order3.Positions.Add(new Position() { Article = article1, Amount = 17 });
            order3.Positions.Add(new Position() { Article = article2, Amount = 3 });
            order3.Positions.Add(new Position() { Article = article3, Amount = 1 });
            order3.Positions.Add(new Position() { Article = article4, Amount = 2021 });
            order3.Positions.Add(new Position() { Article = article5, Amount = 38 });
            order3.Positions.Add(new Position() { Article = article6, Amount = 12094 });
            order3.Positions.Add(new Position() { Article = article7, Amount = 15 });
            order3.Positions.Add(new Position() { Article = article8, Amount = 19 });
            order3.Positions.Add(new Position() { Article = article9, Amount = 1 });
            order3.Positions.Add(new Position() { Article = article10, Amount = 3 });
            order3.Positions.Add(new Position() { Article = article1, Amount = 17 });
            order3.Positions.Add(new Position() { Article = article2, Amount = 3 });
            order3.Positions.Add(new Position() { Article = article3, Amount = 1 });
            order3.Positions.Add(new Position() { Article = article4, Amount = 2021 });
            order3.Positions.Add(new Position() { Article = article5, Amount = 38 });
            order3.Positions.Add(new Position() { Article = article6, Amount = 12094 });
            order3.Positions.Add(new Position() { Article = article7, Amount = 15 });
            order3.Positions.Add(new Position() { Article = article1, Amount = 19 });
            order3.Positions.Add(new Position() { Article = article8, Amount = 1 });
            order3.Positions.Add(new Position() { Article = article10, Amount = 3 });
            order3.Positions.Add(new Position() { Article = article18, Amount = 99 });

            order4.Positions.Add(new Position() { Article = article1, Amount = 5 });
            order4.Positions.Add(new Position() { Article = article2, Amount = 5 });
            //order4.Positions.Add(new Position() { Article = article3, Amount = 1 });
            //order4.Positions.Add(new Position() { Article = article4, Amount = 2021 });
            //order4.Positions.Add(new Position() { Article = article5, Amount = 38 });
            //order4.Positions.Add(new Position() { Article = article6, Amount = 12094 });
            //order4.Positions.Add(new Position() { Article = article7, Amount = 15 });
            //order4.Positions.Add(new Position() { Article = article8, Amount = 19 });
            //order4.Positions.Add(new Position() { Article = article9, Amount = 1 });
            //order4.Positions.Add(new Position() { Article = article10, Amount = 3 });
            //order4.Positions.Add(new Position() { Article = article1, Amount = 17 });
            //order4.Positions.Add(new Position() { Article = article2, Amount = 3 });
            //order4.Positions.Add(new Position() { Article = article3, Amount = 1 });
            //order4.Positions.Add(new Position() { Article = article4, Amount = 2021 });
            //order4.Positions.Add(new Position() { Article = article5, Amount = 38 });
            //order4.Positions.Add(new Position() { Article = article6, Amount = 12094 });
            //order4.Positions.Add(new Position() { Article = article7, Amount = 15 });
            //order4.Positions.Add(new Position() { Article = article1, Amount = 19 });
            //order4.Positions.Add(new Position() { Article = article8, Amount = 1 });
            //order4.Positions.Add(new Position() { Article = article10, Amount = 3 });
            //order4.Positions.Add(new Position() { Article = article18, Amount = 99 });

            order5.Positions.Add(new Position() { Article = article1, Amount = 1 });
            //order5.Positions.Add(new Position() { Article = article2, Amount = 3 });
            //order5.Positions.Add(new Position() { Article = article3, Amount = 1 });
            //order5.Positions.Add(new Position() { Article = article4, Amount = 2021 });
            //order5.Positions.Add(new Position() { Article = article5, Amount = 38 });
            //order5.Positions.Add(new Position() { Article = article6, Amount = 12094 });
            //order5.Positions.Add(new Position() { Article = article7, Amount = 15 });
            //order5.Positions.Add(new Position() { Article = article8, Amount = 19 });
            //order5.Positions.Add(new Position() { Article = article9, Amount = 1 });
            //order5.Positions.Add(new Position() { Article = article10, Amount = 3 });
            //order5.Positions.Add(new Position() { Article = article1, Amount = 17 });
            //order5.Positions.Add(new Position() { Article = article2, Amount = 3 });
            //order5.Positions.Add(new Position() { Article = article3, Amount = 1 });
            //order5.Positions.Add(new Position() { Article = article4, Amount = 2021 });
            //order5.Positions.Add(new Position() { Article = article5, Amount = 38 });
            //order5.Positions.Add(new Position() { Article = article6, Amount = 12094 });
            //order5.Positions.Add(new Position() { Article = article7, Amount = 15 });
            //order5.Positions.Add(new Position() { Article = article1, Amount = 19 });
            //order5.Positions.Add(new Position() { Article = article8, Amount = 1 });
            //order5.Positions.Add(new Position() { Article = article10, Amount = 3 });
            //order5.Positions.Add(new Position() { Article = article18, Amount = 99 });
            
            order6.Positions.Add(new Position() { Article = article1, Amount = 1 });
            order7.Positions.Add(new Position() { Article = article1, Amount = 1 });
            order8.Positions.Add(new Position() { Article = article1, Amount = 1 });
            order9.Positions.Add(new Position() { Article = article1, Amount = 1 });


            repo.Orders.Add(order1);
            repo.Orders.Add(order2);
            repo.Orders.Add(order3);
            repo.Orders.Add(order4);
            repo.Orders.Add(order5);
            repo.Orders.Add(order6);
            repo.Orders.Add(order7);
            repo.Orders.Add(order8);
            repo.Orders.Add(order9);
        }
        public static void RemoveAllData(DataRepository repo)
        {
            repo.Customers.Clear();
            repo.Orders.Clear();
            // repo.Positions.Clear();
            repo.Articles.Clear();
            repo.ArticleGroups.Clear();
        }
    }
}
