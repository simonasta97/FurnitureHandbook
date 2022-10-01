namespace FurnitureHandbook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Models;

    public class Hardware : BaseDeletableModel<int>
    {
        public string HandleModel { get; set; }

        public string MechanismType { get; set; }

        public int MechanismQuantity { get; set; }

        public string HingeType { get; set; }

        public int HingeQuantity { get; set; }
    }
}
