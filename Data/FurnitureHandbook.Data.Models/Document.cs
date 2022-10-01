namespace FurnitureHandbook.Data.Models
{
    using FurnitureHandbook.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Document : BaseDeletableModel<int>
    {
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string FileUrl { get; set; }

        public FileType FileType { get; set; }
    }
}
