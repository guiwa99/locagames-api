namespace Senac.LocaGames.Domain.Dtos.Jogo.Response
{
  public class ObterTodosResponse
  {
    public long Id { get; set; }

    public string Titulo { get; set; }

    public bool Disponivel { get; set; }

    public string Categoria { get; set; }

    public DateTime? DataRetirada { get; set; }

    public bool IsEmAtraso { get; set; }
  }
}
