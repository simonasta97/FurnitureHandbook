namespace FurnitureHandbook.Services.Data.Hardware
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Web.ViewModels.Furnitures;

    public interface IHardwareService
    {
        public Task<int?> CreateAsync(CreateFurnitureInputModel furnitureModel);
    }
}
