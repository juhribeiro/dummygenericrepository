namespace Teste.Data
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}