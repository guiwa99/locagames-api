namespace Senac.LocaGames.Domain.Exceptions
{
  public class DomainException : Exception
  {
    public DomainException(string message, string errorCode) : base(message)
    {
      CodigoErro = errorCode;
    }

    public DomainException(string message) : base(message)
    {
    }

    public string CodigoErro { get; set; }
  }
}
