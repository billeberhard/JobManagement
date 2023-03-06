namespace DataLayer.TransferObjects.View
{
    public struct ArticleGroupTreeItem
    {
        public int ArticleGroupId { get; set; }
        public string Name { get; set; }
        public string SuperiorArticleGroupId { get; set; }
        public ICollection<ArticleGroupTreeItem> SubordinateArticleGroups { get; set; }
    }
}
