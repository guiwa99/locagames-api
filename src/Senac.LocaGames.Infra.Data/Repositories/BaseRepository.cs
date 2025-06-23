using Senac.LocaGames.Domain.Repositories;
using Senac.LocaGames.Infra.Data.DatabaseConfiguration;
using System.Data;

namespace Senac.LocaGames.Infra.Data.Repositories
{
  public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    private readonly IDbConnectionFactory _connectionFactory;

    protected IDbConnection Connection => _connectionFactory.CreateConnection();

    protected BaseRepository(IDbConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }

    public abstract Task DeleteAsync(long id);

    public abstract Task<TEntity> GetAsync(long id);

    public abstract Task<long> InsertAsync(TEntity entity);

    public abstract Task UpdateAsync(TEntity entity);
  }
}
