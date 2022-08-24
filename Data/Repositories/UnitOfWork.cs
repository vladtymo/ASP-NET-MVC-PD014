using Data.Entities;
using System;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CompanyDbContext context;

        private IRepository<Category> categoryRepository;
        private IRepository<Product> productRepository;

        public UnitOfWork(CompanyDbContext context)
        {
            this.context = context;
        }
        public IRepository<Category> CategoryRepository
        {
            get
            {
                // Lazy Loading
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new Repository<Category>(context);
                }
                return categoryRepository;
            }
        }
        public IRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new Repository<Product>(context);
                }
                return productRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
