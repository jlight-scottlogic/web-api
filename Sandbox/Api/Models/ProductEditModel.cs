using System;

namespace Api.Models
{
    public class ProductEditModel : ProductCreateModel
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; }
    }
}
