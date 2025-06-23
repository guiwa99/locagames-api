namespace Senac.LocaGames.Domain.Repositories
{
  public interface IRepository<T> where T : class
  {
    Task<long> InsertAsync(T entity);
    Task DeleteAsync(long id);
    Task UpdateAsync(T entity);
    Task<T> GetAsync(long id);
  }
}
