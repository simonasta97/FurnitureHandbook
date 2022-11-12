namespace FurnitureHandbook.Web.ViewModels.Furnitures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Mapping;
    using FurnitureHandbook.Web.ViewModels.Projects;

    public class SingleFurnitureViewModel : IMapFrom<Furniture>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string ImageUrl { get; set; }

        public string TextureName { get; set; }

        public string TextureType { get; set; }

        public string TextureManufacturerName { get; set; }

        public string TextureTextureCode { get; set; }

        public string EdgebandName { get; set; }

        public double EdgebandThickness { get; set; }

        public string EdgebandManufacturerName { get; set; }

        public string HardwareHandleModel { get; set; }

        public string HardwareMechanismType { get; set; }

        public string HardwareMechanismQuantity { get; set; }

        public string HardwareHingeType { get; set; }

        public string HardwareHingeQuantity { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Furniture, SingleFurnitureViewModel>();
        }
    }
}
