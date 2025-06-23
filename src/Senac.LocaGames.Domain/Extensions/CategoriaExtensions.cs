using Senac.LocaGames.Domain.Models;

namespace Senac.LocaGames.Domain.Extensions
{
  public static class CategoriaExtensions
  {
    public static int GetPrazo(this Categoria categoria)
    {
      return categoria switch
      {
        Categoria.BRONZE => 9,
        Categoria.PRATA => 6,
        Categoria.OURO => 3,
        _ => throw new ArgumentOutOfRangeException()
      };
    }
  }
}
