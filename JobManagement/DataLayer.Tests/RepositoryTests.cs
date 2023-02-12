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
            RemoveAllDataFromRepo();
        }

        [TearDown]
        public void TearDown()
        {
            RemoveAllDataFromRepo();
        }


        protected DataRepository repo = new DataRepository();
        protected void RemoveAllDataFromRepo()
        {
            repo.Customers.Clear();
            repo.Locations.Clear();
            repo.Orders.Clear();
            repo.Positions.Clear();
            repo.Articles.Clear();
            repo.ArticleGroups.Clear();
        }
        protected Location GetSampleLocation()
        {
            return new Location("94105", "San Francisco");
        }
        protected ICollection<Location> GetSampleLocations()
        {
            return new List<Location>()
            {
                new Location("94105", "San Francisco"),
                new Location("10001", "New York"),
                new Location("60601", "Chicago"),
                new Location("90001", "Los Angeles"),
                new Location("80202", "Denver"),
                new Location("77056", "Houston"),
                new Location("60604", "Chicago"),
                new Location("75201", "Dallas"),
                new Location("02108", "Boston"),
                new Location("98101", "Seattle"),
                new Location("10013", "New York"),
                new Location("33101", "Miami"),
                new Location("19102", "Philadelphia")
            };
        }
        protected ICollection<Customer> GetSampleCustomers()
        {
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

            return new List<Customer>()
            {
                new Customer("John", "Doe", location1, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123"),
                new Customer("Jane", "Smith", location2, "5th Ave", "100", "janesmith@example.com", "www.janesmith.com", "pass456"),
                new Customer("James", "Johnson", location3, "Michigan Ave", "150", "jamesjohnson@example.com", "www.jamesjohnson.com", "pass789"),
                new Customer("Emily", "Brown", location4, "Hollywood Blvd", "250", "emilybrown@example.com", "www.emilybrown.com", "pass246"),
                new Customer("Michael", "Davis", location5, "16th St", "300", "michaeldavis@example.com", "www.michaeldavis.com", "pass369"),
                new Customer("Sarah", "Wilson", location6, "Texas St", "400", "sarahwilson@example.com", "www.sarahwilson.com", "pass159"),
                new Customer("David", "Moore", location7, "Lake Shore Dr", "450", "davidmoore@example.com", "www.davidmoore.com", "pass753"),
                new Customer("Jessica", "Anderson", location8, "Main St", "500", "jessicaanderson@example.com", "www.jessicaanderson.com", "pass852"),
                new Customer("William", "Thomas", location9, "Beacon St", "550", "williamthomas@example.com", "www.williamthomas.com", "pass147"),
                new Customer("Ashley", "Jackson", location10, "Pike St", "600", "ashleyjackson@example.com", "www.ashleyjackson.com", "pass258"),
                new Customer("Christopher", "White", location11, "Broadway", "650", "christopherwhite@example.com", "www.christopherwhite.com", "pass369"),
                new Customer("Elizabeth", "Harris", location12, "Ocean Dr", "700", "elizabethharris@example.com", "www.elizabethharris.com", "pass753"),
                new Customer("Matthew", "Clark", location13, "Walnut St", "750", "matthewclark@example.com", "www.matthewclark.com", "pass852"),
                new Customer("Nathan", "Lewis", location1, "Mission St", "800", "nathanlewis@example.com", "www.nathanlewis.com", "pass963"),
                new Customer("Andrew", "Walker", location3, "State St", "900", "andrewwalker@example.com", "www.andrewwalker.com", "pass123"),
                new Customer("Samantha", "Hall", location4, "Vine St", "950", "samanthahall@example.com", "www.samanthahall.com", "pass456"),
                new Customer("Daniel", "Allen", location5, "Larimer St", "1000", "danielallen@example.com", "www.danielallen.com", "pass789"),
                new Customer("Ava", "King", location6, "San Jacinto St", "1050", "avaking@example.com", "www.avaking.com", "pass246"),
                new Customer("Nicholas", "Wright", location7, "North Michigan Ave", "1100", "nicholaswright@example.com", "www.nicholaswright.com", "pass369"),
                new Customer("Isabelle", "Lopez", location8, "Main St", "1150", "isabellelopez@example.com", "www.isabellelopez.com", "pass159"),
                new Customer("Ethan", "Hill", location9, "Marathon St", "1200", "ethanhill@example.com", "www.ethanhill.com", "pass753"),
                new Customer("Avery", "Green", location10, "Pike Pl", "1250", "averygreen@example.com", "www.averygreen.com", "pass852"),
                new Customer("Ella", "Adams", location11, "Madison Ave", "1300", "ellaadams@example.com", "www.ellaadams.com", "pass963"),
                new Customer("Alexander", "Nelson", location12, "Ocean Dr", "1350", "alexandernelson@example.com", "www.alexandernelson.com", "pass147")
             };
        }
        protected ICollection<ArticleGroup> GetSampleArticleGroups()
        {
            ICollection<ArticleGroup> articleGroups = new List<ArticleGroup>();

            ArticleGroup vehicle = new ArticleGroup("Vehicle");
            ArticleGroup car = new ArticleGroup("Car", vehicle);
            ArticleGroup plane = new ArticleGroup("Plane", vehicle);
            ArticleGroup truck = new ArticleGroup("Truck", vehicle);
            ArticleGroup sportsCar = new ArticleGroup("Sports Car", car);
            ArticleGroup sedan = new ArticleGroup("Sedan", car);
            ArticleGroup helicopter = new ArticleGroup("Helicopter", plane);
            ArticleGroup airliner = new ArticleGroup("Airliner", plane);
            ArticleGroup pickupTruck = new ArticleGroup("Pickup Truck", truck);

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
            ArticleGroup vehicle = new ArticleGroup("Vehicle");
            ArticleGroup car = new ArticleGroup("Car", vehicle);
            ArticleGroup plane = new ArticleGroup("Plane", vehicle);
            ArticleGroup truck = new ArticleGroup("Truck", vehicle);
            ArticleGroup sportsCar = new ArticleGroup("Sports Car", car);
            ArticleGroup sedan = new ArticleGroup("Sedan", car);
            ArticleGroup helicopter = new ArticleGroup("Helicopter", plane);
            ArticleGroup airliner = new ArticleGroup("Airliner", plane);
            ArticleGroup pickupTruck = new ArticleGroup("Pickup Truck", truck);

            return new List<Article>()
            {
                new Article("screw", 0.35M, vehicle),
                new Article("nut", 0.15M, vehicle),
                new Article("wrench", 2.5M, vehicle),
                new Article("tire", 35M, car),
                new Article("spark plug", 4M, car),
                new Article("propeller", 250M, plane),
                new Article("engine", 5000M, plane),
                new Article("trailer hitch", 120M, truck),
                new Article("turbocharger", 800M, sportsCar),
                new Article("spoiler", 500M, sportsCar),
                new Article("door handle", 25M, sedan),
                new Article("windshield wiper", 15M, sedan),
                new Article("rotor blade", 800M, helicopter),
                new Article("fuel tank", 200M, helicopter),
                new Article("overhead bin", 75M, airliner),
                new Article("seat cushion", 20M, airliner),
                new Article("tailgate", 400M, pickupTruck),
                new Article("bed liner", 300M, pickupTruck)
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