using Cod3rsGrowth.Web.DetalhesDeProblemas;
using Cod3rsGrowth.Web.Injecao;

var builder = WebApplication.CreateBuilder(args);
var colecaoDeServicos = new ServiceCollection();

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