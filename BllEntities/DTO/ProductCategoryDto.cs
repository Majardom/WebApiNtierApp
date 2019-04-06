using System.ComponentModel.DataAnnotations;

namespace BllEntities.DTO
{
    public class ProductCategoryDto : BaseDtoEntity
    {
        [StringLength(30), Required]
        public string Name { get; set; }
    }
}
