namespace FurnitureHandbook.Web.ViewModels.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Mapping;

    public class SingleProjectViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ClientFullName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DownPayment { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Furniture> Furnitures { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Project, SingleProjectViewModel>();
        }
    }
}
