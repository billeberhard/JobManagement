using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    public class OrderEvaluationEntity
    {
        public int Id { get; set; }
        public int CustomerNumber { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }
        
        [MaxLength(200)]
        public string StreetName { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string HouseNumber { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string PostalCode { get; set; }
        
        [MaxLength(100)]
        public string City { get; set; }

        public DateTime CreationDate { get; set; }

        public int OrderNumber { get; set; }

        public decimal TotalOrderPrice { get; set; }
    }
}