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
    using Microsoft.EntityFrameworkCore.Metadata;

    public class ProjectViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public decimal TotalPrice { get; set; }

        public string ClientFullName { get; set; }

        public string ClientPhoneNumber { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Project, ProjectViewModel>();
        }
    }
}
