using Dapper;
using Senac.LocaGames.Domain.Models;
using Senac.LocaGames.Domain.Repositories;
using Senac.LocaGames.Infra.Data.DatabaseConfiguration;

namespace Senac.LocaGames.Infra.Data.Repositories
{
  public class JogoRepository : BaseRepository<Jogo>, IJogoRepository
  {
    private readonly IDbConnectionFactory _connectionFactory;

    public JogoRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

    public async override Task DeleteAsync(long id)
    {
      await Connection.QueryFirstOrDefaultAsync<Jogo>(
        @"
        DELETE
        FROM jogo
        WHERE id = @Id
        ",
        new
        {
          Id = id
        });
    }

    public async Task<IEnumerable<Jogo>> GetAllAsync()
    {
      return await Connection.QueryAsync<Jogo>(
        @"
        SELECT id, 
          titulo, 
          disponivel, 
          categoria_id as Categoria, 
          data_retirada AS DataRetirada
        FROM jogo
        ORDER BY titulo;
        ");
    }

    public override async Task<Jogo> GetAsync(long id)
    {
      return await Connection.QueryFirstOrDefaultAsync<Jogo>(
        @"
        SELECT id, 
          titulo,
          descricao,
          disponivel,
          responsavel,
          categoria_id as Categoria, 
          data_retirada AS DataRetirada
        FROM jogo
        WHERE id = @Id
        ",
        new
        {
          Id = id
        });
    }

    public override async Task<long> InsertAsync(Jogo entity)
    {
      return await Connection.QueryFirstOrDefaultAsync<long>(
        @"
        INSERT INTO jogo 
          (titulo, 
          descricao, 
          disponivel, 
          categoria_id, 
          responsavel, 
          data_retirada) 
        VALUES 
          (@Titulo, 
          @Descricao, 
          @Disponivel, 
          @Categoria, 
          @Responsavel, 
          @DataRetirada)
        RETURNING id;
        ",
        entity);
    }

    public override async Task UpdateAsync(Jogo entity)
    {
      await Connection.QueryFirstOrDefaultAsync(
       @"
        UPDATE 
          jogo 
        SET
          titulo = @Titulo,
          descricao = @Descricao,
          disponivel = @Disponivel, 
          categoria_id = @Categoria, 
          responsavel = @Responsavel, 
          data_retirada = @DataRetirada 
        WHERE id = @Id;
        ",
       entity);
    }
  }
}
