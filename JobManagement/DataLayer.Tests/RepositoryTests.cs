using DataLayer.Repository;
using DataLayer.TransferObjects;
using NUnit.Framework;

namespace DataLayerTests
{
    public abstract class RepositoryTests
    {
        [SetUp]
        public void SetUp()
        {
            DataRepository.RemoveAllData(repo);
        }

        [TearDown]
        public void TearDown()
        {
            DataRepository.AddSampleData(repo);
        }


        protected DataRepository repo = new DataRepository();

        protected ICollection<Customer> GetSampleCustomers()
        {
            return new List<Customer>()
            {
                new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" },
                new Customer() { FirstName = "Jane", LastName = "Smith", PostalCode = "10001", City = "New York", StreetName = "5th Ave", HouseNumber = "100", EmailAddress = "janesmith@example.com", WebsiteURL = "www.janesmith.com", Password = "pass456" },
                new Customer() { FirstName = "James", LastName = "Johnson", PostalCode = "60601", City = "Chicago", StreetName = "Michigan Ave", HouseNumber = "150", EmailAddress = "jamesjohnson@example.com", WebsiteURL = "www.jamesjohnson.com", Password = "pass789" },
                new Customer() { FirstName = "Emily", LastName = "Brown", PostalCode = "90001", City = "Los Angeles", StreetName = "Hollywood Blvd", HouseNumber = "250", EmailAddress = "emilybrown@example.com", WebsiteURL = "www.emilybrown.com", Password = "pass246" },
                new Customer() { FirstName = "Michael", LastName = "Davis", PostalCode = "80202", City = "Denver", StreetName = "16th St", HouseNumber = "300", EmailAddress = "michaeldavis@example.com", WebsiteURL = "www.michaeldavis.com", Password = "pass369" },
                new Customer() { FirstName = "Sarah", LastName = "Wilson", PostalCode = "77056", City = "Houston", StreetName = "Texas St", HouseNumber = "400", EmailAddress = "sarahwilson@example.com", WebsiteURL = "www.sarahwilson.com", Password = "pass159" },
                new Customer() { FirstName = "David", LastName = "Moore", PostalCode = "60604", City = "Chicago", StreetName = "Lake Shore Dr", HouseNumber = "450", EmailAddress = "davidmoore@example.com", WebsiteURL = "www.davidmoore.com", Password = "pass753" },
                new Customer() { FirstName = "Jessica", LastName = "Anderson", PostalCode = "75201", City = "Dallas", StreetName = "Main St", HouseNumber = "500", EmailAddress = "jessicaanderson@example.com", WebsiteURL = "www.jessicaanderson.com", Password = "pass852" },
                new Customer() { FirstName = "William", LastName = "Thomas", PostalCode = "02108", City = "Boston", StreetName = "Beacon St", HouseNumber = "550", EmailAddress = "williamthomas@example.com", WebsiteURL = "www.williamthomas.com", Password = "pass147" },
                new Customer() { FirstName = "Ashley", LastName = "Jackson", PostalCode = "98101", City = "Seattle", StreetName = "Pike St", HouseNumber = "600", EmailAddress = "ashleyjackson@example.com", WebsiteURL = "www.ashleyjackson.com", Password = "pass258" },
                new Customer() { FirstName = "Christopher", LastName = "White", PostalCode = "10013", City = "New York", StreetName = "Broadway", HouseNumber = "650", EmailAddress = "christopherwhite@example.com", WebsiteURL = "www.christopherwhite.com", Password = "pass369" },
                new Customer() { FirstName = "Elizabeth", LastName = "Harris", PostalCode = "33101", City = "Miami", StreetName = "Ocean Dr", HouseNumber = "700", EmailAddress = "elizabethharris@example.com", WebsiteURL = "www.elizabethharris.com", Password = "pass753" },
                new Customer() { FirstName = "Matthew", LastName = "Clark", PostalCode = "19102", City = "Philadelphia", StreetName = "Walnut St", HouseNumber = "750", EmailAddress = "matthewclark@example.com", WebsiteURL = "www.matthewclark.com", Password = "pass852" },
                new Customer() { FirstName = "Nathan", LastName = "Lewis", PostalCode = "94105", City = "San Francisco", StreetName = "Mission St", HouseNumber = "800", EmailAddress = "nathanlewis@example.com", WebsiteURL = "www.nathanlewis.com", Password = "pass963" },
                new Customer() { FirstName = "Andrew", LastName = "Walker", PostalCode = "60601", City = "Chicago", StreetName = "State St", HouseNumber = "900", EmailAddress = "andrewwalker@example.com", WebsiteURL = "www.andrewwalker.com", Password = "pass123" },
                new Customer() { FirstName = "Samantha", LastName = "Hall", PostalCode = "90001", City = "Los Angeles", StreetName = "Vine St", HouseNumber = "950", EmailAddress = "samanthahall@example.com", WebsiteURL = "www.samanthahall.com", Password = "pass456" },
                new Customer() { FirstName = "Daniel", LastName = "Allen", PostalCode = "80202", City = "Denver", StreetName = "Larimer St", HouseNumber = "1000", EmailAddress = "danielallen@example.com", WebsiteURL = "www.danielallen.com", Password = "pass789" },
                new Customer() { FirstName = "Ava", LastName = "King", PostalCode = "77056", City = "Houston", StreetName = "San Jacinto St", HouseNumber = "1050", EmailAddress = "avaking@example.com", WebsiteURL = "www.avaking.com", Password = "pass246" },
                new Customer() { FirstName = "Nicholas", LastName = "Wright", PostalCode = "60604", City = "Chicago", StreetName = "North Michigan Ave", HouseNumber = "1100", EmailAddress = "nicholaswright@example.com", WebsiteURL = "www.nicholaswright.com", Password = "pass369" },
                new Customer() { FirstName = "Isabelle", LastName = "Lopez", PostalCode = "75201", City = "Dallas", StreetName = "Main St", HouseNumber = "1150", EmailAddress = "isabellelopez@example.com", WebsiteURL = "www.isabellelopez.com", Password = "pass159" },
                new Customer() { FirstName = "Ethan", LastName = "Hill", PostalCode = "02108", City = "Boston", StreetName = "Marathon St", HouseNumber = "1200", EmailAddress = "ethanhill@example.com", WebsiteURL = "www.ethanhill.com", Password = "pass753" },
                new Customer() { FirstName = "Avery", LastName = "Green", PostalCode = "98101", City = "Seattle", StreetName = "Pike Pl", HouseNumber = "1250", EmailAddress = "averygreen@example.com", WebsiteURL = "www.averygreen.com", Password = "pass852" },
                new Customer() { FirstName = "Ella", LastName = "Adams", PostalCode = "10013", City = "New York", StreetName = "Madison Ave", HouseNumber = "1300", EmailAddress = "ellaadams@example.com", WebsiteURL = "www.ellaadams.com", Password = "pass963" },
                new Customer() { FirstName = "Alexander", LastName = "Nelson", PostalCode = "33101", City = "Miami", StreetName = "Ocean Dr", HouseNumber = "1350", EmailAddress = "alexandernelson@example.com", WebsiteURL = "www.alexandernelson.com", Password = "pass147" }

            };
        }
        protected ICollection<ArticleGroup> GetSampleArticleGroups()
        {
            ICollection<ArticleGroup> articleGroups = new List<ArticleGroup>();

            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };
            ArticleGroup plane = new ArticleGroup() { Name = "Plane", SuperiorArticleGroup = vehicle };
            ArticleGroup truck = new ArticleGroup() { Name = "Truck", SuperiorArticleGroup = vehicle };
            ArticleGroup sportsCar = new ArticleGroup() { Name = "Sports Car", SuperiorArticleGroup = car };
            ArticleGroup sedan = new ArticleGroup() { Name = "Sedan", SuperiorArticleGroup = car };
            ArticleGroup helicopter = new ArticleGroup() { Name = "Helicopter", SuperiorArticleGroup = plane };
            ArticleGroup airliner = new ArticleGroup() { Name = "Airliner", SuperiorArticleGroup = plane };
            ArticleGroup pickupTruck = new ArticleGroup() { Name = "Pickup Truck", SuperiorArticleGroup = truck };

