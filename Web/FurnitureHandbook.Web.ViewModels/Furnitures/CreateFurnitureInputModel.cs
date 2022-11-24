namespace FurnitureHandbook.Web.ViewModels.Furnitures
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    using static FurnitureHandbook.Common.GlobalConstants;
    using static FurnitureHandbook.Common.GlobalConstants.Furniture;

    using Furniture = FurnitureHandbook.Data.Models.Furniture;

    public class CreateFurnitureInputModel : IMapFrom<Furniture>
    {
        public string ProjectId { get; set; }

        [Display(Name = "Мебел")]
        [Required(ErrorMessage = "Полето 'Мебел' е задължително.")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа.")]
        public string Name { get; set; }

        [Display(Name = "Цвят")]
        [Required(ErrorMessage = "Полето 'Цвят' е задължително.")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа.")]
        public string Color { get; set; }

        [Display(Name = "Снимка")]
        [Required(ErrorMessage = "Снимката е задължителна.")]
        public IFormFile Image { get; set; }

        [Display(Name = "Дължина")]
        [Required(ErrorMessage = "Полето 'Дължина' е задължително.")]
        public decimal Length { get; set; }

        [Display(Name = "Ширина")]
        [Required(ErrorMessage = "Полето 'Ширина' е задължително.")]
        public decimal Width { get; set; }

        [Display(Name = "Дълбочина")]
        [Required(ErrorMessage = "Полето 'Дълбочина' е задължително.")]
        public decimal Depth { get; set; }

        [Display(Name = "Материал")]
        public int? TextureId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Textures { get; set; }

        [Display(Name = "Кант")]
        public int? EdgebandId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Edgebands { get; set; }

        [Display(Name = "Материал")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа.")]
        public string TextureName { get; set; }

        [Display(Name = "Вид на материала")]
        public TextureType TextureType { get; set; }

        [Display(Name = "Производител")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа.")]
        public string TextureManufacturerName { get; set; }

        [Display(Name = "Код")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа.")]
        public string TextureCode { get; set; }

        [Display(Name = "Кант")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа.")]
        public string EdgebandName { get; set; }

        [Display(Name = "Дебелина на кант(мм.)")]
        [Range(0.32, 2)]
        public double EdgebandThickness { get; set; }

        [Display(Name = "Производител")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа.")]
        public string EdgebandManufacturerName { get; set; }

        [Display(Name = "Модел дръжки")]
        public string HandleModel { get; set; }

        [Display(Name = "Механизми")]
        public string MechanismType { get; set; }

        [Display(Name = "Количество механизми")]
        public int MechanismQuantity { get; set; }

        [Display(Name = "Панти")]
        public string HingeType { get; set; }

        [Display(Name = "Количество панти")]
        public int HingeQuantity { get; set; }

        [Display(Name = "Мебелен обков")]

        public int? HardwareId { get; set; }
    }
}
