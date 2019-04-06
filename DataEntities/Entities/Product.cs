namespace DataEntities.Entities
{
    public class Product : BaseDalEntity
    {
        public string Name { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ProductCategory Category { get; set; }
    }
}
