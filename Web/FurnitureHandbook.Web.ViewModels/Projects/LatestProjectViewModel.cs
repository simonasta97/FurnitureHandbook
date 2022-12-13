namespace FurnitureHandbook.Web.ViewModels.Projects
{
    using System;
    using System.Linq;

    using AutoMapper;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Mapping;

    public class LatestProjectViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public decimal TotalPrice { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Project, ProjectViewModel>();
        }
    }
}