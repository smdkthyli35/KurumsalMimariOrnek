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
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IEntityRepository<Category> entityRepository) : base(unitOfWork, entityRepository)
        {
        }

        public async Task<Category> GetWithProductByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
