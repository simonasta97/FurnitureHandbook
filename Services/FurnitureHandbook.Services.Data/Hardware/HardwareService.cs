namespace FurnitureHandbook.Services.Data.Hardware
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Web.ViewModels.Furnitures;

    public class HardwareService : IHardwareService
    {
        private readonly IDeletableEntityRepository<Hardware> hardwaresRepository;

        public HardwareService(IDeletableEntityRepository<Hardware> hardwaresRepository)
        {
            this.hardwaresRepository = hardwaresRepository;
        }

        public async Task<int?> CreateAsync(CreateFurnitureInputModel furnitureModel)
        {
            var hardware = new Hardware
            {
                HandleModel = furnitureModel.HandleModel,
                MechanismType = furnitureModel.MechanismType,
                MechanismQuantity = furnitureModel.MechanismQuantity,
                HingeType = furnitureModel.HingeType,
                HingeQuantity = furnitureModel.HingeQuantity,
            };

            await this.hardwaresRepository.AddAsync(hardware);
            await this.hardwaresRepository.SaveChangesAsync();

            var createdHardware = this.hardwaresRepository
                .All()
                .FirstOrDefault(x => x.HandleModel == furnitureModel.HandleModel
                    && x.MechanismType == furnitureModel.MechanismType
                    && x.MechanismQuantity == furnitureModel.MechanismQuantity
                    && x.HingeType == furnitureModel.HingeType
                    && x.HingeQuantity == furnitureModel.HingeQuantity);

            return createdHardware.Id;
        }
    }
}
