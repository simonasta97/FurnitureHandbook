namespace FurnitureHandbook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Models;

    public class Size : BaseDeletableModel<int>
    {
        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }
    }
}
