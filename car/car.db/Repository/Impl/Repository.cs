using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;


namespace w.sale.car.db.Repository.Impl
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext context;
        public Repository(AppDbContext context)
        {
            this.context = context;
        }


        public async Task<List<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity?> GetQueryable()
        {
            return context.Set<TEntity>(); 
        }

        public void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);

        }
        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

    }
}
