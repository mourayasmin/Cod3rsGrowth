using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Web.DetalhesDeProblemas;
using Cod3rsGrowth.Web.Injecao;
using FluentMigrator.Runner;

var builder = WebApplication.CreateBuilder(args);
var colecaoDeServicos = new ServiceCollection();

if(args?.FirstOrDefault() == "BancoTeste")
{
    StringDeConexao.connectionString = "ConnectionStringTeste";
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.ConfigurarServicos();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.ExibeDetalhesDeProblemasDeExcecaoNaAPI(app.Services.GetRequiredService<ILoggerFactory>());

app.UseFileServer(new FileServerOptions()
{
    EnableDirectoryBrowsing = true
});

app.UseStaticFiles(new StaticFileOptions()
{
    ServeUnknownFileTypes = true
});

app.Run();