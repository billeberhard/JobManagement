using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model
{
    public class ArticleEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public virtual ArticleGroupEntity ArticleGroup { get; set; }
    }
}