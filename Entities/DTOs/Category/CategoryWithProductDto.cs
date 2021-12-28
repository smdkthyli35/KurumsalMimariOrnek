using Entities.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Category
{
    public class CategoryWithProductDto : CategoryDto
    {
        public IEnumerable<ProductDto> Product { get; set; }
    }
}
