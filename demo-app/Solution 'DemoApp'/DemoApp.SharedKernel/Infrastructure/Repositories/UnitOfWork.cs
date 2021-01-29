using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApp.SharedKernel.Infrastructure.Repositories
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly IServiceProvider _serviceProvider;
        private bool _disposed;
        private Dictionary<Type, object> _repositories;
        public TContext DbContext { get; }

        public UnitOfWork(IServiceProvider serviceProvider, TContext context)
        {
            _serviceProvider = serviceProvider;
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _repositories?.Clear();
                DbContext.Dispose();
            }

            _disposed = true;
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class
        {
            _repositories ??= new Dictionary<Type, object>();

            if (hasCustomRepository)
            {
                var handlerType = typeof(IRepository<>).MakeGenericType(typeof(TEntity));
                var customRepo = _serviceProvider.GetService(handlerType);
                if (customRepo != null) return customRepo as IRepository<TEntity>;
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(DbContext);
            return (IRepository<TEntity>)_repositories[type];
        }

        public int SaveChanges(bool ensureAutoHistory = false)
        {
            var affectedRows = DbContext.SaveChanges();
            return affectedRows;
        }

        public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
        {
            var affectedRows = await DbContext.SaveChangesAsync();
            return affectedRows;
        }
    }
}