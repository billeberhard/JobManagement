using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class OrderEvaluation
    {
        public OrderEvaluation()
        {}
        internal OrderEvaluation(OrderEvaluationEntity entity)
        {
            CustomerNumber = entity.CustomerNumber;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            StreetName = entity.StreetName;
            HouseNumber = entity.HouseNumber;
            PostalCode = entity.PostalCode;
            City = entity.City;
            CreationDate = entity.CreationDate;
            OrderNumber = entity.OrderNumber;
            TotalOrderPrice = entity.TotalOrderPrice;
    }

        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public DateTime CreationDate { get; set; }
        public int OrderNumber { get; set; }
        public decimal TotalOrderPrice { get; set; }
    }

    public class OrderEvaluationFilterCriterias
    {
        public int CustomerNumber { get; set; } = -1;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public DateTime MinCreationDate { get; set; } = new DateTime(1753, 1, 1, 0, 0, 0);
        public DateTime MaxCreationDate { get; set; } = DateTime.MaxValue;
        public int OrderNumber { get; set; } = -1;
        public decimal MinTotalOrderPrice { get; set; } = -1;
        public decimal MaxTotalOrderPrice { get; set; } = -1;
    }
}