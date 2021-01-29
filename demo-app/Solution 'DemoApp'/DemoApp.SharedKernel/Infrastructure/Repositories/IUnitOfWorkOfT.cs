using Microsoft.EntityFrameworkCore;

namespace DemoApp.SharedKernel.Infrastructure.Repositories
{
    public interface IUnitOfWork<out TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext DbContext { get; }
    }
}