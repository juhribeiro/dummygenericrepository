using System.Collections.Generic;

namespace Teste.Data
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}