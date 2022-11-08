namespace FurnitureHandbook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Models;

    public class Document : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int Size { get; set; }

        public string FileUrl { get; set; }

        public FileType FileType { get; set; }
    }
}
