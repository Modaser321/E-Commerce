using E_Commerce.Domain.Entities;

namespace E_Commerce.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IRepository<TEntity,Tkey> GetRepository<TEntity,Tkey>() where TEntity : Entity<Tkey>;
    }
}
