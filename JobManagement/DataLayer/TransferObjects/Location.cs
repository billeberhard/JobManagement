//using DataLayer.Model;

//namespace DataLayer.TransferObjects
//{
//    public class Location
//    {
//        public Location(string postalCode, string name)
//        {
//            PostalCode = postalCode;
//            Name = name;
//        }
//        internal Location(LocationEntity entity)
//        {
//            LocationId = entity.LocationId;
//            PostalCode = entity.PostalCode;
//            Name = entity.Name;
//        }

//        internal int LocationId { get; set; }
//        public string PostalCode { get; set; }
//        public string Name { get; set; }

//        internal LocationEntity ConvertToEntity()
//        {
//            return new LocationEntity()
//            {
//                PostalCode = PostalCode,
//                Name = Name
//            };
//        }
//        public override string? ToString()
//        {
//            return $"{PostalCode}, {Name}";
//        }
//        public override bool Equals(object? obj)
//        {
//            return obj is Location location &&
//                   LocationId == location.LocationId;
//        }
//        public bool DataEquals(object? obj)
//        {
//            return obj is Location location &&
//                   PostalCode == location.PostalCode &&
//                   Name == location.Name;
//        }
//        public override int GetHashCode()
//        {
//            return HashCode.Combine(LocationId, PostalCode, Name);
//        }
//    }
//}