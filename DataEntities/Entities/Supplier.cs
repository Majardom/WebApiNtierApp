using System.Collections.Generic;

namespace DataEntities.Entities
{
    public class Supplier : BaseDalEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
