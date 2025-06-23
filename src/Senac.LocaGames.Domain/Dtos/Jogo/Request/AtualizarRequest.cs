using System.Text.Json.Serialization;

namespace Senac.LocaGames.Domain.Dtos.Jogo.Request
{
  public class AtualizarRequest
  {
    [JsonIgnore]
    public long Id { get; set; }

    public string Titulo { get; set; }

    public string Descricao { get; set; }

    public string Categoria { get; set; }
  }
}
