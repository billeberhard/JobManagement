using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Location
    {
        public Location(string postalCode, string name)
        {
            PostalCode = postalCode;
            Name = name;
        }
        public Location(LocationEntity entity)
        {
            PostalCode = entity.PostalCode;
            Name = entity.Name;
        }

        public string PostalCode { get; set; }
        public string Name { get; set; }

        public LocationEntity ConvertToEntity()
        {
            return new LocationEntity
            {
                PostalCode = PostalCode,
                Name = Name
            };
        }
        public override string? ToString()
        {
            return $"{PostalCode}, {Name}";
        }
        public override bool Equals(object? obj)
        {
            return obj is Location location &&
                   PostalCode == location.PostalCode &&
                   Name == location.Name;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(PostalCode, Name);
        }
    }
}