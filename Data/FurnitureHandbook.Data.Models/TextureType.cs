namespace FurnitureHandbook.Data.Models
{
    using System.ComponentModel.DataAnnotations;

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
