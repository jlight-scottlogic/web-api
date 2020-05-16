using System;

namespace Api.Data.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
