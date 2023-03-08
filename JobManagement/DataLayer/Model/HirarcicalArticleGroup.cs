namespace DataLayer.Model
{
    public class HierarcicalArticleGroupEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? SuperiorArticleGroupId { get; set; }

        public int Hierarchy { get; set; }
    }
}