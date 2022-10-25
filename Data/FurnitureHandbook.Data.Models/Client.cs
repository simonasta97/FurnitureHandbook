namespace FurnitureHandbook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Models;

    public class Client : BaseDeletableModel<int>
    {
        public Client()
        {
            this.Projects = new HashSet<Project>();
        }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
