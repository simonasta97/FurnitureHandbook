﻿namespace FurnitureHandbook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Models;

    public class Furniture : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public int SizeId { get; set; }

        public virtual Size Size { get; set; }

        public int TextureId { get; set; }

        public virtual Texture Texture { get; set; }

        public int EdgebandId { get; set; }

        public virtual Edgeband Edgeband { get; set; }

        public int HardwareId { get; set; }

        public virtual Hardware Hardware { get; set; }

        public string Note { get; set; }
    }
}