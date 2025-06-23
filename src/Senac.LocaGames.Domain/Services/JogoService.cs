using Senac.LocaGames.Domain.Dtos.Jogo.Request;
using Senac.LocaGames.Domain.Dtos.Jogo.Response;
using Senac.LocaGames.Domain.Exceptions;
using Senac.LocaGames.Domain.Extensions;
using Senac.LocaGames.Domain.Models;
using Senac.LocaGames.Domain.Repositories;

namespace Senac.LocaGames.Domain.Services
{
  public class JogoService : IJogoService
  {
    private readonly IJogoRepository _jogoRepository;

    public JogoService(IJogoRepository jogoRepository)
    {
      _jogoRepository = jogoRepository;
    }

    public async Task Alugar(AlugarRequest request)
    {
      if (request.Id == 0)
        throw new DomainException("Id deve ser maior que 0.");

      var jogo = await _jogoRepository.GetAsync(request.Id);

      if (jogo == null)
        throw new DomainException("Jogo não encontrado.");

      if (jogo.NaoDisponivel)
        throw new DomainException("Jogo já está alugado.");

      jogo.DataRetirada = DateTime.Now.AddDays(jogo.Categoria.GetPrazo());
      jogo.Disponivel = false;
      jogo.Responsavel = request.Responsavel;

      await _jogoRepository.UpdateAsync(jogo);
    }

    public async Task Atualizar(AtualizarRequest atualizarRequest)
    {
      bool isCategoriaValida = Enum.TryParse(atualizarRequest.Categoria, out Categoria categoria);
      if (!isCategoriaValida)
        throw new DomainException("Categoria inválida.");

      if (atualizarRequest.Id == 0)
        throw new DomainException("Id deve ser maior que 0.");

      var jogo = await _jogoRepository.GetAsync(atualizarRequest.Id);

      if (jogo == null)
        throw new DomainException("Jogo não encontrado.");

      if (atualizarRequest.Titulo != null)
        jogo.Titulo = atualizarRequest.Titulo;

      if (atualizarRequest.Descricao != null)
        jogo.Descricao = atualizarRequest.Descricao;

      jogo.Categoria = categoria;

      await _jogoRepository.UpdateAsync(jogo);
    }

    public async Task<CadastrarResponse> Cadastrar(CadastrarRequest request)
    {
      bool isCategoriaValida = Enum.TryParse(request.Categoria, out Categoria categoria);
      if (!isCategoriaValida)
        throw new DomainException("Categoria inválida.");

      var jogo = new Jogo(request.Titulo, request.Descricao, categoria);

      long idResponse = await _jogoRepository.InsertAsync(jogo);

      return new CadastrarResponse
      {
        Id = idResponse
      };
    }

    public async Task Deletar(long id)
    {
      if (id == 0)
        throw new DomainException("Id deve ser maior que 0.");

      var jogo = await _jogoRepository.GetAsync(id);

      if (jogo == null)
        throw new DomainException("Jogo não encontrado.");

      if (jogo.NaoDisponivel)
        throw new DomainException("O jogo atualmente está alugado e não pode ser deletado");

      await _jogoRepository.DeleteAsync(id);
    }

    public async Task Devolver(long id)
    {
      if (id == 0)
        throw new DomainException("Id deve ser maior que 0.");

      var jogo = await _jogoRepository.GetAsync(id);

      if (jogo == null)
        throw new DomainException("Jogo não encontrado.");

      if (jogo.Disponivel)
        throw new DomainException("Não é possível devolver um jogo que está disponivel.");

      jogo.DataRetirada = null;
      jogo.Disponivel = true;
      jogo.Responsavel = null;

      await _jogoRepository.UpdateAsync(jogo);
    }

    public async Task<IEnumerable<ObterTodosResponse>> ObterTodos()
    {
      var jogos = await _jogoRepository.GetAllAsync();

      var jogosResponse = jogos.Select(j => new ObterTodosResponse
      {
        Id = j.Id,
        Titulo = j.Titulo,
        Disponivel = j.Disponivel,
        DataRetirada = j.DataRetirada,
        Categoria = j.Categoria.ToString(),
        IsEmAtraso = DateTime.Now > j.DataRetirada
      });

      return jogosResponse;
    }
  }
}
