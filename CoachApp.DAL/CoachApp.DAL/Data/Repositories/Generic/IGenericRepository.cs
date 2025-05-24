namespace CoachApp.DAL.Data.Repositories.Generic;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    Task DeleteByIdAsync(int id);
    Task SaveChangesAsync();
    void Delete(TEntity entity);
}
