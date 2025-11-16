using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistence.Context;

namespace E_Commerce.Persistence.Repositories
{
    
    public class UnitOfWork(StoreDbContext context) : IUnitOfWork
    {
        private readonly Dictionary<string,object> _repositories = [];
        public IRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : Entity<Tkey>
        {
            var typeName = typeof(TEntity).Name;
            if(_repositories.TryGetValue(typeName,out object? value))
                return (value as IRepository<TEntity, Tkey>)!;

            var repository = new Repository<TEntity, Tkey>(context);

            _repositories.Add(typeName,repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        => await context.SaveChangesAsync();
    }
}
