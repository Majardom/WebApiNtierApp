using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BllEntities.DTO
{
    public class SupplierDto : BaseDtoEntity
    {
        [StringLength(30), Required]
        public string Name { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
