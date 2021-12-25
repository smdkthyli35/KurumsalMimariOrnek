using Data.Abstract;
using Data.Concrete.EntityFramework.Contexts;
using Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private EfProductRepository _productRepository;
        private EfCategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository Products => _productRepository = _productRepository ?? new EfProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new EfCategoryRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
