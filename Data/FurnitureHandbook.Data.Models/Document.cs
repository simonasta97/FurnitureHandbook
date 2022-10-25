namespace FurnitureHandbook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Models;

    public class Document : BaseDeletableModel<int>
    {
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string FileUrl { get; set; }

        public FileType FileType { get; set; }
    }
}
