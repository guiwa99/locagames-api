using Senac.LocaGames.Domain.Dtos.Jogo.Request;
using Senac.LocaGames.Domain.Dtos.Jogo.Response;

namespace Senac.LocaGames.Domain.Services
{
  public interface IJogoService
  {
    Task<CadastrarResponse> Cadastrar(CadastrarRequest request);

    Task<IEnumerable<ObterTodosResponse>> ObterTodos();

    Task Alugar(AlugarRequest request);

    Task Devolver(long id);

    Task Atualizar(AtualizarRequest atualizarRequest);

    Task Deletar(long id);
  }
}
