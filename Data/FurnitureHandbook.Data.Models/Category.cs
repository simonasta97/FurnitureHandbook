namespace FurnitureHandbook.Data.Models
{
    using System.Collections.Generic;

    using FurnitureHandbook.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Projects = new HashSet<Project>();
            this.Documents = new HashSet<Document>();
        }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
