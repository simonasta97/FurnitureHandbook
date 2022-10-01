namespace FurnitureHandbook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Models;

    public class Edgeband : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public double Thickness { get; set; }

        public string ManufacturerName { get; set; }
    }
}
