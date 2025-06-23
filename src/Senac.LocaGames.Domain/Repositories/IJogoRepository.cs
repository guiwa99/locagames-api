using Senac.LocaGames.Domain.Models;

namespace Senac.LocaGames.Domain.Repositories
{
  public interface IJogoRepository : IRepository<Jogo>
  {
    Task<IEnumerable<Jogo>> GetAllAsync();
  }
}