            articleGroups.Add(vehicle);
            articleGroups.Add(car);
            articleGroups.Add(plane);
            articleGroups.Add(truck);
            articleGroups.Add(sportsCar);
            articleGroups.Add(sedan);
            articleGroups.Add(helicopter);
            articleGroups.Add(airliner);
            articleGroups.Add(pickupTruck);

            return articleGroups;
        }

        protected ICollection<Article> GetSampleArticles()
        {
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };
            ArticleGroup plane = new ArticleGroup() { Name = "Plane", SuperiorArticleGroup = vehicle };
            ArticleGroup truck = new ArticleGroup() { Name = "Truck", SuperiorArticleGroup = vehicle };
            ArticleGroup sportsCar = new ArticleGroup() { Name = "Sports Car", SuperiorArticleGroup = car };
            ArticleGroup sedan = new ArticleGroup() { Name = "Sedan", SuperiorArticleGroup = car };
            ArticleGroup helicopter = new ArticleGroup() { Name = "Helicopter", SuperiorArticleGroup = plane };
            ArticleGroup airliner = new ArticleGroup() { Name = "Airliner", SuperiorArticleGroup = plane };
            ArticleGroup pickupTruck = new ArticleGroup() { Name = "Pickup Truck", SuperiorArticleGroup = truck };

