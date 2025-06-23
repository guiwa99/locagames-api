
using Senac.LocaGames.Domain.Repositories;
using Senac.LocaGames.Domain.Services;
using Senac.LocaGames.Infra.Data.DatabaseConfiguration;
using Senac.LocaGames.Infra.Data.Repositories;

namespace Senac.LocaGames.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      var configuration = builder.Configuration;

      // Add services to the container.
      builder.Services.AddScoped<IDbConnectionFactory>(x =>
      {
        string connectionString = configuration.GetConnectionString("LocaGames");
        if (connectionString == null)
          throw new InvalidOperationException("Connection string não configurada");

        return new DbConnectionFactory(connectionString);
      });

      builder.Services.AddScoped<IJogoRepository, JogoRepository>();
      builder.Services.AddScoped<IJogoService, JogoService>();


      builder.Services.AddControllers();
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();

      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
