using System.Text.Json.Serialization;

namespace Senac.LocaGames.Domain.Dtos.Jogo.Request
{
  public class AlugarRequest
  {
    [JsonIgnore]
    public long Id  { get; set; }

    public string Responsavel { get; set; }
  }
}