            return new List<Article>()
            {
                new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle },
                new Article() { Name = "nut", Price = 0.15M, ArticleGroup = vehicle },
                new Article() { Name = "wrench", Price = 2.5M, ArticleGroup = vehicle },
                new Article() { Name = "tire", Price = 35M, ArticleGroup = car },
                new Article() { Name = "spark plug", Price = 4M, ArticleGroup = car },
                new Article() { Name = "propeller", Price = 250M, ArticleGroup = plane },
                new Article() { Name = "engine", Price = 5000M, ArticleGroup = plane },
                new Article() { Name = "trailer hitch", Price = 120M, ArticleGroup = truck },
                new Article() { Name = "turbocharger", Price = 800M, ArticleGroup = sportsCar },
                new Article() { Name = "spoiler", Price = 500M, ArticleGroup = sportsCar },
                new Article() { Name = "door handle", Price = 25M, ArticleGroup = sedan },
                new Article() { Name = "windshield wiper", Price = 15M, ArticleGroup = sedan },
                new Article() { Name = "rotor blade", Price = 800M, ArticleGroup = helicopter },
                new Article() { Name = "fuel tank", Price = 200M, ArticleGroup = helicopter },
                new Article() { Name = "overhead bin", Price = 75M, ArticleGroup = airliner },
                new Article() { Name = "seat cushion", Price = 20M, ArticleGroup = airliner },
                new Article() { Name = "tailgate", Price = 400M, ArticleGroup = pickupTruck },
                new Article() { Name = "bed liner", Price = 300M, ArticleGroup = pickupTruck }
            };
        }

        protected void AddAll(ICollection<Customer> customers)
        {
            foreach (Customer c in customers)
                repo.Customers.Add(c);
        }
        protected void AddAll(ICollection<ArticleGroup> articleGroup)
        {
            foreach (ArticleGroup c in articleGroup)
                repo.ArticleGroups.Add(c);
        }
        protected void AddAll(ICollection<Article> articleGroup)
        {
            foreach (Article c in articleGroup)
                repo.Articles.Add(c);
        }
    }
}