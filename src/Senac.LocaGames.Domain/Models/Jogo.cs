namespace Senac.LocaGames.Domain.Models
{
  public class Jogo
  {
    public Jogo(string titulo, string descricao, Categoria categoria)
    {
      Titulo = titulo;
      Descricao = descricao;
      Categoria = categoria;
      Disponivel = true;
      DataRetirada = null;
    }

    public Jogo(long id, string titulo, bool disponivel, Categoria categoria, DateTime? dataRetirada)
    {
      Id = id;
      Titulo = titulo;
      Disponivel = disponivel;
      Categoria = categoria;
      DataRetirada = dataRetirada;
    }

    public Jogo(long id, string titulo, string descricao, bool disponivel, string responsavel, Categoria categoria, DateTime? dataRetirada)
    {
      Id = id;
      Titulo = titulo;
      Descricao = descricao;
      Disponivel = disponivel;
      Responsavel = responsavel;
      Categoria = categoria;
      DataRetirada = dataRetirada;
    }

    public long Id { get; set; }

    public string Titulo { get; set; }

    public string Descricao { get; set; }

    public bool Disponivel { get; set; }

    public Categoria Categoria { get; set; }

    public string Responsavel { get; set; }

    public DateTime? DataRetirada { get; set; }

    public bool NaoDisponivel => !Disponivel;
  }
}
