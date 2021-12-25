using Core.Data;
using Data.Abstract;
using Entities.Concrete;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IEntityRepository<Product> entityRepository) : base(unitOfWork, entityRepository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryById(productId);
        }
    }
}
