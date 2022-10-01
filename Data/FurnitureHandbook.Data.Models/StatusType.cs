namespace FurnitureHandbook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public enum StatusType
    {
        [Display(Name = "Активен")]
        Active = 1,
        [Display(Name = "Завършен")]
        Completed = 2,
        [Display(Name = "Отказан")]
        Cancelled = 3,
    }
}
