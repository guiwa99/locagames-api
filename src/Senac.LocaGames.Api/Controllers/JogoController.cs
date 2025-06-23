using Microsoft.AspNetCore.Mvc;
using Senac.LocaGames.Domain.Dtos;
using Senac.LocaGames.Domain.Dtos.Jogo.Request;
using Senac.LocaGames.Domain.Exceptions;
using Senac.LocaGames.Domain.Services;

namespace Senac.LocaGames.Api.Controllers
{
  [ApiController]
  [Route("jogo")]
  public class JogoController : Controller
  {
    private readonly IJogoService _jogoService;

    public JogoController(IJogoService usuarioService)
    {
      _jogoService = usuarioService;
    }

    [HttpPost()]
    public async Task<IActionResult> Cadastrar(CadastrarRequest cadastrarRequest)
    {
      try
      {
        var response = await _jogoService.Cadastrar(cadastrarRequest);

        return Ok();
      }
      catch (DomainException ex)
      {
        return BadRequest(new DefaultErrorResponse
        {
          Mensagem = ex.Message,
          Codigo = ex.CodigoErro
        });
      }
      catch (Exception ex)
      {
        return StatusCode(500, new DefaultErrorResponse { Mensagem = ex.Message });
      }
    }

    [HttpGet()]
    public async Task<IActionResult> ObterTodos()
    {
      try
      {
        var response = await _jogoService.ObterTodos();

        return Ok(response);
      }
      catch (DomainException ex)
      {
        return BadRequest(new DefaultErrorResponse
        {
          Mensagem = ex.Message,
          Codigo = ex.CodigoErro
        });
      }
      catch (Exception ex)
      {
        return StatusCode(500, new DefaultErrorResponse { Mensagem = ex.Message });
      }
    }

    [HttpPut("{id}/alugar")]
    public async Task<IActionResult> Alugar([FromBody] AlugarRequest request, [FromRoute] long id)
    {
      try
      {
        await _jogoService.Alugar(new AlugarRequest { Id = id, Responsavel = request.Responsavel });

        return Ok();
      }
      catch (DomainException ex)
      {
        return BadRequest(new DefaultErrorResponse
        {
          Mensagem = ex.Message,
          Codigo = ex.CodigoErro
        });
      }
      catch (Exception ex)
      {
        return StatusCode(500, new DefaultErrorResponse { Mensagem = ex.Message });
      }
    }

    [HttpPut("{id}/devolver")]
    public async Task<IActionResult> Devolver([FromRoute] long id)
    {
      try
      {
        await _jogoService.Devolver(id);

        return Ok();
      }
      catch (DomainException ex)
      {
        return BadRequest(new DefaultErrorResponse
        {
          Mensagem = ex.Message,
          Codigo = ex.CodigoErro
        });
      }
      catch (Exception ex)
      {
        return StatusCode(500, new DefaultErrorResponse { Mensagem = ex.Message });
      }
    }

    [HttpPut("{id}/atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarRequest request, [FromRoute] long id)
    {
      try
      {
        var atualizarRequest = new AtualizarRequest
        {
          Id = id,
          Titulo = request.Titulo,
          Descricao = request.Descricao,
          Categoria = request.Categoria
        };

        await _jogoService.Atualizar(atualizarRequest);

        return Ok();
      }
      catch (DomainException ex)
      {
        return BadRequest(new DefaultErrorResponse
        {
          Mensagem = ex.Message,
          Codigo = ex.CodigoErro
        });
      }
      catch (Exception ex)
      {
        return StatusCode(500, new DefaultErrorResponse { Mensagem = ex.Message });
      }
    }

    [HttpPut("{id}/deletar")]
    public async Task<IActionResult> Deletar([FromRoute] long id)
    {
      try
      {
        await _jogoService.Deletar(id);

        return Ok();
      }
      catch (DomainException ex)
      {
        return BadRequest(new DefaultErrorResponse
        {
          Mensagem = ex.Message,
          Codigo = ex.CodigoErro
        });
      }
      catch (Exception ex)
      {
        return StatusCode(500, new DefaultErrorResponse { Mensagem = ex.Message });
      }
    }
  }
}
