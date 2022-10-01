namespace FurnitureHandbook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public enum TextureType
    {
        [Display(Name = "ПДЧ")]
        CHIPBOARD = 1,
        [Display(Name = "МДФ")]
        MDF = 2,
        [Display(Name = "Друг")]
        Other = 3,
    }
}
