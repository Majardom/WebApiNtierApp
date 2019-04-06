using System.ComponentModel.DataAnnotations;

namespace BllEntities.DTO
{
    public class ProductDto : BaseDtoEntity
    {
        [StringLength(30), Required]
        public string Name { get; set; }
        [Required]
        public ProductCategoryDto Category { get; set; }
        [Required]
        public SupplierDto Supplier { get; set; }
    }
}
