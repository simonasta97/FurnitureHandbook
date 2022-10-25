namespace FurnitureHandbook.Data.Models
{
    using System;
    using System.Collections.Generic;

    using FurnitureHandbook.Data.Common.Models;

    public class Project : BaseDeletableModel<string>
    {
        public Project()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Furnitures = new HashSet<Furniture>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DownPayment { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public StatusType Status { get; set; }

        public int? ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Furniture> Furnitures { get; set; }
    }
}
