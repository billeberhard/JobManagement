using DataLayer.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.TransferObjects
{
    public class HierarcicalArticleGroup
    {
        public HierarcicalArticleGroup()
        {}
        internal HierarcicalArticleGroup(HierarcicalArticleGroupEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            SuperiorArticleGroupId = entity.SuperiorArticleGroupId;
            Hierarchy = entity.Hierarchy;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int? SuperiorArticleGroupId { get; set; }

        public int Hierarchy { get; set; }
    }
}