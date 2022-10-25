namespace FurnitureHandbook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Models;

    public class Texture : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public TextureType Type { get; set; }

        public string ManufacturerName { get; set; }

        public string TextureCode { get; set; }
    }
}
