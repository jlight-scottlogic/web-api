using System;

namespace Api.Models
{
    public class ProductCreateModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
