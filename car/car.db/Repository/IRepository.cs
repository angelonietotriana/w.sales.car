namespace w.sale.car.db.Repository
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        IQueryable<TEntity?> GetQueryable();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity id);
        Task SaveChangesAsync();
        Task<int> SaveChanges();
    }
}
