using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model
{
    public class PositionEntity
    {
        public int Id { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public virtual ArticleEntity Article { get; set; }

        [Required]
        public virtual OrderEntity Order { get; set; }
    }
}