using System.Data;

namespace Senac.LocaGames.Infra.Data.DatabaseConfiguration
{
  public interface IDbConnectionFactory
  {
    IDbConnection CreateConnection();
  }
}
